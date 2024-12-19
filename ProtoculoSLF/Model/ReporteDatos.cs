using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoculoSLF.Model
{
    public class ReporteDatos
    {
        public string Lote { get; set; }
        public int NT { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int Pallet { get; set; }
        public string CodigoCliente { get; set; }
        public string SolicitudCliente { get; set; }
        public int Remito { get; set; }
        public int OrdenDeCompra { get; set; }


    }
}
