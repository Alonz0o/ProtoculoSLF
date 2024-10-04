using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySqlConnector;
using System.Security.Cryptography;
using static System.Windows.Forms.MonthCalendar;
using System.Windows.Forms;
using ProtoculoSLF.Model;
using DevExpress.DataProcessing.InMemoryDataProcessor;

namespace ProtoculoSLF.Repository
{
    public class BaseRepository
    {
        private readonly string connectionString;

        public BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexionAriel"].ToString();
        }

        internal void GetProtocolos()
        {
            List<Protocolo> ps = new List<Protocolo>();
            List<ProtocoloItem> pis = new List<ProtocoloItem>();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT e.IdCodigo,e.formato_protocol,e.fecha_modificacion,fp.Descripcion
                                        FROM extrusion e 
                                        LEFT JOIN formatosdeprotocolos fp ON e.formato_protocol=fp.id_formato;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Protocolo p = new Protocolo
                        {
                            Id = reader[0] != DBNull.Value ? Convert.ToInt32(reader.GetDouble(0)) : 0,
                            FormatoProtocolo = reader[1] != DBNull.Value ? reader.GetInt32(1) : 0,
                            Fecha = reader[2] != DBNull.Value ? reader.GetDateTime(2) : new DateTime(1993, 1, 20),
                            Descripcion = reader[3] != DBNull.Value ? reader.GetString(3) : "",
                        };
                        ps.Add(p);
                    }
                }

                Form1.instancia.protocolos = ps;
            }
        }

        internal List<ProtocoloItem> GetProtocolosItems(object idProtocolo)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT pi.iditem,pi.controles,pi.unidad,pi.orden,pi.certificado,pi.idformatoprotocoloa
                                        FROM formatoprotocoloa_item pi
                                        WHERE pi.idformatoprotocoloa = @pIdProtocolo;";
                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Nombre = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Medida = reader[2] != DBNull.Value ? reader.GetString(2) : "",
                            Orden = reader[3] != DBNull.Value ? reader.GetInt32(3) : 0,
                            EsCertificado = reader[4] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(4)) : false,
                            IdProtocolo = reader[5] != DBNull.Value ? reader.GetInt32(5) : 0,
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal List<NT> GetNTs(object idCodigo)
        {
            List<NT> nts = new List<NT>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT id,nt,o_p,cliente,pallets,creado,cant_bobinas FROM nt WHERE codigo=@pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NT n = new NT
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            NumNT = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                            OP = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Cliente = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            NumPallet = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                            Creado = reader.IsDBNull(5) ? new DateTime(1993,01,20) : reader.GetDateTime(5),
                            CantidadBobinas = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        };
                        nts.Add(n);
                    }
                }
            }
            return nts;
        }

    }
}
