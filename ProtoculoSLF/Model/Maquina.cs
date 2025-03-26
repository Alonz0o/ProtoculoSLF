using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoculoSLF.Model
{
    internal class Maquina
    {
        public string Sector { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }

    }
}
