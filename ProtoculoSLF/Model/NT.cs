using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoculoSLF.Model
{
    public class NT
    {
        public int Id { get; set; }
        public int NumNT { get; set; }
        public string Orden { get; set; }
        public string Cliente { get; set; }
        public int NumPallet { get; set; }
        public int CantidadBobinas { get; set; }
        public DateTime Creado { get; set; }
        public int IdProtocolo { get; set; }
        public int CantidadEnsayos { get; set; }
    }
}
