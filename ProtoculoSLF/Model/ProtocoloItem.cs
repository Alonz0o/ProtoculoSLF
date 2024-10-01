using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoculoSLF.Model
{
    internal class ProtocoloItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Medida { get; set; }
        public int Orden { get; set; }
        public bool EsCertificado { get; set; }
        public int IdProtocolo { get; set; }
    }
}
