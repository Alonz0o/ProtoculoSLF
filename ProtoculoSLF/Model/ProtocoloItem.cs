using System;

namespace ProtoculoSLF.Model
{
    public class ProtocoloItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Proceso { get; set; }
        public string Medida { get; set; }
        public string Auditor { get; set; }
        public string Simbolo { get; set; }
        public int Posicion { get; set; }
        public double EspecificacionMin { get; set; }
        public double Especificacion { get; set; }
        public double EspecificacionMax { get; set; }
        public bool EsCertificado { get; set; }
        public bool EsConstante { get; set; }
        public bool EsValor { get; set; }
        public string EsCertificadoSiNo { get; set; }
        public int IdProtocolo { get; set; }
        public int IdProtocoloItem { get; set; }
        public string EspecificacionDato { get; set; }
        public bool Seleccionar { get; set; }
        public string Valor { get; set; }
        public string ValorConstante { get; set; }
        public int IdEnsayo { get; set; }
        public int Legajo { get; set; }
        public int PaqueteNum { get; set; }
        public string OP { get; set; }
        public string Turno { get; set; }
        public string Maquina { get; set; }
        public DateTime Creado { get; set; }
        public int Orden { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
