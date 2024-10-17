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
using DevExpress.XtraRichEdit.Import.Html;

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
        internal int GetCambios()
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var command = conexion.CreateCommand())
                {
                    command.CommandText = "SELECT id_nt_log,valor_log,correcto_log,accion_creada FROM formatoprotocoloa_ensayo_log WHERE accion_creada >= NOW() - INTERVAL 5 SECOND;";
                    return command.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(command.ExecuteScalar()) : 0;
                }
            }
        }

        internal bool InsertEnsayo(int idNt, int idProtocoloItem, double valor, int correcto)
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
                            command.CommandText = @"INSERT INTO formatoprotocoloa_ensayo (id_nt,id_protocolo_item,valor_ensayo,correcto) 
                                                                                  VALUES (@pIdNt,@pIdProtocoloItem,@pValor,@pCorrecto);";
                            command.Parameters.Add("@pIdNt", MySqlDbType.Int32).Value = idNt;
                            command.Parameters.Add("@pIdProtocoloItem", MySqlDbType.Int32).Value = idProtocoloItem;
                            command.Parameters.Add("@pValor", MySqlDbType.Double).Value = valor;
                            command.Parameters.Add("@pCorrecto", MySqlDbType.Int32).Value = correcto;

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
        


        internal void GetProtocolos()
        {
            List<Protocolo> ps = new List<Protocolo>();
            List<ProtocoloItem> pis = new List<ProtocoloItem>();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT e.IdCodigo,e.formato_protocol,e.fecha_modificacion,fp.Descripcion,e.Numero_Art_Cliente
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
                            CodigoCliente = reader[4] != DBNull.Value ? reader.GetString(4) : "",
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
                command.CommandText = @"SELECT fi.iditem,fi.controles,fi.unidad,fi.certificado,fi.simbolo,fi.especificacion_min,fi.especificacion,fi.especificacion_max
                                        FROM formatoprotocoloa_item fi;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        var simbolo = reader[4] != DBNull.Value ? reader.GetString(4) : "";
                        var espeficacionMin = reader[5] != DBNull.Value ? reader.GetDouble(5) : 0.0;
                        var espeficacion = reader[6] != DBNull.Value ? reader.GetDouble(6) : 0.0;
                        var espeficacionMax = reader[7] != DBNull.Value ? reader.GetDouble(7) : 0.0;
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Nombre = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Medida = reader[2] != DBNull.Value ? reader.GetString(2) : "",
                            EspecificacionMin = espeficacionMin,
                            Especificacion = espeficacion,
                            EspecificacionMax = espeficacionMax,
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
                            EspecificacionDato = simbolo == "-" ? espeficacionMin + " - " + espeficacionMax : simbolo == "N" ? "VALIDA" : espeficacion + " " + simbolo + " " + espeficacionMax,
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
                command.CommandText = @"SELECT fi.iditem,fi.controles,fi.unidad,fi.certificado,fi.simbolo,fi.especificacion_min,fi.especificacion,fi.especificacion_max,fpi.orden,fpi.id
                                        FROM formatoprotocoloa_protocolo_item fpi
                                        JOIN formatoprotocoloa_item fi on fpi.id_item = fi.iditem
                                        WHERE fpi.id_protocolo = @pIdProtocolo;";
                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        var simbolo = reader[4] != DBNull.Value ? reader.GetString(4) : "";
                        var espeficacionMin = reader[5] != DBNull.Value ? reader.GetDouble(5) : 0.0;
                        var espeficacion = reader[6] != DBNull.Value ? reader.GetDouble(6) : 0.0;
                        var espeficacionMax = reader[7] != DBNull.Value ? reader.GetDouble(7) : 0.0;
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Nombre = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Medida = reader[2] != DBNull.Value ? reader.GetString(2) : "",
                            EspecificacionMin = espeficacionMin,
                            Especificacion = espeficacion,
                            EspecificacionMax = espeficacionMax,
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
                            EspecificacionDato = simbolo == "-" ? espeficacionMin + " - " + espeficacionMax : simbolo == "N" ? "VALIDA" : espeficacion + " " + simbolo + " " + espeficacionMax,
                            Orden = reader[8] != DBNull.Value ? reader.GetInt32(8) : 0,
                            IdProtocoloItem = reader[9] != DBNull.Value ? reader.GetInt32(9) : 0,
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
                            Creado = reader.IsDBNull(5) ? new DateTime(1993, 01, 20) : reader.GetDateTime(5),
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
                command.CommandText = @"SELECT fe.id,fi.controles,fe.valor_ensayo,fe.correcto,fi.simbolo,fpi.orden,fi.especificacion_min,fi.especificacion,fi.especificacion_max,fe.id_protocolo_item,fi.unidad
                                        FROM formatoprotocoloa_ensayo fe
                                        JOIN formatoprotocoloa_protocolo_item fpi on fe.id_protocolo_item = fpi.id
                                        JOIN formatoprotocoloa_item fi on fpi.id_item = fi.iditem
                                        WHERE fpi.id_protocolo = @pIdProtocolo;";
                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var valorEnsayo = reader[2] != DBNull.Value ? reader.GetDouble(2) : 0.0;
                        var simbolo = reader[4] != DBNull.Value ? reader.GetString(4) : "";
                        var esCorrecto = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        ProtocoloEnsayo pe = new ProtocoloEnsayo
                        {
                            Id = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Nombre = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Simbolo = simbolo,
                            ValorEnsayo = simbolo == "N" ? (esCorrecto ? "OK" : "NO") : valorEnsayo.ToString(),
                            EsCorrectoSiNo = esCorrecto ? "SI" : "NO",
                            Orden = reader[5] != DBNull.Value ? reader.GetInt32(5) : 0,
                            EspecificacionMin = reader[6] != DBNull.Value ? reader.GetDouble(6) : 0.0,
                            Especificacion = reader[7] != DBNull.Value ? reader.GetDouble(7) : 0.0,
                            EspecificacionMax = reader[8] != DBNull.Value ? reader.GetDouble(8) : 0.0,
                            IdProtocoloItem = reader[9] != DBNull.Value ? reader.GetInt32(9) : 0,
                            Unidad = reader[10] != DBNull.Value ? reader.GetString(10) : "",
                        };
                        pes.Add(pe);
                    }
                }
            }

            return pes.GroupBy(i => i.Nombre)
                .Select(grupo => new ProtocoloEnsayo
                {
                    Id = grupo.FirstOrDefault().Id,
                    Nombre = grupo.Key,
                    ValorEnsayo = grupo.FirstOrDefault().Simbolo == "N" ? grupo.FirstOrDefault().ValorEnsayo : grupo.Where(p => double.TryParse(p.ValorEnsayo, out _))
                                                                                       .Select(p => double.Parse(p.ValorEnsayo))
                                                                                       .DefaultIfEmpty(0)
                                                                                       .Average().ToString(),
                    Orden = grupo.FirstOrDefault().Orden,
                    EspecificacionMin = grupo.FirstOrDefault().EspecificacionMin,
                    Especificacion = grupo.FirstOrDefault().Especificacion,
                    EspecificacionMax = grupo.FirstOrDefault().EspecificacionMax,
                    IdProtocoloItem = grupo.FirstOrDefault().IdProtocoloItem,
                    Simbolo = grupo.FirstOrDefault().Simbolo,
                    Unidad = grupo.FirstOrDefault().Unidad,
                }).ToList();
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
        internal bool ModificarNtIdProtocolo(int idNt, int idNtProtocolo)
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

        internal bool GetNombreItemDuplicado(string nombre)
        {
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT iditem FROM formatoprotocoloa_item where controles = @pNombre;";
                command.Parameters.Add("@pNombre", MySqlDbType.String).Value = nombre;
                var pp = command.ExecuteScalar();
                if (pp == null) return true;
                else return false;
            }
        }

        internal int GetUltimaPosicionProtocoloItem(int idProtocolo)
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var command = conexion.CreateCommand())
                {
                    command.CommandText = @"SELECT max(fpi.orden)
                                            FROM formatoprotocoloa_protocolo_item fpi
                                            WHERE fpi.id_protocolo = @pIdProtocolo;";
                    command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                    return command.ExecuteScalar() != DBNull.Value ? (int)command.ExecuteScalar() : 0;
                }
            }
        }

        internal List<ProtocoloEnsayo> GetEnsayosPorIdProtocoloItem(ProtocoloEnsayo peSeleccionado)
        {
            List<ProtocoloEnsayo> pes = new List<ProtocoloEnsayo>();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fe.valor_ensayo FROM formatoprotocoloa_ensayo fe where fe.id_protocolo_item=@pIdProtocoloItem;";
                command.Parameters.Add("@pIdProtocoloItem", MySqlDbType.Int32).Value = peSeleccionado.IdProtocoloItem;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProtocoloEnsayo pe = new ProtocoloEnsayo
                        {
                            Nombre = peSeleccionado.Nombre,
                            ValorEnsayo = reader.IsDBNull(0) ? "" : reader.GetDouble(0).ToString(),
                            Especificacion = peSeleccionado.Especificacion,
                        };
                        pes.Add(pe);
                    }
                }

                return pes;
            }
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
                            command.CommandText = @"INSERT INTO formatoprotocoloa_item (controles,unidad,usuario,certificado,especificacion_min,especificacion,especificacion_max,simbolo) 
                                                                                VALUES (@pNombre,@pMedida,@pUsuario,@pEsCertificado,@pEpecificacionMin,@pEspecificacion,@pEpecificacionMax,@pCaracter)";
                            command.Parameters.Add("@pNombre", MySqlDbType.String).Value = pi.Nombre;
                            command.Parameters.Add("@pMedida", MySqlDbType.String).Value = pi.Medida;
                            command.Parameters.Add("@pUsuario", MySqlDbType.String).Value = "ARIEL ALON";
                            command.Parameters.Add("@pEsCertificado", MySqlDbType.Int32).Value = pi.EsCertificado;
                            command.Parameters.Add("@pEpecificacionMin", MySqlDbType.Int32).Value = pi.EspecificacionMin;
                            command.Parameters.Add("@pEspecificacion", MySqlDbType.Double).Value = pi.Especificacion;
                            command.Parameters.Add("@pEpecificacionMax", MySqlDbType.Int32).Value = pi.EspecificacionMax;
                            command.Parameters.Add("@pCaracter", MySqlDbType.String).Value = pi.Simbolo;
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
        internal bool DeleteItem(string qryUpdate, int idItem)
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
                            command.CommandText = @"DELETE FROM formatoprotocoloa_item WHERE (iditem = @pIdItem);";
                            command.Parameters.Add("@pIdItem", MySqlDbType.Int32).Value = idItem;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al modificar TX");
                            }

                            if (qryUpdate != "NO")
                            {
                                command.CommandText = qryUpdate;
                                if (command.ExecuteNonQuery() <= 0)
                                {
                                    throw new Exception("Error al actualizar SCRAPS");
                                }
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

        internal bool UpdateItem(string qryUpdate, ProtocoloItem pi)
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
                            command.CommandText = @"UPDATE formatoprotocoloa_item SET controles = @pNombre,
                                                                                      unidad = @pMedida,
                                                                                      usuario = @pUsuario,
                                                                                      certificado = @pEsCertificado,
                                                                                      especificacion_min = @pEpecificacionMin,
                                                                                      especificacion = @pEspecificacion,
                                                                                      especificacion_max = @pEpecificacionMax,
                                                                                      simbolo = @pSimbolo
                                                                                      WHERE iditem = (@pIdItem);";
                            command.Parameters.Add("@pNombre", MySqlDbType.String).Value = pi.Nombre;
                            command.Parameters.Add("@pMedida", MySqlDbType.String).Value = pi.Medida;
                            command.Parameters.Add("@pUsuario", MySqlDbType.String).Value = "ARIEL ALON";
                            command.Parameters.Add("@pEsCertificado", MySqlDbType.Int32).Value = pi.EsCertificado;
                            command.Parameters.Add("@pEpecificacionMin", MySqlDbType.Double).Value = pi.EspecificacionMin;
                            command.Parameters.Add("@pEspecificacion", MySqlDbType.Double).Value = pi.Especificacion;
                            command.Parameters.Add("@pEpecificacionMax", MySqlDbType.Double).Value = pi.EspecificacionMax;
                            command.Parameters.Add("@pSimbolo", MySqlDbType.String).Value = pi.Simbolo;
                            command.Parameters.Add("@pIdItem", MySqlDbType.Int32).Value = pi.Id;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al modificar TX");
                            }

                            if (qryUpdate != "NO")
                            {
                                command.CommandText = qryUpdate;
                                if (command.ExecuteNonQuery() <= 0)
                                {
                                    throw new Exception("Error al actualizar SCRAPS");
                                }
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
