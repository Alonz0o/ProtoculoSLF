using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoculoSLF.Model
{
    internal class OP
    {
        public int Id { get; set; }
        public int CantProduccion { get; set; }
        public int Orden { get; set; }
        public int Codigo { get; set; }
        public string Maquina { get; set; }
        public int Cantidad { get; set; }
        public int Prioridad { get; set; }
        public override string ToString()
        {
            return Orden + "/" + Codigo;
        }
    }
}
