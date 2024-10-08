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
using DevExpress.Pdf.Native.BouncyCastle.Utilities.Collections;
using DevExpress.XtraBars.Customization;

namespace ProtoculoSLF.Repository
{
    public class BaseRepository
    {
        private readonly string connectionString;

        public BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexionAriel"].ToString();
        }

        internal bool InsertAProtocoloItem(string qry)
        {
            bool res = false;
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    using (var command = conexion.CreateCommand())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            command.CommandText = qry;
                            if (command.ExecuteNonQuery() <= 0)
                            {
                                throw new Exception("Error al insertar itemProtocolo");
                            }

                            transaction.Commit();
                            res = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            res = false;
                        }
                    }
                }
            }

            return res;
        }

        internal bool InsertEnsayo(int idNt,int idProtocolo,int idItem,double valor)
        {
            bool res = false;
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    using (var command = conexion.CreateCommand())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            command.CommandText = @"INSERT INTO formatoprotocoloa_protocolo_item (id_protocolo,id_item) VALUES(@pIdProtocolo, @pIdItem); SELECT LAST_INSERT_ID();";
                            command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                            command.Parameters.Add("@pIdItem", MySqlDbType.Int32).Value = idItem;
                            int idProtocoloItem = Convert.ToInt32(command.ExecuteScalar());


                            command.CommandText = @"INSERT INTO formatoprotocoloa_ensayo (id_nt,id_protocolo_item,valor_ensayo) 
                                                                                  VALUES (@pIdNt,@pIdProtocoloItem,@pValor);";
                            command.Parameters.Add("@pIdNt", MySqlDbType.Int32).Value = idNt;
                            command.Parameters.Add("@pIdProtocoloItem", MySqlDbType.Int32).Value = idProtocoloItem;
                            command.Parameters.Add("@pValor", MySqlDbType.Double).Value = valor;

                            if (command.ExecuteNonQuery() <= 0)
                            {
                                throw new Exception("Error al insertar itemProtocolo");
                            }

                            transaction.Commit();
                            res = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            res = false;
                        }
                    }
                }
            }

            return res;
        }
        internal bool AgregarItemProtocolo(ProtocoloItem pi)
        {
            bool res = false;
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    using (var command = conexion.CreateCommand())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            command.CommandText = @"INSERT INTO formatoprotocoloa_item (controles,unidad,orden,usuario,certificado) 
                                                                                VALUES (@pNombre,@pMedida,@pOrden,@pUsuario,@pEsCertificado)";
                            command.Parameters.Add("@pNombre", MySqlDbType.String).Value = pi.Nombre;
                            command.Parameters.Add("@pMedida", MySqlDbType.String).Value = pi.Medida;
                            command.Parameters.Add("@pOrden", MySqlDbType.Int32).Value = pi.Orden;
                            command.Parameters.Add("@pUsuario", MySqlDbType.String).Value = "ARIEL ALON";
                            command.Parameters.Add("@pEsCertificado", MySqlDbType.Int32).Value = pi.EsCertificado;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al insertar itemProtocolo");
                            }

                            transaction.Commit();
                            res = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            res = false;
                        }
                    }
                }
            }

            return res;
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

        internal List<ProtocoloItem> GetItems()
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fi.iditem,fi.controles,fi.unidad,fi.orden,fi.certificado
                                        FROM formatoprotocoloa_item fi;";
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
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal List<ProtocoloItem> GetProtocolosItems(object idProtocolo)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fi.iditem,fi.controles,fi.unidad,fi.orden,fi.certificado,fpi.id_protocolo
                                        FROM formatoprotocoloa_protocolo_item fpi
                                        JOIN formatoprotocoloa_item fi on fpi.id_item = fi.iditem
                                        WHERE fpi.id_protocolo = @pIdProtocolo;";
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
                command.CommandText = @"SELECT id,nt,o_p,cliente,pallets,creado,cant_bobinas,id_protocolo FROM nt WHERE codigo=@pIdCodigo;";
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
                            IdProtocolo = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                        };
                        nts.Add(n);
                    }
                }
            }
            return nts;
        }

        internal List<ProtocoloEnsayo> GetEnsayosItems(object idProtocolo)
        {
            List<ProtocoloEnsayo> pes = new List<ProtocoloEnsayo>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fe.id,fi.controles,fe.valor_ensayo,fe.correcto
                                        FROM formatoprotocoloa_ensayo fe
                                        JOIN formatoprotocoloa_protocolo_item fpi on fe.id_protocolo_item = fpi.id
                                        JOIN formatoprotocoloa_item fi on fpi.id_item = fi.iditem
                                        WHERE fpi.id_protocolo = @pIdProtocolo;";
                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProtocoloEnsayo pe = new ProtocoloEnsayo
                        {
                            Id = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Nombre = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            ValorEnsayo = reader[2] != DBNull.Value ? reader.GetDouble(2) : 0.0,
                            Correcto = reader[3] != DBNull.Value ? reader.GetInt32(3) : 0,
                        };
                        pes.Add(pe);
                    }
                }
            }

            return pes.GroupBy(obj => obj.Nombre)
                .Select(grupo => new ProtocoloEnsayo
                {
                    Id = grupo.FirstOrDefault().Id,
                    Nombre = grupo.Key,
                    ValorEnsayo = Math.Round(grupo.Average(obj => obj.ValorEnsayo), 2),
                    Correcto = grupo.FirstOrDefault().Correcto
                }).ToList(); ;
        }
        internal List<Protocolo> GetFormatosProtocolos()
        {
            List<Protocolo> ps = new List<Protocolo>();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT id_formato,descripcion,fecha 
                                        FROM formatosdeprotocolos;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Protocolo p = new Protocolo
                        {
                            FormatoProtocolo = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Descripcion = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Fecha = reader[2] != DBNull.Value ? reader.GetDateTime(2) : new DateTime(1993, 1, 20),
                        };
                        ps.Add(p);
                    }
                }

                return ps;
            }
        }
        internal bool ModificarNtIdProtocolo(int idNt,int idNtProtocolo)
        {
            bool res = false;
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    using (var command = conexion.CreateCommand())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            command.CommandText = @"UPDATE nt SET id_protocolo=@pIdProtocolo
                                                    WHERE id = @pID";
                            command.Parameters.Add("@pId", MySqlDbType.Int32).Value = idNt;
                            command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idNtProtocolo;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al updatear protocolo");
                            }
                            transaction.Commit();
                            res = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            res = false;
                        }
                    }
                }
            }
            return res;
        }
    }
}
