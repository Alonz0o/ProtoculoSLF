using System;

namespace ProtoculoSLF.Model
{
    public class Protocolo
    {
        public int Id { get; set; }
        public int FormatoProtocolo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string CodigoCliente { get; set; }
        public override string ToString()
        {
            return FormatoProtocolo.ToString();
        }

    }

}
