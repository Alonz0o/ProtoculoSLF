﻿using System;

namespace ProtoculoSLF.Model
{
    public class Protocolo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int FormatoProtocolo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string CodigoCliente { get; set; }
        public bool Seleccionar { get; set; }
        public int Disposicion { get; set; }
        public string Cliente { get; set; }
        public double PesoMtsTeorico { get; set; }
        public int Remito { get; set; }
        public int OrdenDeCompra { get; set; }
        public override string ToString()
        {
            return FormatoProtocolo.ToString();
        }

    }

}
