namespace ProtoculoSLF.Model
{
    public class ProtocoloItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Medida { get; set; }
        public string Simbolo { get; set; }
        public int Orden { get; set; }
        public double EspecificacionMin { get; set; }
        public double Especificacion { get; set; }
        public double EspecificacionMax { get; set; }
        public bool EsCertificado { get; set; }
        public string EsCertificadoSiNo { get; set; }
        public int IdProtocoloItem { get; set; }
        public string EspecificacionDato { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
