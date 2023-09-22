using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using Ej1_plan_de_pagos.Modelo;
using CalendarioClassLib.Modelo;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ej1_plan_de_pagos
{
    public partial class FormPrincipal : Form
    {
        Municipalidad muni;
        string nombreFichero = "sistema.dat";

        Infractor infractorSelected = null;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;

            FileStream fs = null;
            try
            {
                string pathCompleto = Path.Combine(path, nombreFichero);

                if (File.Exists(pathCompleto))//cuando corre por primera vez, se supone que no existe
                {
                    fs = new FileStream(pathCompleto, FileMode.Open, FileAccess.Read);

                    if (fs.Length > 0) //normalmente cuando se crea el fichero y no se hace el close queda de tamaño cero.
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        muni = bf.Deserialize(fs) as Municipalidad;
                    }
                }
            }
            catch (Exception ex)
            {
                //si hubo cambios en las clases va a dar error de deserialización
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
            }

            //preinicialización
            if (muni == null)
            {
                muni = new Municipalidad();
            }
        }

        /*
        Forma alternativa - ojo aquí para programación 1
        private void btnAgregarFeriado_Click(object sender, EventArgs e)
        {
            FormDatosFeriado fDatoFeriado = new FormDatosFeriado();
            fDatoFeriado.Calendario = muni.Calendario;
            fDatoFeriado.ShowDialog();
        }
        */

        /*Forma recomendada*/
        private void btnAgregarFeriado_Click(object sender, EventArgs e)
        {
            FormDatosFeriado fDatoFeriado = new FormDatosFeriado();

            fDatoFeriado.ShowDialog();

            do
            {
                if (fDatoFeriado.DialogResult == DialogResult.OK)
                {
                    DateTime dia = fDatoFeriado.pickFecha.Value;
                    string descripcion = fDatoFeriado.tbDescripcion.Text;

                    muni.Calendario.AgregarFeriado(dia, descripcion);
                }
                else if (fDatoFeriado.DialogResult == DialogResult.Retry)
                {
                    DateTime dia = fDatoFeriado.pickFecha.Value;

                    Feriado feriado=muni.Calendario.Buscar(dia);
                    if (feriado != null)
                        fDatoFeriado.tbDescripcion.Text = feriado.Descripcion;
                    else
                        fDatoFeriado.tbDescripcion.Clear();
                }
                fDatoFeriado.ShowDialog();

            } while (fDatoFeriado.DialogResult!=DialogResult.Cancel);
        }

        private void btnCrearPlan_Click(object sender, EventArgs e)
        {
            FormEdicionPlan fPlan = new FormEdicionPlan();

            if (infractorSelected != null)
            {
                fPlan.tbDni.Text = infractorSelected.Dni.ToString();
                fPlan.tbApellidosYNombres.Text = infractorSelected.ApelldosYNombres.ToString();
                fPlan.tbApellidosYNombres.Enabled = false;
                fPlan.tbDni.Enabled = false;
            }
            else
            {
                fPlan.tbDni.Text = tbDni.Text;
                fPlan.tbApellidosYNombres.Enabled = true;
            }                

            if (fPlan.ShowDialog() == DialogResult.OK)
            {
                
                double monto = Convert.ToDouble(fPlan.tbMonto.Text);
                int cantCuotas = Convert.ToInt32(fPlan.nupCuotas.Value);
                DateTime fechaAltaPlan = fPlan.pickerInicio.Value;

                //lo agrega si no lo encontro 
                if (infractorSelected == null)
                {
                    int dni = Convert.ToInt32(fPlan.tbDni.Text);
                    string apellidoYNombre = fPlan.tbApellidosYNombres.Text;

                    infractorSelected = muni.AgregarInfractor(dni, apellidoYNombre);
                }

                PlanDePago nuevoPlan = muni.CrearPlanDePagos(infractorSelected.Dni, monto, cantCuotas, fechaAltaPlan);

                FormResumen fResumen = new FormResumen();
                fResumen.tbResumen.Text=nuevoPlan.VerDetalle();
                fResumen.ShowDialog();
                fResumen.Dispose();
            }
            
            fPlan.Dispose();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Application.StartupPath;

            FileStream fs = null;
            try
            {
                string pathCompleto = Path.Combine(path, nombreFichero);

                fs = new FileStream(pathCompleto, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, muni);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDni.Text.Trim())==false)
            {
                int dni = Convert.ToInt32(tbDni.Text);

                infractorSelected = muni.BuscarInfractor(dni);

                if (infractorSelected != null)
                {
                    tbApellidosYNombres.Text = infractorSelected.ApelldosYNombres;
                    btnCrearPlan.Enabled = true;

                    cbPlanesDelInfractor.Enabled = true;
                    List<PlanDePago> planes=muni.VerPlanesDelInfractor(dni);
                    cbPlanesDelInfractor.Items.AddRange(planes.ToArray());
                }
                else
                {
                    tbApellidosYNombres.Text = "";
                    tbApellidosYNombres.Enabled = false;
                    btnCrearPlan.Enabled = true;
                }
            }
        }

        private void btnConsultarPlanes_Click(object sender, EventArgs e)
        {
            PlanDePago selected=cbPlanesDelInfractor.SelectedItem as PlanDePago;
            if (selected != null)
            {
                FormResumen fResumen = new FormResumen();
                fResumen.tbResumen.Text = selected.VerDetalle();
                fResumen.ShowDialog();
                fResumen.Dispose();
            }
        }

        private void tbDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void importraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> listado = new List<string>();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    string path = openFileDialog1.FileName;

                    //creamos el manejador
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

                    //flujo de texto
                    StreamReader sr = new StreamReader(fs);

                    //ciclo de escritura
                    while(sr.EndOfStream==false)
                    {
                        string linea=sr.ReadLine();
                        listado.Add(linea);
                    }
                }
                catch(Exception ex)
                {
                    //tratamiento de la excepción
                }
                finally
                {
                    //cerrando el flujo
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
            }

            try
            {
                muni.ImportarInfracciones(listado);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClearBackColor_TextChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
                btn.BackColor = Color.White;
        }
    }
}
