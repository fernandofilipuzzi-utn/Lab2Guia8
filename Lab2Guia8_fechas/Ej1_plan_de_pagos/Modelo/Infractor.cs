using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_plan_de_pagos.Modelo
{
    [Serializable]
    class Infractor : IComparable
    {
        public int DNI { get; set; }
        public string ApelldosYNombres { get; set; }

        public Infractor() { }

        public Infractor(int dni)
        {
            this.DNI = dni;
        }

        public Infractor(int dni, string apellidoYNombre)
        {
            this.DNI = dni;
            this.ApelldosYNombres = apellidoYNombre;
        }

        public int CompareTo(object obj)
        {
            int resultado = -1;
            Infractor infractor = obj as Infractor;
            if (infractor != null)
                resultado = this.DNI.CompareTo(infractor.DNI);
            return resultado;
        }

        public override string ToString()
        {
            return $"{ApelldosYNombres}({DNI})";
        }
    }
}
