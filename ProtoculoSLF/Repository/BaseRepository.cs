using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using MySqlConnector;
using ProtoculoSLF.Model;

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
                    command.CommandText = "SELECT id_nt_log,valor_log,correcto_log,accion_creada FROM formato_ensayo_log WHERE accion_creada >= NOW() - INTERVAL 5 SECOND;";
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
                            command.CommandText = @"INSERT INTO formato_ensayo (id_nt,id_protocolo_item,valor_ensayo,correcto) 
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
                command.CommandText = @"SELECT e.IdCodigo,e.formato_protocol,e.fecha_modificacion,fp.nombre,e.Numero_Art_Cliente,fp.por_lote,fp.por_pallet
                                        FROM extrusion e 
                                        LEFT JOIN formato_protocolo fp ON e.formato_protocol=fp.id;";
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
                            EsPorLote = reader.IsDBNull(5) ? false : Convert.ToBoolean(reader.GetInt32(5)),
                            EsPorPallet = reader.IsDBNull(6) ? false : Convert.ToBoolean(reader.GetInt32(6)),
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
                command.CommandText = @"SELECT fi.id,fi.nombre,fi.unidad,fi.certifica
                                        FROM formato_item fi;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Medida = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            EsCertificado = esCertificado,
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
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
                command.CommandText = @"SELECT fi.id,fi.nombre,fi.unidad,fi.certifica,fpi.simbolo,fpi.especificacion_min,fpi.especificacion,fpi.especificacion_max,fpi.orden,fpi.id
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_item fi on fpi.id_item = fi.id
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
        //VER VER SE MODIFICO BASE DE DATOS
        internal List<ProtocoloEnsayo> GetEnsayosItems(object idProtocolo)
        {
            List<ProtocoloEnsayo> pes = new List<ProtocoloEnsayo>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fe.id,fi.nombre,fe.valor_ensayo,fe.correcto,fpi.simbolo,fpi.orden,fpi.especificacion_min,fpi.especificacion,fpi.especificacion_max,fpi.id,fi.unidad
                                        FROM formato_ensayo fe
                                        JOIN formato_protocolo_item fpi on fe.id_protocolo_item = fpi.id
                                        JOIN formato_item fi on fpi.id_item = fi.id
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

        internal List<ProtocoloEnsayo> GetEnsayosPorIdProtocoloItem(int idProtocoloItem)
        {
            List<ProtocoloEnsayo> pes = new List<ProtocoloEnsayo>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fe.id,fi.nombre,fe.valor_ensayo,fe.correcto,fpi.simbolo,fpi.orden,fpi.especificacion_min,fpi.especificacion,fpi.especificacion_max,fe.id_protocolo_item,fi.unidad
                                        FROM formato_ensayo fe
                                        JOIN formato_protocolo_item fpi on fe.id_protocolo_item = fpi.id
                                        JOIN formato_item fi on fpi.id_item = fi.id
                                        WHERE fe.id_protocolo_item=@pIdProtocoloItem;";
                command.Parameters.Add("@pIdProtocoloItem", MySqlDbType.Int32).Value = idProtocoloItem;
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

            return pes;
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
                command.CommandText = @"SELECT fe.valor_ensayo FROM formato_ensayo fe where fe.id_protocolo_item=@pIdProtocoloItem;";
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
                            command.CommandText = @"INSERT INTO formato_protocolo_item (id_protocolo,id_item,orden,especificacion_min,especificacion,especificacion_max,simbolo) 
                                                                                VALUES (@pIdProtocolo,@pIdItem,@pOrden,@pEpecificacionMin,@pEspecificacion,@pEpecificacionMax,@pSimbolo)";
                            command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = pi.IdProtocolo;
                            command.Parameters.Add("@pIdItem", MySqlDbType.Int32).Value = pi.Id;
                            command.Parameters.Add("@pOrden", MySqlDbType.Int32).Value = pi.Orden;
                            command.Parameters.Add("@pEpecificacionMin", MySqlDbType.Double).Value = pi.EspecificacionMin;
                            command.Parameters.Add("@pEspecificacion", MySqlDbType.Double).Value = pi.Especificacion;
                            command.Parameters.Add("@pEpecificacionMax", MySqlDbType.Double).Value = pi.EspecificacionMax;
                            command.Parameters.Add("@pSimbolo", MySqlDbType.String).Value = pi.Simbolo;
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
        internal bool DeleteEnsayo(int idEnsayo)
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
                            command.CommandText = @"DELETE FROM formatoprotocoloa_ensayo WHERE (id = @pIdEnsayo);";
                            command.Parameters.Add("@pIdEnsayo", MySqlDbType.Int32).Value = idEnsayo;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al modificar TX");
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
        internal bool UpdateEnsayo(ProtocoloEnsayo pi)
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
                            command.CommandText = @"UPDATE formatoprotocoloa_ensayo SET valor_ensayo = @pValor,
                                                                                        correcto = @pCorrecto                                                                                      
                                                                                        WHERE id = (@pIdEnsayo);";
                            command.Parameters.Add("@pValor", MySqlDbType.Double).Value = pi.ValorEnsayo;
                            command.Parameters.Add("@pCorrecto", MySqlDbType.Int32).Value = pi.Correcto;
                            command.Parameters.Add("@pIdEnsayo", MySqlDbType.Int32).Value = pi.Id;

                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al modificar TX");
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

        internal List<ProtocoloItem> GetExtrusionItems(int idCodigo)
        {

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT ancho,ancho_min,ancho_max,fuelle,fuelle_min,fuelle_max,espesor,espesor_min,espesor_max 
                                        FROM extrusion
                                        WHERE idcodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //LO PASO A MILIMETROS UNIDAD = 2, LO MULTIPLICO POR 10
                        var simbolo = "±";
                        var espeficacionAncho = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0)*10;
                        var espeficacionAnchoMin = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        var espeficacionAnchoMax = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                        var especificacionAnchoDato = espeficacionAncho + simbolo + espeficacionAnchoMax;

                        var espeficacionFuelle = reader.IsDBNull(3) ? 0.0 : reader.GetDouble(3) * 10;
                        var espeficacionFuelleMin = reader.IsDBNull(4) ? 0.0 : reader.GetDouble(4);
                        var espeficacionFuelleMax = reader.IsDBNull(5) ? 0.0 : reader.GetDouble(5);
                        var especificacionFuelleDato = espeficacionFuelle + simbolo + espeficacionFuelleMax;

                        var espeficacionEspesor = reader.IsDBNull(6) ? 0.0 : reader.GetDouble(6) * 10;
                        var espeficacionEspesorMin = reader.IsDBNull(7) ? 0.0 : reader.GetDouble(7);
                        var espeficacionEspesorMax = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8);
                        var especificacionEspesorDato = espeficacionEspesor + simbolo + espeficacionEspesorMax;

                        List<ProtocoloItem> eds = new List<ProtocoloItem> {
                            new ProtocoloItem { Nombre ="Ancho Extrusión",Simbolo = "±", Medida="Milimetro",Especificacion = espeficacionAncho,EspecificacionMin = espeficacionAnchoMin,EspecificacionMax=espeficacionAnchoMax,EspecificacionDato=especificacionAnchoDato ,Seleccionar = false},
                            new ProtocoloItem { Nombre ="Fuelle Extrusión",Simbolo = "±",Medida="Milimetro",Especificacion=espeficacionFuelle,EspecificacionMin = espeficacionFuelleMin,EspecificacionMax=espeficacionFuelleMax,EspecificacionDato=especificacionFuelleDato,Seleccionar = false},
                            new ProtocoloItem { Nombre ="Espesor Extrusión",Simbolo = "±",Medida ="Micron",Especificacion=espeficacionEspesor,EspecificacionMin = espeficacionEspesorMin,EspecificacionMax=espeficacionEspesorMax,EspecificacionDato=especificacionEspesorDato,Seleccionar = false},

                        };

                        return eds;

                    }

                }

                return null;
            }
        }
        internal List<ProtocoloItem> GetImpresionItems(int idCodigo)
        {
            List<ProtocoloItem> itemsConfeccion = new List<ProtocoloItem>();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT ancho,ancho_min,ancho_max,fuelle,fuelle_min,fuelle_max,espesor,espesor_min,espesor_max
                                        FROM impresion 
                                        WHERE IdCodigo = @pIdCodigo";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var simbolo = "±";
                        var espeficacionAncho = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0) * 10;
                        var espeficacionAnchoMin = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        var espeficacionAnchoMax = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                        var especificacionAnchoDato = espeficacionAncho + simbolo + espeficacionAnchoMax;
               
                        //var espeficacionFuelle = reader.IsDBNull(3) ? 0.0 : reader.GetDouble(3) * 10;
                        //var espeficacionFuelleMin = reader.IsDBNull(4) ? 0.0 : reader.GetDouble(4);
                        //var espeficacionFuelleMax = reader.IsDBNull(5) ? 0.0 : reader.GetDouble(5);
                        //var especificacionFuelleDato = espeficacionFuelle + simbolo + espeficacionFuelleMax;

                        var espeficacionEspesor = reader.IsDBNull(6) ? 0.0 : reader.GetDouble(6);
                        var espeficacionEspesorMin = reader.IsDBNull(7) ? 0.0 : reader.GetDouble(7);
                        var espeficacionEspesorMax = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8);
                        var especificacionEspesorDato = espeficacionEspesor + simbolo + espeficacionEspesorMax;

                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Ancho impresión", Simbolo = "±", Medida = "Milimetro", Especificacion = espeficacionAncho, EspecificacionMin = espeficacionAnchoMin, EspecificacionMax = espeficacionAnchoMax, EspecificacionDato = especificacionAnchoDato, Seleccionar = false });
                        //itemsConfeccion.Add(new ProtocoloItem { Nombre = "Fuelle impresión", Simbolo = "±", Medida = "Milimetro", Especificacion = espeficacionFuelle, EspecificacionMin = espeficacionFuelleMin, EspecificacionMax = espeficacionFuelleMax, EspecificacionDato = especificacionFuelleDato, Seleccionar = false });
                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Espesor impresión", Simbolo = "±", Medida = "Micron", Especificacion = espeficacionEspesor, EspecificacionMin = espeficacionEspesorMin, EspecificacionMax = espeficacionEspesorMax, EspecificacionDato = especificacionEspesorDato, Seleccionar = false });

                    }

                }
                return itemsConfeccion;
            }
        }
        internal List<ProtocoloItem> GetConfeccionItems(int idCodigo)
        {
            List<ProtocoloItem> itemsConfeccion = new List<ProtocoloItem>();
            
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT ancho,ancho_min,ancho_max,largo,largo_min,largo_max,fuelle,fuelle_min,fuelle_max,espesor,espesor_min,espesor_max
                                        FROM confeccion 
                                        WHERE IdCodigo = @pIdCodigo";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var simbolo = "±";
                        var espeficacionAncho = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0) * 10;
                        var espeficacionAnchoMin = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        var espeficacionAnchoMax = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                        var especificacionAnchoDato = espeficacionAncho + simbolo + espeficacionAnchoMax;

                        var espeficacionLargo = reader.IsDBNull(3) ? 0.0 : reader.GetDouble(3) * 10;
                        var espeficacionLargoMin = reader.IsDBNull(4) ? 0.0 : reader.GetDouble(4);
                        var espeficacionLargoMax = reader.IsDBNull(5) ? 0.0 : reader.GetDouble(5);
                        var especificacionLargoDato = espeficacionLargo + simbolo + espeficacionLargoMax;

                        var espeficacionFuelle = reader.IsDBNull(6) ? 0.0 : reader.GetDouble(6) *10;
                        var espeficacionFuelleMin = reader.IsDBNull(7) ? 0.0 : reader.GetDouble(7);
                        var espeficacionFuelleMax = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8);
                        var especificacionFuelleDato = espeficacionFuelle + simbolo + espeficacionFuelleMax;

                        var espeficacionEspesor = reader.IsDBNull(9) ? 0.0 : reader.GetDouble(9);
                        var espeficacionEspesorMin = reader.IsDBNull(10) ? 0.0 : reader.GetDouble(10);
                        var espeficacionEspesorMax = reader.IsDBNull(11) ? 0.0 : reader.GetDouble(11);
                        var especificacionEspesorDato = espeficacionEspesor + simbolo + espeficacionEspesorMax;

                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Ancho de bolsa", Simbolo = "±", Medida = "Milimetro", Especificacion = espeficacionAncho, EspecificacionMin = espeficacionAnchoMin, EspecificacionMax = espeficacionAnchoMax, EspecificacionDato = especificacionAnchoDato, Seleccionar = false });
                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Largo de bolsa", Simbolo = "±", Medida = "Milimetro", Especificacion = espeficacionLargo, EspecificacionMin = espeficacionLargoMin, EspecificacionMax = espeficacionLargoMax, EspecificacionDato = especificacionLargoDato, Seleccionar = false });
                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Fuelle Confección", Simbolo = "±", Medida = "Milimetro", Especificacion = espeficacionFuelle, EspecificacionMin = espeficacionFuelleMin, EspecificacionMax = espeficacionFuelleMax, EspecificacionDato = especificacionFuelleDato, Seleccionar = false });
                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Espesor Confección", Simbolo = "±", Medida = "Micron", Especificacion = espeficacionEspesor, EspecificacionMin = espeficacionEspesorMin, EspecificacionMax = espeficacionEspesorMax, EspecificacionDato = especificacionEspesorDato, Seleccionar = false });
            
                    }

                }
                command.CommandText = @"SELECT largo_solapa,largo_solapat,fuelle,fuellet,ancho_bobina,ancho_bobinat,DistanciaAlOrificioWicket,DistanciaAlOrificioWicketT,DistanciaEntreOrificioWicket,DistanciaEntreOrificioWicketT,LargoCorteSoft,LargoCorteSoftT
                                        FROM confeccion_wicketera 
                                        WHERE IdCodigo = @pIdCodigo";
                using (var reader = command.ExecuteReader())
                {               
                    if (reader.Read())
                    {
                        var simbolo = "±";
                        var especificacionSolapaWick = reader.IsDBNull(0) ? 0.0 : reader.GetInt32(0);
                        var especificacionSolapaWickMax = reader.IsDBNull(1) ? 0.0 : reader.GetInt32(1);
                        var especificacionSolapaWickDato = especificacionSolapaWick + simbolo + especificacionSolapaWickMax;

                        var especificacionFuelleWick = reader.IsDBNull(2) ? 0.0 : reader.GetInt32(2);
                        var especificacionFuelleWickMax = reader.IsDBNull(3) ? 0.0 : reader.GetInt32(3);
                        var especificacionFuelleWickDato = especificacionFuelleWick + simbolo + especificacionFuelleWickMax;

                        var especificacionAnchoBobinaWick = reader.IsDBNull(4) ? 0.0 : reader.GetInt32(4);
                        var especificacionAnchoBobinaWickMax = reader.IsDBNull(5) ? 0.0 : reader.GetInt32(5);
                        var especificacionAnchoBobinaWickDato = especificacionAnchoBobinaWick + simbolo + especificacionAnchoBobinaWickMax;
                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Largo solapa wicket", Simbolo = "±", Medida = "Milimetro", Especificacion = especificacionSolapaWick, EspecificacionMax = especificacionSolapaWickMax, EspecificacionDato = especificacionSolapaWickDato, Seleccionar = false });
                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Fuelle wicket", Simbolo = "±", Medida = "Milimetro", Especificacion = especificacionFuelleWick, EspecificacionMax = especificacionFuelleWickMax, EspecificacionDato = especificacionFuelleWickDato, Seleccionar = false });
                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Ancho bobina wicket", Simbolo = "±", Medida = "Milimetro", Especificacion = especificacionAnchoBobinaWick, EspecificacionMax = especificacionAnchoBobinaWickMax, EspecificacionDato = especificacionAnchoBobinaWickDato, Seleccionar = false });
                    }
                }
                return itemsConfeccion;
            }
        }
    }
}
