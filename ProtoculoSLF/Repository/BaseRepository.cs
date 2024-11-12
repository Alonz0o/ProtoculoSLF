using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using MySqlConnector;
using ProtoculoSLF.Model;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using System.Windows.Forms;
using DevExpress.PivotGrid.OLAP.Mdx;

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
                    command.CommandText = "SELECT id,id_nt_log,valor_log,correcto_log,accion_creada FROM formato_ensayo_log WHERE accion_creada >= NOW() - INTERVAL 5 SECOND;";
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

        internal List<Protocolo> GetProtocolos()
        {
            List<Protocolo> protocolos = new List<Protocolo>();
            List<ProtocoloItem> pis = new List<ProtocoloItem>();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT e.IdCodigo,e.id_formato_protocolo,e.fecha_modificacion,fp.nombre,e.Numero_Art_Cliente,fp.disposicion,fl.Razon_Social 
                                        FROM extrusion e 
                                        JOIN formato_protocolo fp ON e.id_formato_protocolo=fp.id
                                        JOIN ficha_logistica fl ON e.NumeroCliente = fl.Num_Cliente
                                        WHERE e.id_formato_protocolo IS NOT NULL;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Protocolo p = new Protocolo
                        {
                            Id = reader[0] != DBNull.Value ? Convert.ToInt32(reader.GetDouble(0)) : 0,
                            FormatoProtocolo = reader[1] != DBNull.Value ? reader.GetInt32(1) : 0,
                            Fecha = reader[2] != DBNull.Value ? reader.GetDateTime(2) : new DateTime(1993, 1, 20),
                            Nombre = reader[3] != DBNull.Value ? reader.GetString(3) : "",
                            CodigoCliente = reader[4] != DBNull.Value ? reader.GetString(4) : "",
                            Disposicion = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                            Cliente = reader[6] != DBNull.Value ? reader.GetString(6) : "",
                        };
                        protocolos.Add(p);
                    }
                }

               return protocolos;
            }
        }

        internal List<ProtocoloItem> GetItemsDelProtocoloNUEVO(int idProtocolo)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fpi.id,fi.nombre,fi.unidad,fi.certifica,fi.simbolo,fi.id
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_item fi ON fpi.id_item = fi.id
                                        WHERE fpi.id_protocolo = @pIdProtocolo;";
                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                            IdProtocoloItem = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Medida = reader.IsDBNull(2) ? "Constante" : reader.GetString(2),
                            EsCertificado = esCertificado,
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
                            Simbolo = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal List<ProtocoloItem> GetItems()
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fi.id,fi.nombre,fi.unidad,fi.certifica,fi.simbolo
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
                            Medida = reader.IsDBNull(2) ? "Constante" : reader.GetString(2),
                            EsCertificado = esCertificado,
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
                            Simbolo = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal List<ProtocoloItem> GetProtocolosItemsEspecificacionPorCodigo(int idCodigo)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fi.id,fi.nombre,fi.unidad,fi.certifica,fpi.orden,fpie.especificacion,fpie.especificacion_min,fpie.especificacion_max,fi.simbolo,fpi.id
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_protocolo_item_especificacion fpie on fpi.id = fpie.id_formato_protocolo_item
                                        JOIN formato_item fi on fpi.id_item = fi.id
                                        WHERE fpie.id_codigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        var simbolo = reader[8] != DBNull.Value ? reader.GetString(8) : "";
                        var espeficacion = reader[5] != DBNull.Value ? reader.GetDouble(5) : 0.0;
                        var espeficacionMin = reader[6] != DBNull.Value ? reader.GetDouble(6) : 0.0;
                        var espeficacionMax = reader[7] != DBNull.Value ? reader.GetDouble(7) : 0.0;
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Nombre = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Medida = reader[2] != DBNull.Value ? reader.GetString(2) : "",
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
                            Orden = reader[4] != DBNull.Value ? reader.GetInt32(4) : 0,
                            Simbolo = simbolo,
                            EspecificacionMin = espeficacionMin,
                            Especificacion = espeficacion,
                            EspecificacionMax = espeficacionMax,
                            EspecificacionDato = simbolo == "-" ? espeficacionMin + " - " + espeficacionMax : simbolo == "N" ? "VALIDA" : espeficacion + " " + simbolo + " " + espeficacionMax,
                            IdProtocoloItem = reader[9] != DBNull.Value ? reader.GetInt32(9) : 0,

                        };
                        pis.Add(pi);
                    }
                }
            }

            return pis;

        }
        internal List<ProtocoloItem> GetProtocolosItems(int idProtocolo)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fi.id,fi.nombre,fi.unidad,fi.certifica,fpi.orden,fpi.id
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_item fi on fpi.id_item = fi.id
                                        WHERE fpi.id_protocolo = @pIdProtocolo;";
                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Nombre = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Medida = reader[2] != DBNull.Value ? reader.GetString(2) : "",
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
                            Orden = reader[4] != DBNull.Value ? reader.GetInt32(4) : 0,
                            IdProtocoloItem = reader[5] != DBNull.Value ? reader.GetInt32(5) : 0,
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
        internal List<NT> GetNTsPorLote(int idCodigo)
        {
            List<NT> nts = new List<NT>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT o_p,count(nt),sum(pallets),sum(cant_bobinas)
                                        FROM nt 
                                        WHERE codigo=@pIdCodigo
                                        GROUP BY o_p;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NT n = new NT
                        {
                            OP = reader.IsDBNull(0) ? "" : reader.GetString(0),
                            NumNT = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                            NumPallet = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            CantidadBobinas = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        };
                        nts.Add(n);
                    }
                }
            }
            return nts;
        }

        internal List<ProtocoloEnsayo> GetEnsayosPorLote(string op)
        {
            ProtocoloItem p = new ProtocoloItem();
            List<ProtocoloEnsayo> pes = new List<ProtocoloEnsayo>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {

                conexion.Open();
                command.Connection = conexion;

                command.CommandText = $@"SELECT fi.nombre,fi.simbolo,fpi.orden,fpie.especificacion,fpie.especificacion_min,fpie.especificacion_max,fpi.id,fi.unidad,fe.valor_ensayo
                                        FROM formato_ensayo fe
                                        JOIN formato_protocolo_item fpi ON fe.id_protocolo_item = fpi.id
                                        JOIN formato_protocolo_item_especificacion fpie on fpi.id = fpie.id_formato_protocolo_item                           
                                        JOIN formato_item fi on fpi.id_item = fi.id
                                        WHERE fe.op = @pOp";
                command.Parameters.Add("@pOp", MySqlDbType.String).Value = op;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var valorEnsayo = reader[8] != DBNull.Value ? reader.GetDouble(8) : 0.0;
                        ProtocoloEnsayo pe = new ProtocoloEnsayo
                        {
                            Nombre = reader[0] != DBNull.Value ? reader.GetString(0) : "",
                            Simbolo = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Orden = reader[2] != DBNull.Value ? reader.GetInt32(2) : 0,
                            Especificacion = reader[3] != DBNull.Value ? reader.GetDouble(3) : 0.0,
                            EspecificacionMin = reader[4] != DBNull.Value ? reader.GetDouble(4) : 0.0,
                            EspecificacionMax = reader[5] != DBNull.Value ? reader.GetDouble(5) : 0.0,
                            IdProtocoloItem = reader[6] != DBNull.Value ? reader.GetInt32(6) : 0,
                            Unidad = reader[7] != DBNull.Value ? reader.GetString(7) : "",
                            ValorEnsayo = valorEnsayo.ToString(),

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
                    ValorEnsayo = grupo.FirstOrDefault().Simbolo == "N" ? grupo.FirstOrDefault().ValorEnsayo : grupo.Where(pr => double.TryParse(pr.ValorEnsayo, out _))
                                                                                       .Select(pr => double.Parse(pr.ValorEnsayo))
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

        internal List<ProtocoloEnsayo> GetEnsayosItemsAnchoBolsa(string nombreItem, int orden, int codigo)
        {
            ProtocoloItem p = new ProtocoloItem();
            List<ProtocoloEnsayo> pes = new List<ProtocoloEnsayo>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {

                conexion.Open();
                command.Connection = conexion;

                command.CommandText = @"SELECT fi.nombre,fi.simbolo,fpi.orden,fpie.especificacion_min,fpie.especificacion,fpie.especificacion_max,fpi.id,fi.unidad
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_protocolo_item_especificacion fpie on fpi.id = fpie.id_formato_protocolo_item
                                        JOIN formato_item fi on fpi.id_item = fi.id
                                        WHERE fpie.id_codigo = @pIdCodigo and fi.nombre = @pNombreItem";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = codigo;
                command.Parameters.Add("@pNombreItem", MySqlDbType.String).Value = nombreItem;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p.Nombre = reader[0] != DBNull.Value ? reader.GetString(0) : "";
                        var simbolo = reader[1] != DBNull.Value ? reader.GetString(1) : "";
                        p.Simbolo = simbolo;
                        p.Orden = reader[2] != DBNull.Value ? reader.GetInt32(2) : 0;
                        p.EspecificacionMin = reader[3] != DBNull.Value ? reader.GetDouble(3) : 0.0;
                        p.Especificacion = reader[4] != DBNull.Value ? reader.GetDouble(4) : 0.0;
                        p.EspecificacionMax = reader[5] != DBNull.Value ? reader.GetDouble(5) : 0.0;
                        p.IdProtocoloItem = reader[6] != DBNull.Value ? reader.GetInt32(6) : 0;
                        p.Medida = reader[7] != DBNull.Value ? reader.GetString(7) : "";
                    }
                }
                command.CommandText = @"SELECT Ancho,Peso_Metro,Orden,Codigo
                                        FROM parametros_anchos
                                        WHERE orden=@pIdOrden and Codigo=@pIdCodigo and orden <> -1;";
                command.Parameters.Add("@pIdOrden", MySqlDbType.Int32).Value = orden;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var valorEnsayo = reader[0] != DBNull.Value ? reader.GetDouble(0) : 0.0;
                        ProtocoloEnsayo pe = new ProtocoloEnsayo
                        {
                            Nombre = p.Nombre,
                            Simbolo = p.Simbolo,
                            ValorEnsayo = valorEnsayo.ToString(),
                            Orden = p.Orden,
                            EspecificacionMin = p.EspecificacionMin,
                            Especificacion = p.Especificacion,
                            EspecificacionMax = p.EspecificacionMax,
                            IdProtocoloItem = p.IdProtocoloItem,
                            Unidad = p.Medida,
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
                    ValorEnsayo = grupo.FirstOrDefault().Simbolo == "N" ? grupo.FirstOrDefault().ValorEnsayo : grupo.Where(pr => double.TryParse(pr.ValorEnsayo, out _))
                                                                                       .Select(pr => double.Parse(pr.ValorEnsayo))
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
                command.CommandText = @"SELECT fe.id,fi.nombre,fe.valor_ensayo,fe.correcto,fi.simbolo,fpi.orden,fpi.especificacion_min,fpi.especificacion,fpi.especificacion_max,fe.id_protocolo_item,fi.unidad
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
                command.CommandText = @"SELECT id,nombre,observacion,disposicion,creacion
                                        FROM formato_protocolo;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Protocolo p = new Protocolo
                        {
                            FormatoProtocolo = reader[0] != DBNull.Value ? reader.GetInt32(0) : 0,
                            Nombre = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Descripcion = reader[2] != DBNull.Value ? reader.GetString(2) : "",
                            Disposicion = reader[3] != DBNull.Value ? reader.GetInt32(3) : 0,
                            Fecha = reader[4] != DBNull.Value ? reader.GetDateTime(4) : new DateTime(1993, 1, 20),

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
                                            FROM formato_protocolo_item fpi
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

        internal bool AgregarItem(ProtocoloItem pi)
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
                            command.CommandText = @"INSERT INTO formato_item (nombre,unidad,usuario,certifica,constante,simbolo,proceso) 
                                                                      VALUES (@pNombre,@pUnidad,@pUsuario,@pCertifica,@pConstante,@pSimbolo,@pProceso); SELECT LAST_INSERT_ID();";
                            command.Parameters.Add("@pNombre", MySqlDbType.String).Value = pi.Nombre;
                            command.Parameters.Add("@pUnidad", MySqlDbType.String).Value = pi.Medida;
                            command.Parameters.Add("@pUsuario", MySqlDbType.String).Value = "ALON";
                            command.Parameters.Add("@pCertifica", MySqlDbType.Int32).Value = pi.EsCertificado;
                            command.Parameters.Add("@pConstante", MySqlDbType.Int32).Value = pi.EsConstante;
                            command.Parameters.Add("@pSimbolo", MySqlDbType.String).Value = pi.Simbolo;
                            command.Parameters.Add("@pProceso", MySqlDbType.String).Value = pi.Proceso;

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
        internal int AgregarItemFOREACHBORRAR(ProtocoloItem pi)
        {
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
                            command.CommandText = @"INSERT INTO formato_item (nombre,unidad,usuario,certifica,constante,simbolo) 
                                                                      VALUES (@pNombre,@pUnidad,@pUsuario,@pCertifica,@pConstante,@pSimbolo); SELECT LAST_INSERT_ID();";
                            command.Parameters.Add("@pNombre", MySqlDbType.String).Value = pi.Nombre;
                            command.Parameters.Add("@pUnidad", MySqlDbType.String).Value = pi.Medida;
                            command.Parameters.Add("@pUsuario", MySqlDbType.String).Value = "ALON";
                            command.Parameters.Add("@pCertifica", MySqlDbType.Int32).Value = pi.EsCertificado;
                            command.Parameters.Add("@pConstante", MySqlDbType.Int32).Value = pi.EsConstante;
                            command.Parameters.Add("@pSimbolo", MySqlDbType.String).Value = pi.Simbolo;

                            pi.Id = Convert.ToInt32(command.ExecuteScalar());

                            if (pi.Id == -1 || pi.Id == 0)
                            {
                                throw new Exception("Error al insertar itemProtocolo");
                            }

                            transaction.Commit();
                            return pi.Id;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return 0;
                        }
                    }
                }
            }
        }
        internal bool AgregarItemProtocolo(ProtocoloItem pi, int idCodigo)
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
                            if (pi.IdProtocoloItem == 0)
                            {
                                command.CommandText = @"INSERT INTO formato_protocolo_item (id_protocolo,id_item,orden) 
                                                                                VALUES (@pIdProtocolo,@pIdItem,@pOrden); SELECT LAST_INSERT_ID();";
                                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = pi.IdProtocolo;
                                command.Parameters.Add("@pIdItem", MySqlDbType.Int32).Value = pi.Id;
                                command.Parameters.Add("@pOrden", MySqlDbType.Int32).Value = pi.Orden;

                                pi.IdProtocoloItem = Convert.ToInt32(command.ExecuteScalar());
                            }

                            if (pi.IdProtocoloItem == -1 || pi.IdProtocoloItem == 0)
                            {
                                throw new Exception("Error al insertar itemProtocolo");
                            }

                            command.CommandText = @"INSERT INTO formato_protocolo_item_especificacion (id_codigo,id_formato_protocolo_item,especificacion,especificacion_min,especificacion_max) 
                                                                                               VALUES (@pIdCodigo,@pIdProtocoloItem,@pEspecificacion,@pEpecificacionMin,@pEpecificacionMax);";
                            command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                            command.Parameters.Add("@pIdProtocoloItem", MySqlDbType.Int32).Value = pi.IdProtocoloItem;
                            command.Parameters.Add("@pEpecificacionMin", MySqlDbType.Double).Value = pi.EspecificacionMin;
                            command.Parameters.Add("@pEspecificacion", MySqlDbType.Double).Value = pi.Especificacion;
                            command.Parameters.Add("@pEpecificacionMax", MySqlDbType.Double).Value = pi.EspecificacionMax;
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
                        var espeficacionAncho = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0) * 10;
                        var espeficacionAnchoMin = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        var espeficacionAnchoMax = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                        var especificacionAnchoDato = espeficacionAncho + simbolo + espeficacionAnchoMax;

                        var espeficacionFuelle = reader.IsDBNull(3) ? 0.0 : reader.GetDouble(3) * 10;
                        var espeficacionFuelleMin = reader.IsDBNull(4) ? 0.0 : reader.GetDouble(4);
                        var espeficacionFuelleMax = reader.IsDBNull(5) ? 0.0 : reader.GetDouble(5);
                        var especificacionFuelleDato = espeficacionFuelle + simbolo + espeficacionFuelleMax;

                        var espeficacionEspesor = reader.IsDBNull(6) ? 0.0 : reader.GetDouble(6);
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
                                        WHERE idcodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Double).Value = idCodigo;
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

                        //var espeficacionFuelle = reader.IsDBNull(6) ? 0.0 : reader.GetDouble(6) *10;
                        //var espeficacionFuelleMin = reader.IsDBNull(7) ? 0.0 : reader.GetDouble(7);
                        //var espeficacionFuelleMax = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8);
                        //var especificacionFuelleDato = espeficacionFuelle + simbolo + espeficacionFuelleMax;

                        var espeficacionEspesor = reader.IsDBNull(9) ? 0.0 : reader.GetDouble(9);
                        var espeficacionEspesorMin = reader.IsDBNull(10) ? 0.0 : reader.GetDouble(10);
                        var espeficacionEspesorMax = reader.IsDBNull(11) ? 0.0 : reader.GetDouble(11);
                        var especificacionEspesorDato = espeficacionEspesor + simbolo + espeficacionEspesorMax;

                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Ancho de bolsa", Simbolo = "±", Medida = "Milimetro", Especificacion = espeficacionAncho, EspecificacionMin = espeficacionAnchoMin, EspecificacionMax = espeficacionAnchoMax, EspecificacionDato = especificacionAnchoDato, Seleccionar = false });
                        itemsConfeccion.Add(new ProtocoloItem { Nombre = "Largo de bolsa", Simbolo = "±", Medida = "Milimetro", Especificacion = espeficacionLargo, EspecificacionMin = espeficacionLargoMin, EspecificacionMax = espeficacionLargoMax, EspecificacionDato = especificacionLargoDato, Seleccionar = false });
                        //itemsConfeccion.Add(new ProtocoloItem { Nombre = "Fuelle Confección", Simbolo = "±", Medida = "Milimetro", Especificacion = espeficacionFuelle, EspecificacionMin = espeficacionFuelleMin, EspecificacionMax = espeficacionFuelleMax, EspecificacionDato = especificacionFuelleDato, Seleccionar = false });
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

        internal int GetTotalDeItemsPorProtocolo(int idCodigo)
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var command = conexion.CreateCommand())
                {
                    command.CommandText = @"SELECT count(id) FROM formato_protocolo_item_especificacion where id_codigo = @pIdCodigo";
                    command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                    return command.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(command.ExecuteScalar()) : 0;
                }
            }
        }
        internal int GetTotalDeItemsPorIdCodigo(int idCodigo)
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var command = conexion.CreateCommand())
                {
                    command.CommandText = @"SELECT count(id) FROM formato_protocolo_item_especificacion WHERE id_codigo = @pIdCodigo";
                    command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                    return command.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(command.ExecuteScalar()) : 0;
                }
            }
        }
        internal int GetTotalDeItemsProtocolo(int idProtocolo)
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var command = conexion.CreateCommand())
                {
                    command.CommandText = @"SELECT count(id) FROM formato_protocolo_item WHERE id_protocolo = @pIdProtocolo";
                    command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                    return command.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(command.ExecuteScalar()) : 0;
                }
            }
        }

        internal int GetFormatoProtocoloItemId(int idProtocolo, int idItem)
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var command = conexion.CreateCommand())
                {
                    command.CommandText = @"SELECT id FROM formato_protocolo_item WHERE id_protocolo = @pIdProtocolo and id_item = @pIdItem;";
                    command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                    command.Parameters.Add("@pIdItem", MySqlDbType.Int32).Value = idItem;
                    return command.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(command.ExecuteScalar()) : 0;
                }
            }
        }

        internal int GetIdProtocoloItemPorNombre(string nombre)
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var command = conexion.CreateCommand())
                {
                    command.CommandText = @"SELECT fpi.id
                                            FROM formato_protocolo_item fpi
                                            JOIN formato_item fi on fpi.id_item = fi.id
                                            WHERE fi.nombre = @pItemNombre;";
                    command.Parameters.Add("@pItemNombre", MySqlDbType.Int32).Value = nombre;
                    return command.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(command.ExecuteScalar()) : 0;
                }
            }
        }

        internal bool UpdateDisposicionProtocolo(int disposicion, int formatoProtocolo)
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
                            command.CommandText = @"UPDATE formato_protocolo SET disposicion = @pDisposicion                                                                                    
                                                                                    WHERE id = @pIdProtocolo;";
                            command.Parameters.Add("@pDisposicion", MySqlDbType.Int32).Value = disposicion;
                            command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = formatoProtocolo;

                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al modificar protocolo");
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

        internal List<string> GetItemsDelProtocolo(int idProtocoloSeleccionado)
        {
            List<string> items = new List<string>();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fi.nombre
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_item fi on fpi.id_item = fi.id
                                        WHERE fpi.id_protocolo = @pIdProtocolo";
                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocoloSeleccionado;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(reader.IsDBNull(0) ? "" : reader.GetString(0));
                    }

                }
                return items;
            }
        }

        internal int EstaEnItemEspecificado(int idCodigo, string item)
        {
            int totalItems = 0;
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT COUNT(fi.nombre)
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_protocolo_item_especificacion fpie on fpi.id = fpie.id_formato_protocolo_item
                                        JOIN formato_item fi on fpi.id_item = fi.id
                                        WHERE fpie.id_codigo = @pIdCodigo and fi.nombre = @pItemNombre;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                command.Parameters.Add("@pItemNombre", MySqlDbType.String).Value = item;

                totalItems = Convert.ToInt32(command.ExecuteScalar());
            }
            return totalItems;
        }

        internal ExtrusionDatos GetDatosCodigo(string idCodigo)
        {
            ExtrusionDatos ed = new ExtrusionDatos();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT e.IdCodigo,e.NumeroCliente,fl.Razon_Social 
                                        FROM extrusion e 
                                        JOIN ficha_logistica fl on e.NumeroCliente = fl.Num_Cliente
                                        WHERE e.IdCodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ed.Nombre = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    }

                }
                return ed;
            }
        }

        internal int GetUltimoProtocolo()
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var command = conexion.CreateCommand())
                {
                    command.CommandText = @"SELECT MAX(id) FROM formato_protocolo;";
                    return command.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(command.ExecuteScalar()) : 0;
                }
            }
        }
        internal List<Protocolo> GetClientesSinProtocolo()
        {
            List<Protocolo> ps = new List<Protocolo>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT e.IdCodigo,fl.Razon_Social 
                                        FROM extrusion e 
                                        LEFT JOIN formato_protocolo fp ON e.formato_protocol=fp.id
                                        LEFT JOIN ficha_logistica fl ON e.NumeroCliente = fl.Num_Cliente
                                        WHERE e.id_formato_protocolo IS NULL;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Protocolo p = new Protocolo
                        {
                            Id = reader[0] != DBNull.Value ? Convert.ToInt32(reader.GetDouble(0)) : 0,
                            Descripcion = reader[1] != DBNull.Value ? reader.GetString(1) : "",
                            Seleccionar = false,
                        };
                        ps.Add(p);
                    }
                }

                return ps;
            }
        }

        internal bool InsertAProtocolo(Protocolo protocoloACrear, string qryUpdate, string qryInsertProtocoloItems,string accion)
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
                            if (accion == "modificar")
                            {
                                command.CommandText = @"UPDATE formato_protocolo SET nombre = @pNombre,
                                                                                     estado = @pEstado,
                                                                                     observacion = @pObservacion,
                                                                                     usuario = @pUsuario,
                                                                                     disposicion = @pDisposicion
                                                                                     WHERE id = (@pIdProtocolo); SELECT LAST_INSERT_ID();";
                            }
                            else {
                                command.CommandText = @"INSERT INTO formato_protocolo (nombre,estado,observacion,usuario,disposicion) 
                                                                           VALUES (@pNombre,@pEstado,@pObservacion,@pUsuario,@pDisposicion); SELECT LAST_INSERT_ID();";
                               
                            }
                            command.Parameters.Add("@pNombre", MySqlDbType.String).Value = protocoloACrear.Nombre;
                            command.Parameters.Add("@pEstado", MySqlDbType.Int32).Value = 1;
                            command.Parameters.Add("@pUsuario", MySqlDbType.String).Value = "ADMIN";
                            command.Parameters.Add("@pObservacion", MySqlDbType.String).Value = protocoloACrear.Descripcion;
                            command.Parameters.Add("@pDisposicion", MySqlDbType.Int32).Value = protocoloACrear.Disposicion;
                            command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = protocoloACrear.FormatoProtocolo;

                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al insertar itemProtocolo");
                            }                         
                            if (qryUpdate != "NO")
                            {
                                command.CommandText = qryUpdate;
                                if (command.ExecuteNonQuery() <= 0)
                                {
                                    throw new Exception("Error al actualizar SCRAPS");
                                }
                            }
                            if (qryInsertProtocoloItems != "NO")
                            {
                                command.CommandText = qryInsertProtocoloItems;
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

        internal Especificacion GetFichaLogisticaConfeccionAncho(int idCodigo)
        {
            Especificacion esp = new Especificacion();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT ancho,ancho_min,ancho_max
                                        FROM confeccion 
                                        WHERE idcodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Double).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        esp.Medio = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0) * 10;
                        esp.Minimo = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        esp.Maximo = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                    }

                }

                return esp;
            }
        }
        internal Especificacion GetFichaLogisticaConfeccionLargo(int idCodigo)
        {
            Especificacion esp = new Especificacion();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT largo,largo_min,largo_max
                                        FROM confeccion 
                                        WHERE idcodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Double).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        esp.Medio = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0) * 10;
                        esp.Minimo = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        esp.Maximo = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                    }

                }

                return esp;
            }
        }

        internal Especificacion GetFichaLogisticaConfeccionEspesor(int idCodigo)
        {
            Especificacion esp = new Especificacion();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT espesor,espesor_min,espesor_max
                                        FROM confeccion 
                                        WHERE idcodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Double).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        esp.Medio = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0) * 10;
                        esp.Minimo = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        esp.Maximo = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                    }

                }

                return esp;
            }
        }

        internal bool QuitarProtocoloACodigo(int idCodigo)
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
                            command.CommandText = @"UPDATE extrusion SET id_formato_protocolo = NULL                                                                                    
                                                                                     WHERE IdCodigo = @pIdCodigo;";
                            command.Parameters.Add("@pIdCodigo", MySqlDbType.Double).Value = idCodigo;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al modificar protocolo");
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
