using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoculoSLF.Model
{
    internal class Simbolo
    {
        public string Caracter { get; set; }
        public string Significado { get; set; }
        public override string ToString()
        {
            return Caracter+" ("+ Significado+")";
        }
    }
}
