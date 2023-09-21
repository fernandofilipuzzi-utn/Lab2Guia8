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

        private void btnAgregarFeriado_Click(object sender, EventArgs e)
        {
            FormDatosFeriado fDatoFeriado = new FormDatosFeriado();
                        

            if (fDatoFeriado.ShowDialog() == DialogResult.OK)
            {
                DateTime dia = fDatoFeriado.pickFecha.Value;
                string descripcion = fDatoFeriado.tbDescripcion.Text;
             
                muni.Calendario.AgregarFeriado(dia, descripcion);
            }
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                int dni = Convert.ToInt32(tbDni.Text);
                string nombre = tbApellidosYNombres.Text;
                double monto = Convert.ToDouble(tbMonto.Text);
                int cantCuotas = Convert.ToInt32(nupCuotas.Value);
                DateTime fechaAltaPlan = pickerInicio.Value;

                if (infractorSelected == null)
                {
                    infractorSelected=muni.AgregarInfractor(dni, nombre);
                }

                PlanDePago nuevoPlan = muni.CrearPlanDePagos(dni, monto, cantCuotas, fechaAltaPlan);
                
                tbDetalle.Text = nuevoPlan.VerDetalle();

                lbxPlanesGenerados.Items.Add(nuevoPlan);

                #region limpiando controles
                tbDni.Clear();
                tbApellidosYNombres.Clear();
                tbMonto.Clear();
                nupCuotas.Value = 0;
                #endregion
            }
        }

        public bool Validar()
        {
            bool isNoOk = false;

            if (string.IsNullOrEmpty(tbDni.Text.Trim()) == true)
            {
                isNoOk |= true;
                tbDni.BackColor = Color.Orange;
            }

            if (string.IsNullOrEmpty(tbApellidosYNombres.Text.Trim()) == true)
            {
                isNoOk |= true;
                tbApellidosYNombres.BackColor = Color.Orange;
            }

            if (string.IsNullOrEmpty(tbMonto.Text.Trim()) == true)
            {
                isNoOk |= true;
                tbMonto.BackColor = Color.Orange;
            }

            return isNoOk==false;
        }

        private void tbDni_TextChanged(object sender, EventArgs e)
        {
            tbDni.BackColor = Color.White;
        }

        private void tbMonto_TextChanged(object sender, EventArgs e)
        {
            tbMonto.BackColor = Color.White;
        }

        private void tbDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) ||  char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbApellidosYNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbApellidosYNombres.BackColor = Color.White;
        }

        private void tbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' ||
                    char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void lbxPlanesGenerados_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlanDePago plan = lbxPlanesGenerados.SelectedItem as PlanDePago;
            
            if(plan !=null)
                tbDetalle.Text = plan.VerDetalle();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            int dni = Convert.ToInt32(tbDni.Text);

            infractorSelected = muni.BuscarInfractor(dni);

            if (infractorSelected == null)
            {
                tbApellidosYNombres.Enabled = true;
            }
            else
            {
                tbApellidosYNombres.Enabled = false;
                gbDatosPago.Enabled = true;
            }
        }
    }
}
