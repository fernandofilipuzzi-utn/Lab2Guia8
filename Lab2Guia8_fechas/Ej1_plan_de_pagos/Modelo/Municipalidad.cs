using CalendarioClassLib.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_plan_de_pagos.Modelo
{
    [Serializable]
    class Municipalidad
    {
        public Calendario Calendario { get; set; } = new Calendario();

        List<PlanDePago> planes = new List<PlanDePago>();
        List<Infractor> infractores = new List<Infractor>();

        public Infractor BuscarInfractor(int dni)
        {
            infractores.Sort();
            int idx = infractores.BinarySearch(new Infractor(dni));

            Infractor buscado = null;
            if (idx >= 0) buscado = infractores[idx];

            return buscado;
        }

        public Infractor AgregarInfractor(int dni, string nombre)
        {
            Infractor nuevo = new Infractor(dni, nombre);
            infractores.Add(nuevo);
            return nuevo;
        }

        public PlanDePago CrearPlanDePagos(int dni, double monto, int cantCuotas,DateTime fechaAltaPlan)
        {
            Infractor destinatario = BuscarInfractor(dni);
            PlanDePago nuevo = new PlanDePago(monto, cantCuotas, fechaAltaPlan, destinatario, Calendario);
            return nuevo;
        }
    }
}
