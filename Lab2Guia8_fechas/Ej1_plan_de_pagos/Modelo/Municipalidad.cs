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
        Calendario calendario = new Calendario();
        List<PlanDePago> planes = new List<PlanDePago>();
        List<Infractor> infractores = new List<Infractor>();
        

    }
}
