﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Clases_Reporteador
{
    public class clsReporte
    {
        private int iIdReporte;
        private string sNombre;
        private string sRuta;
        private int iEstado;

        public int IIdReporte { get => iIdReporte; set => iIdReporte = value; }
        public string SNombre { get => sNombre; set => sNombre = value; }
        public string SRuta { get => sRuta; set => sRuta = value; }
        public int IEstado { get => iEstado; set => iEstado = value; }
    }
}
