using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoculoSLF.Model
{
    public class ProtocoloEnsayo
    {
        public int Id { get; set; }
        public string ValorEnsayo { get; set; }
        public string Nombre { get; set; }
        public int Correcto { get; set; }
        public double EspecificacionMin { get; set; }
        public double Especificacion { get; set; }
        public double EspecificacionMax { get; set; }
        public string Unidad { get; set; }
        public string Simbolo { get; set; }
        public string EsCorrectoSiNo { get; set; }
        public int Orden { get; set; }
        public int IdProtocoloItem { get; set; }
    }
}
