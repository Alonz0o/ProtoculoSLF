namespace ProtoculoSLF.Model
{
    public class ProtocoloItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Medida { get; set; }
        public int Orden { get; set; }
        public bool EsCertificado { get; set; }
        public int IdProtocolo { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
