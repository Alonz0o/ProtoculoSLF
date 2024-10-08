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
        public double ValorEnsayo { get; set; }
        public string Nombre { get; set; }
        public int Correcto { get; set; }

    }
}
