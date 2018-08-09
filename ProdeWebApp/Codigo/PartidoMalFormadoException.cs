﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdeWebApp.Codigo
{
    public class PartidoMalFormadoException : Exception
    {
        public string Equipo1 { get; set; }

        public string Equipo2 { get; set; }

        public override string ToString()
        {
            return $"Error en partido de {Equipo1} vs. {Equipo2}, {Message}";
        }
    }
}
