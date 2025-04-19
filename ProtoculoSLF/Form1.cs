using DevExpress.XtraGrid.Views.Grid;
using ProtoculoSLF.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.Data;
using ProtoculoSLF.Model;
using DevExpress.Utils;
using ProtoculoSLF.Report;
using System.IO;
using IniParser.Model;
using IniParser;
using DevExpress.XtraReports.UI;
using System.Diagnostics;

namespace ProtoculoSLF
{
    public partial class Form1 : Form
    {
        public BaseRepository br = new BaseRepository();
        public List<Protocolo> protocolos = new List<Protocolo>();
        public List<ProtocoloItem> protocoItems = new List<ProtocoloItem>();
        public List<NT> nts = new List<NT>();
        public List<ProtocoloEnsayo> protocoloEnsayos = new List<ProtocoloEnsayo>();
        public ReporteDatos datosReporte = new ReporteDatos();
        public Protocolo protocoloSeleccionado = new Protocolo();
        public static Form1 instancia;
        public bool esPorLote;
        string archivoINI = Directory.GetCurrentDirectory() + @"\config.ini";
        string protocoloINI = "";

        private List<ProtocoloItem> items = new List<ProtocoloItem>();
        public bool EsCanceladoFormAsignarItemAProtocolo = false, EsConProtocolo = false;

        private async Task GetEnsayosTask()
        {
            while (true)
            {
                if (br.GetCambios() > 0)
                {
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se agrego un ensayo.");
                    noti.Show();
                    //GetEnsayosRealizados();
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public Form1()
        {
            InitializeComponent();
            GenerarTablaProtocolos();
            GenerarTablaProtocolosItem();
            GenerarTablaItemsValor();
            GenerarTablaEnsayos();

            if (!File.Exists(archivoINI)) File.Create(archivoINI).Close();

            LeerConfigSplitter();
            instancia = this;

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // BOTON PROTOCOLO
            ToolStripMenuItem itemAgregarProtocolo = new ToolStripMenuItem("Asistente de protocolo");
            itemAgregarProtocolo.Size = btnAgregarProtocolo.Size;
            itemAgregarProtocolo.Click += AgregarProtocolo_Click;
            contextMenu.Items.Add(itemAgregarProtocolo);

            ToolStripMenuItem itemModificarProtocolo = new ToolStripMenuItem("Modificar protocolo");
            itemModificarProtocolo.Click += ModificarProtocolo_Click;
            contextMenu.Items.Add(itemModificarProtocolo);

            btnAgregarProtocolo.ContextMenuStrip = contextMenu;
            btnAgregarProtocolo.Click += (s, e) =>
            {
                contextMenu.Show(btnAgregarProtocolo, new Point(0, btnAgregarProtocolo.Height));
            };

          
        }

        private void AgregarProtocolo_Click(object sender, EventArgs e)
        {
            formAgregarProtocolo form = new formAgregarProtocolo("agregar");
            form.Size = panel7.Size;
            Point locationOnScreen = panel7.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X, locationOnScreen.Y);
            form.Show();
        }

        private void ModificarProtocolo_Click(object sender, EventArgs e)
        {
            formAgregarProtocolo form = new formAgregarProtocolo("modificar");
            form.Size = panel7.Size;
            Point locationOnScreen = panel7.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X, locationOnScreen.Y);
            form.Show();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await GetEnsayosTask();
        }
        private void GenerarTablaItemsValor()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cNombre = new GridColumn();
            cNombre.FieldName = "Nombre";
            cNombre.Caption = "Nombre";
            cNombre.UnboundDataType = typeof(string);
            cNombre.Visible = true;
            cNombre.OptionsColumn.AllowEdit = false;

            GridColumn cMedida = new GridColumn();
            cMedida.FieldName = "Medida";
            cMedida.Caption = "Medida";
            cMedida.UnboundDataType = typeof(string);
            cMedida.Visible = true;
            cMedida.OptionsColumn.AllowEdit = false;

            GridColumn cValor = new GridColumn();
            cValor.FieldName = "Valor";
            cValor.Caption = "Valor";
            cValor.Visible = true;
            cValor.UnboundDataType = typeof(string);

            GridColumn cEspecificacion = new GridColumn();
            cEspecificacion.FieldName = "EspecificacionDato";
            cEspecificacion.Caption = "Especificación";
            cEspecificacion.Visible = true;
            cEspecificacion.UnboundDataType = typeof(string);
            cEspecificacion.OptionsColumn.AllowEdit = false;

            gvItemsValor.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cValor, cEspecificacion });
        }
        private void GenerarTablaProtocolos()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "Codigo";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;
            cId.Visible = true;

            GridColumn cUltimoProceso = new GridColumn();
            cUltimoProceso.FieldName = "UltimoProcesoNombre";
            cUltimoProceso.Caption = "Proceso";
            cUltimoProceso.UnboundDataType = typeof(string);
            cUltimoProceso.OptionsColumn.AllowEdit = false;
            cUltimoProceso.Visible = true;

            GridColumn cIdFormato = new GridColumn();
            cIdFormato.FieldName = "FormatoProtocolo";
            cIdFormato.Caption = "Protocolo N°";
            cIdFormato.UnboundDataType = typeof(int);
            cIdFormato.Visible = true;
            cIdFormato.OptionsColumn.AllowEdit = false;

            GridColumn cFecha = new GridColumn();
            cFecha.FieldName = "Fecha";
            cFecha.Caption = "Creado";
            cFecha.UnboundDataType = typeof(DateTime);
            cFecha.Visible = true;
            cFecha.OptionsColumn.AllowEdit = false;

            GridColumn cNombre = new GridColumn();
            cNombre.FieldName = "Nombre";
            cNombre.Caption = "Nombre";
            cNombre.UnboundDataType = typeof(string);
            cNombre.Visible = true;
            cNombre.OptionsColumn.AllowEdit = false;

            GridColumn cCliente = new GridColumn();
            cCliente.FieldName = "Cliente";
            cCliente.Caption = "Cliente";
            cCliente.Visible = true;

            GridColumn cVerProtocolo = new GridColumn();
            cVerProtocolo.FieldName = "FNVerProtocolo";
            cVerProtocolo.Caption = " ";
            cVerProtocolo.Width = 16;
            cVerProtocolo.Visible = true;

            gvProtocolos.Columns.AddRange(new GridColumn[] { cId, cUltimoProceso,cIdFormato, cFecha, cNombre, cCliente, cVerProtocolo });
            gcProtocolos.DataSource = protocolos.OrderByDescending(e => e.Fecha);

            cCliente.GroupIndex = 0;
            cUltimoProceso.GroupIndex = 1;
            cFecha.SortOrder = ColumnSortOrder.Descending;

            gvProtocolos.OptionsView.ShowGroupPanel = false;
            gvProtocolos.OptionsBehavior.AutoExpandAllGroups = true;

            RepositoryItemButtonEdit botonVer = new RepositoryItemButtonEdit();
            botonVer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonVer.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonVer.Buttons[0].Image = Properties.Resources.show_16x16;
            gcProtocolos.RepositoryItems.Add(botonVer);
            gvProtocolos.Columns["FNVerProtocolo"].ColumnEdit = botonVer;

            botonVer.ButtonClick += (sender, e) =>
            {
                datosReporte.NT = 0;
                ButtonEdit buttonEdit = sender as ButtonEdit;
                if (buttonEdit != null && e.Button.Index == 0)
                {
                    GridView gridView = gvProtocolos;
                    if (gridView != null)
                    {
                        int rowIndex = gridView.FocusedRowHandle;
                        Protocolo p = gridView.GetRow(rowIndex) as Protocolo;
                        if (p != null)
                        {
                            LimpiarTodo();
                            datosReporte.IdCodigo = p.Id;
                            protocoloSeleccionado = p;
                            datosReporte.Cliente = protocoloSeleccionado.Cliente;
                            datosReporte.Remito = protocoloSeleccionado.Remito;
                            datosReporte.OrdenDeCompra = protocoloSeleccionado.OrdenDeCompra;

                            if (protocoloSeleccionado.FormatoProtocolo == 0)
                            {
                                EsConProtocolo = false;
                                var descripcionRemito = protocoloSeleccionado.DescripcionRemito.ToLower();
                                if (descripcionRemito.Contains("bolsas") || descripcionRemito.Contains("bolsa"))
                                {
                                    if (br.AsignarProtocoloEstandarBolsaId(protocoloSeleccionado.Id, 2))
                                    {
                                        protocoloSeleccionado.FormatoProtocolo = br.GetIdProcotoco(p.Id);
                                        protocoloSeleccionado.Disposicion = br.GetDisposicion(protocoloSeleccionado.FormatoProtocolo);
                                        btnConProtocolo.PerformClick();
                                    }

                                }
                            }
                            else
                            {
                                EsConProtocolo = true;
                                MessageBox.Show(protocoloSeleccionado.DescripcionRemito.ToLower());
                            }

                            if (protocoloSeleccionado.Disposicion == 1)
                            {
                                groupControl1.Text = "  Lotes del codigo: " + protocoloSeleccionado.Id;
                                GenerarTablaNtsPorLote();
                                GetProtocoloNtsPorLote();
                            }
                            else {
                                groupControl1.Text = "  Nt´s del codigo: " + protocoloSeleccionado.Id;
                                GenerarTablaNtsPorPallet();
                                GetProtocoloNtsPorPallet();
                            }

                            gvNts.OptionsView.ShowGroupPanel = false;
                            gvNts.OptionsBehavior.AutoExpandAllGroups = true;

                            protocoloEnsayos.Clear();
                            gvNts.RefreshData();
                            gvFormatoValores.RefreshData();
                            dvProtocolos.DocumentSource = null;

                            if (nts.Count != 0)
                            {
                                datosReporte.Producto = protocoloSeleccionado.Descripcion;
                                datosReporte.CodigoCliente = protocoloSeleccionado.CodigoCliente;
                                var parametrosCodigo = nts.FirstOrDefault();
                            }
                            lblCliente.Text = protocoloSeleccionado.Cliente;
                            lblProtocoloId.Text = "Protocolo N° " + protocoloSeleccionado.FormatoProtocolo;
                            lblPalletNum.Text = protocoloSeleccionado.Disposicion == 1 ? "Por lote" : "Por pallet";
                        }
                    }
                }
            };
        }
        private void LimpiarTodo()
        {
            //DEJO los 2 por que las columnas se crearan mediante la disposición, borro colunas y datos
            gcNts.DataSource = null;
            gvNts.Columns.Clear();
            gcItemsProtocolo.DataSource = null;
            gcFormatoValores.DataSource = null;

            lblCliente.Text = string.Empty;
            lblNtNum.Text = string.Empty;
            lblProtocoloId.Text = string.Empty;
            lblPalletNum.Text = string.Empty;
            gcFormatoItems.Text = "Protocolo ITEMS";
        }
        private void LimpiarMenuProtocolo()
        {
            lblCliente.Text = string.Empty;
            lblNtNum.Text = string.Empty;
            lblProtocoloId.Text = string.Empty;
            lblPalletNum.Text = string.Empty;
            gcFormatoItems.Text = "Protocolo ITEMS";
        }
        private void GenerarTablaProtocolosItem()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "Item";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cNombre = new GridColumn();
            cNombre.FieldName = "Nombre";
            cNombre.Caption = "Nombre";
            cNombre.UnboundDataType = typeof(string);
            cNombre.Visible = true;
            cNombre.OptionsColumn.AllowEdit = false;

            GridColumn cMedida = new GridColumn();
            cMedida.FieldName = "Medida";
            cMedida.Caption = "Medida";
            cMedida.UnboundDataType = typeof(string);
            cMedida.Visible = true;
            cMedida.OptionsColumn.AllowEdit = false;

            GridColumn cCertifica = new GridColumn();
            cCertifica.FieldName = "EsCertificadoSiNo";
            cCertifica.Caption = "Certifica";
            cCertifica.Visible = true;
            cCertifica.UnboundDataType = typeof(string);
            cCertifica.OptionsColumn.AllowEdit = false;

            GridColumn cEspecificacion = new GridColumn();
            cEspecificacion.FieldName = "EspecificacionDato";
            cEspecificacion.Caption = "Especificación";
            cEspecificacion.Visible = true;
            cEspecificacion.UnboundDataType = typeof(string);
            cEspecificacion.OptionsColumn.AllowEdit = false;

            GridColumn cOrden = new GridColumn();
            cOrden.FieldName = "Orden";
            cOrden.Caption = "Pos°";
            cOrden.Visible = true;
            cOrden.UnboundDataType = typeof(int);
            cOrden.OptionsColumn.AllowEdit = false;

            GridColumn cCheck = new GridColumn();
            cCheck.FieldName = "EsCertificado";
            cCheck.Caption = " ";
            cCheck.Visible = true;
            cCheck.UnboundType = UnboundColumnType.Boolean;

            gvItemsProtocolo.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cCertifica, cEspecificacion, cOrden });
            gcItemsProtocolo.DataSource = protocoItems;

        }
        private void GenerarTablaNtsPorPallet()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cNT = new GridColumn();
            cNT.FieldName = "NumNT";
            cNT.Caption = "NT N°";
            cNT.UnboundDataType = typeof(string);
            cNT.Visible = true;
            cNT.OptionsColumn.AllowEdit = false;

            GridColumn cIdOrden = new GridColumn();
            cIdOrden.FieldName = "Orden";
            cIdOrden.Caption = "Orden";
            cIdOrden.UnboundDataType = typeof(string);
            cIdOrden.Visible = true;
            cIdOrden.OptionsColumn.AllowEdit = false;

            GridColumn cPallet = new GridColumn();
            cPallet.FieldName = "NumPallet";
            cPallet.Caption = "Pallet N°";
            cPallet.UnboundDataType = typeof(string);
            cPallet.Visible = true;
            cPallet.OptionsColumn.AllowEdit = false;

            GridColumn cCantBobina = new GridColumn();
            cCantBobina.FieldName = "CantidadBobinas";
            cCantBobina.Caption = protocoloSeleccionado.UltimoProceso == 1 ? "Bobinas N°" :
                                  protocoloSeleccionado.UltimoProceso == 2 ? "Bobinas N°" :
                                  protocoloSeleccionado.UltimoProceso == 3 ? "Bultos N°" :
                                  protocoloSeleccionado.UltimoProceso == 4 ? "Bobinas N°" :
                                  protocoloSeleccionado.UltimoProceso == 5 ? "Cajas N°" : "Otros";
            cCantBobina.UnboundDataType = typeof(string);
            cCantBobina.Visible = true;
            cCantBobina.OptionsColumn.AllowEdit = false;

            GridColumn cFecha = new GridColumn();
            cFecha.FieldName = "Creado";
            cFecha.Caption = "Creado";
            cFecha.UnboundDataType = typeof(DateTime);
            cFecha.Visible = true;
            cFecha.OptionsColumn.AllowEdit = false;

            gvNts.Columns.AddRange(new GridColumn[] { cId, cNT, cIdOrden, cPallet, cCantBobina, cFecha });

            cIdOrden.GroupIndex = 0;
            cIdOrden.SortOrder = ColumnSortOrder.Descending;
            cPallet.SortOrder = ColumnSortOrder.Ascending;
        }

        private void GenerarTablaNtsPorLote()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cIdOrden = new GridColumn();
            cIdOrden.FieldName = "Orden";
            cIdOrden.Caption = "Orden";
            cIdOrden.UnboundDataType = typeof(string);
            cIdOrden.Visible = true;
            cIdOrden.OptionsColumn.AllowEdit = false;

            GridColumn cNT = new GridColumn();
            cNT.FieldName = "NumNT";
            cNT.Caption = "NTs N°";
            cNT.UnboundDataType = typeof(string);
            cNT.Visible = true;
            cNT.OptionsColumn.AllowEdit = false;

            GridColumn cPallet = new GridColumn();
            cPallet.FieldName = "NumPallet";
            cPallet.Caption = "Pallets N°";
            cPallet.UnboundDataType = typeof(string);
            cPallet.Visible = true;
            cPallet.OptionsColumn.AllowEdit = false;

            GridColumn cFecha = new GridColumn();
            cFecha.FieldName = "Creado";
            cFecha.Caption = "Creado";
            cFecha.UnboundDataType = typeof(DateTime);
            cFecha.Visible = true;
            cFecha.OptionsColumn.AllowEdit = false;

            GridColumn cCantBobina = new GridColumn();
            cCantBobina.FieldName = "CantidadBobinas";
            cCantBobina.Caption = protocoloSeleccionado.UltimoProceso == 1 ? "Bobinas N°" :
                                  protocoloSeleccionado.UltimoProceso == 2 ? "Bobinas N°" :
                                  protocoloSeleccionado.UltimoProceso == 3 ? "Bultos N°" :
                                  protocoloSeleccionado.UltimoProceso == 4 ? "Bobinas N°" :
                                  protocoloSeleccionado.UltimoProceso == 5 ? "Cajas N°" : "Otros";
            cCantBobina.UnboundDataType = typeof(string);
            cCantBobina.Visible = true;
            cCantBobina.OptionsColumn.AllowEdit = false;

            gvNts.Columns.AddRange(new GridColumn[] { cId, cIdOrden, cNT, cPallet, cCantBobina, cFecha });

            cFecha.SortOrder = ColumnSortOrder.Descending;


        }

        private void GenerarTablaEnsayos()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cNombre = new GridColumn();
            cNombre.FieldName = "Nombre";
            cNombre.Caption = "Nombre";
            cNombre.UnboundDataType = typeof(string);
            cNombre.Visible = true;
            cNombre.OptionsColumn.AllowEdit = false;

            GridColumn cValor = new GridColumn();
            cValor.FieldName = "ValorEnsayo";
            cValor.Caption = "Valor";
            cValor.UnboundDataType = typeof(double);
            cValor.Visible = true;
            cValor.OptionsColumn.AllowEdit = false;

            GridColumn cVerGrafico = new GridColumn();
            cVerGrafico.FieldName = "FNVerGrafico";
            cVerGrafico.Caption = " ";
            cVerGrafico.Width = 16;
            cVerGrafico.Visible = true;

            GridColumn cAcciones = new GridColumn();
            cAcciones.FieldName = "FNAcciones";
            cAcciones.Caption = " ";
            cAcciones.Width = 16;
            cAcciones.Visible = true;


            gvFormatoValores.Columns.AddRange(new GridColumn[] { cId, cNombre, cValor, cAcciones, cVerGrafico });
            gcFormatoValores.DataSource = protocoloEnsayos;

            RepositoryItemButtonEdit botonAccion = new RepositoryItemButtonEdit();
            botonAccion.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonAccion.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonAccion.Buttons[0].Image = Properties.Resources.properties_16x16;
            gcFormatoValores.RepositoryItems.Add(botonAccion);
            gvFormatoValores.Columns["FNAcciones"].ColumnEdit = botonAccion;
            botonAccion.ButtonClick += (sender, e) =>
            {
                ButtonEdit buttonEdit = sender as ButtonEdit;
                if (buttonEdit != null && e.Button.Index == 0)
                {

                    GridView gridView = gvFormatoValores;
                    if (gridView != null)
                    {
                        int rowIndex = gridView.FocusedRowHandle;
                        var pi = gridView.GetRow(rowIndex) as ProtocoloEnsayo;
                        if (pi != null)
                        {
                            //if (p.Disposicion == 1) GenerarTablaNtsPorLote();
                            var op = protocoloSeleccionado.Disposicion == 1 ? datosReporte.Lote : datosReporte.NT.ToString();
                            var ensayosDelItem = br.GetEnsayosPorIdProtocoloItem(datosReporte.IdOP, protocoloSeleccionado.FormatoProtocolo, pi.Id);
                            formDeleteUpdateItem form = new formDeleteUpdateItem(ensayosDelItem,pi);
                            form.Size = gcEnsayos.Size;
                            Point locationOnScreen = gcEnsayos.PointToScreen(Point.Empty);
                            form.Location = new Point(locationOnScreen.X - gcEnsayos.Size.Width - 4, locationOnScreen.Y);
                            form.Show();
                        }
                    }
                }
            };


            RepositoryItemButtonEdit botonVer = new RepositoryItemButtonEdit();
            botonVer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonVer.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonVer.Buttons[0].Image = Properties.Resources.pie_16x16;
            gcFormatoValores.RepositoryItems.Add(botonVer);
            gvFormatoValores.Columns["FNVerGrafico"].ColumnEdit = botonVer;

            botonVer.ButtonClick += (sender, e) =>
            {
                ButtonEdit buttonEdit = sender as ButtonEdit;
                if (buttonEdit != null && e.Button.Index == 0)
                {
                    GridView gridView = gvFormatoValores;
                    if (gridView != null)
                    {
                        int rowIndex = gridView.FocusedRowHandle;


                        ProtocoloEnsayo peSeleccionado = gridView.GetRow(rowIndex) as ProtocoloEnsayo;
                        if (peSeleccionado != null)
                        {
                            formGraficoEstadistico form = new formGraficoEstadistico(br.GetEnsayosPorIdProtocoloItem(peSeleccionado, ntSeleccionado.Id));
                            form.Size = new Size(panel7.Width, gcEnsayos.Height);
                            Point locationOnScreen = gcEnsayos.PointToScreen(Point.Empty);
                            form.Location = new Point(locationOnScreen.X - panel7.Size.Width + 2, locationOnScreen.Y);
                            form.Show();
                        }
                    }
                }
            };

        }
        NT ntSeleccionado = new NT();
        private void dvProtocolos_DragDrop(object sender, DragEventArgs e)
        {
            ntSeleccionado = (NT)e.Data.GetData(typeof(NT));
            datosReporte.IdOrden = ntSeleccionado.Orden;
            datosReporte.NT = ntSeleccionado.NumNT;
            datosReporte.Pallet = ntSeleccionado.NumPallet;
            datosReporte.IdOP = ntSeleccionado.Id;
            var idcodigo = Convert.ToInt32(protocoloSeleccionado.Id);
            gcFormatoItems.Text = "Protocolo N° " + protocoloSeleccionado.FormatoProtocolo + " | ITEMS";

            if (protocoloSeleccionado.Disposicion == 1)
            {
                datosReporte.Lote = ntSeleccionado.OP + "/" + ntSeleccionado.NumPallet;
                lblNtNum.Text = "Cantidad NT" + ntSeleccionado.NumNT;
                if (!EsConProtocolo)
                {
                    List<Especificacion> datosDeFicha = new List<Especificacion>
                                    {
                                        br.GetFichaLogisticaConfeccionAncho(protocoloSeleccionado.Id),
                                        br.GetFichaLogisticaConfeccionLargo(protocoloSeleccionado.Id),
                                        br.GetFichaLogisticaEspesor(protocoloSeleccionado.Id)
                                    };

                    if (br.AsignarProtocoloEstandarBolsa(SQLInsertProtocoloItemEspecificacion(datosReporte.IdCodigo, datosDeFicha)))
                    {
                        EsConProtocolo = true;
                    }
                }
                GetProtocoloItemsEspecificados(datosReporte.IdCodigo, "especificacion");
                GetEnsayosRealizadosPorLote(1, protocoloSeleccionado.Datos);
            }
            else {
                datosReporte.Lote = ntSeleccionado.OP;
                lblNtNum.Text = ntSeleccionado.NumNT.ToString();
                GetProtocoloItemsEspecificados(datosReporte.IdCodigo, "especificacion");
                GetEnsayosRealizadosPorPallets(1, protocoloSeleccionado.Datos);
            }

            //else GetEnsayosRealizados();
        }
        public ProtocoloEnsayo espesorDatos = new ProtocoloEnsayo();
        private void gvNts_MouseMove(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            var hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.InRow && e.Button == MouseButtons.Left)
            {
                var data = view.GetRow(hitInfo.RowHandle);
                if (data != null)
                {
                    gcNts.DoDragDrop(data, DragDropEffects.Move);
                }
            }
        }

        private void dvProtocolos_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(NT))) e.Effect = DragDropEffects.Move;
            else e.Effect = DragDropEffects.None;

        }

        Point posicionNts = new Point();
        public bool EsModificadoNtProtocolo = false;
        private void gvNts_RowClick(object sender, RowClickEventArgs e)
        {
            //if (e.Button.IsRight() & gvNts.FocusedRowHandle >= 0)
            //{
            //    GridView gridView = gvNts;
            //    if (gridView != null)
            //    {
            //        int rowIndex = gridView.FocusedRowHandle;
            //        var s = gridView.GetRow(rowIndex) as NT;
            //        if (s != null)
            //        {
            //            idNtSeleccionado = s.Id;
            //            bhiCabeceraNts.Caption = "Acciones para: "+s.NumNT;
            //        }
            //    }
            //    posicionNts = MousePosition;
            //    pMenuGvNts.ShowPopup(MousePosition);
            //}
        }

        private void bbiAsignarProtocolo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EsModificadoNtProtocolo = false;
            formAsignarProtocolo form = new formAsignarProtocolo(idCodigoAModificara);
            form.Location = posicionNts;
            form.ShowDialog();
            if (EsModificadoNtProtocolo)
            {
                //GetCodigosSinProtocolo();
                formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se modifico correctamente.");
                noti.Show();
            }
        }
        private void bbiQuitarProtocolo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (br.QuitarProtocoloACodigo(idCodigoAModificara))
            {
                //GetCodigosSinProtocolo();
                formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se quito correctamente.");
                noti.Show();
            }
        }

        private void btnAsignarItem_Click(object sender, EventArgs e)
        {
            formAsignarItemProtocolo form = new formAsignarItemProtocolo();
            form.Size = gcFormatoItems.Size;
            Point locationOnScreen = gcFormatoItems.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X - gcFormatoItems.Size.Width - 4, locationOnScreen.Y);
            form.Show();
        }

        private void gcItemsProtocolo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ProtocoloItem))) e.Effect = DragDropEffects.Move;
            else e.Effect = DragDropEffects.None;
        }

        public bool EsConfirmadoAgregarItems = false;
        private void gcItemsProtocolo_DragDrop(object sender, DragEventArgs e)
        {
            EsConfirmadoAgregarItems = false;
            var data = (ProtocoloItem)e.Data.GetData(typeof(ProtocoloItem));
            protocoItems.Add(data);
            gvItemsProtocolo.RefreshData();

            if (formAsignarItemProtocolo.instancia != null)
            {
                formAsignarItemProtocolo.instancia.items.Remove(data);
            }

        }
        public void GetCodigosSinProtocolo()
        {
            protocolos = br.GetCodigosSinProtocolos();
            gcProtocolos.DataSource = protocolos;
        }
        public void GetCodigosConProtocolo()
        {
            protocolos = br.GetCodigosConProtocolos();
            gcProtocolos.DataSource = protocolos;
        }
        public void GetProtocoloNtsPorLote()
        {
            nts.Clear();
            nts = br.GetNTsPorLote(protocoloSeleccionado.Id);
            gcNts.DataSource = nts;
        }
        public void GetProtocoloNtsPorPallet()
        {
            nts.Clear();
            nts = br.GetNTsPorPallet(protocoloSeleccionado.Id);
            gcNts.DataSource = nts;
        }

        private string SQLInsertProtocoloItemEspecificacion(int idOp,List<Especificacion> esp)
        {

            string sqlInsertarProtocoloItem = "INSERT INTO formato_protocolo_item_especificacion (id_codigo,id_formato_protocolo_item,especificacion,especificacion_min,especificacion_max) VALUES ";
            string sqlInsertarProtocoloItem2 = "";
            foreach (var item in esp)
            {
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{idOp}','{item.IdProtocoloItem}','{item.Medio}','{item.Minimo}','{item.Maximo}'),";
            }
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
            return sqlInsertarProtocoloItem;
        }

        public void GetProtocoloItemsEspecificados(int idCodigo,string gridControlNombre)
        {
            if (gridControlNombre == "ensayos")
            {
                items = br.GetProtocolosItemsEspecificacionPorCodigo(idCodigo);
                gcItemsValor.DataSource = items;
            }
            else {
                protocoItems = br.GetProtocolosItemsEspecificacionPorCodigo(idCodigo);
                gcItemsProtocolo.DataSource = protocoItems;
            }
          
        }
        public void RefrescarDatosGvItemsProtocolo()
        {
            gvItemsProtocolo.RefreshData();

        }



        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {
            if (protocoloSeleccionado.Id == 0 || datosReporte.IdOP == 0) return;
            GetProtocoloItemsEspecificados(protocoloSeleccionado.Id,"ensayos");
            gcAgregarEnsayo.Visible = true;
        }

        private void btnCancelarEnsayo_Click(object sender, EventArgs e)
        {
            gcAgregarEnsayo.Visible = false;

        }

        private void btnAgregarEnsayoValor_Click(object sender, EventArgs e)
        {

            var ensayo = new ProtocoloItem();
            ensayo.Turno = "Poner automaticamente";
            ensayo.OP = datosReporte.IdOP.ToString();
            ensayo.Legajo = 999; //"TREAR por parametro";
            ensayo.PaqueteNum = 999;
            List<ItemValor> valores = new List<ItemValor>();
            for (int i = 0; i < gvItemsValor.RowCount; i++)
            {
                var idSeleccionado = (int)gvItemsValor.GetRowCellValue(i, "Id");
                var item = items.FirstOrDefault(d => d.Id == idSeleccionado);
                if (item.Valor != null)
                {
                    if (item.Valor == "0") continue;
                    item.Valor = item.Valor.Replace(',', '.');

                    if (item.EsConstante || item.Medida == "Fuelle")
                    {
                        item.ValorConstante = item.Valor.ToString();
                        item.Valor = "0";

                    }
                    else item.ValorConstante = "0";
                    valores.Add(new ItemValor { Valor = item.Valor, ValorConstante = item.ValorConstante, IdItem = item.Id, IdBobinaMadre = 0 });
                };
            }
            if (valores.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un valor de ensaño.");
                return;
            }
            if (br.InsertEnsayoLoteAuditor(valores, ensayo))
            {
                MessageBox.Show("Ensayo agregado correctamente");
                for (int i = 0; i < gvItemsValor.RowCount; i++)
                {
                    gvItemsValor.SetRowCellValue(i, "Valor", "");
                }
                gvItemsValor.FocusedRowHandle = 0;
                GetEnsayosRealizadosPorLote(1, protocoloSeleccionado.Datos);
            }

            //if (br.InsertEnsayo(datosReporte.IdOP, lueItemA.Id, valorEnsayo, esCorrecto))
            //{
            //    LimpiarFormularioEnsayo();
            //    //GetEnsayosRealizadosPorLote(datosReporte.Lote, 1, protocoloSeleccionado.Datos);
            //}
        }
        private bool ValidarFormularioEnsayo()
        {
            //VERIFICAR SIMBOLO
            //var lueNombreA = lueItemEnsayos.GetSelectedDataRow() as ProtocoloItem;
            //if (lueNombreA == null)
            //{
            //    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Modificar ensayo", "Debe seleccionar control.");
            //    noti.Show();
            //    lueItemEnsayos.Focus();
            //    return false;
            //}
            //if (lueNombreA.Simbolo == "A")
            //{
            //    //VERIFICAR NUMERO MIN
            //    if (tbValorEnsayo.Texts == string.Empty)
            //    {
            //        formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero.");
            //        noti.Show();
            //        tbValorEnsayo.Focus();
            //        return false;
            //    }
            //    if (tbValorEnsayo.Texts.Contains(".")) tbValorEnsayo.Texts = tbValorEnsayo.Texts.Replace('.', ','); ;
            //    if (!Utils.IsSoloSignoA(tbValorEnsayo.Texts))
            //    {
            //        formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
            //        noti.Show();
            //        tbValorEnsayo.Focus();
            //        return false;
            //    }
            //}
            //else if (lueNombreA.Simbolo != "C")
            //{
            //    //VERIFICAR NUMERO MIN
            //    if (tbValorEnsayo.Texts == string.Empty)
            //    {
            //        formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero.");
            //        noti.Show();
            //        tbValorEnsayo.Focus();
            //        return false;
            //    }
            //    if (tbValorEnsayo.Texts.Contains(".")) tbValorEnsayo.Texts = tbValorEnsayo.Texts.Replace('.', ','); ;
            //    if (!Utils.IsSoloNumODecimal(tbValorEnsayo.Texts))
            //    {
            //        formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
            //        noti.Show();
            //        tbValorEnsayo.Focus();
            //        return false;
            //    }
            //}

            return true;
        }

        public void GetEnsayosRealizados()
        {
            //dvProtocolos.DocumentSource = null;

            //var pp = br.GetItemsDelProtocolo(protocoloSeleccionado.FormatoProtocolo);
            //if (pp.Contains("Ancho de bolsa")) protocoloEnsayos.AddRange(br.GetEnsayosItemsAnchoBolsa("Ancho de bolsa", idOrden, protocoloSeleccionado.Id));

            //if (protocoloEnsayos.Count != 0)
            //{
            //    xrCertificadoReal protocolo = new xrCertificadoReal();
            //    dvProtocolos.DocumentSource = protocolo;
            //    dvProtocolos.InitiateDocumentCreation();
            //}
            //gcFormatoValores.DataSource = protocoloEnsayos;
        }

        public void GetEnsayosRealizadosPorLote(int certifica, int datos)
        {
            dvProtocolos.DocumentSource = null;
            protocoloEnsayos = br.GetEnsayosVacios(datosReporte.IdCodigo);

            var ensayosConDatos = br.GetEnsayosPorLote(datosReporte.IdOP, datosReporte.IdCodigo, protocoloSeleccionado.FormatoProtocolo, certifica, datos);
            if (ensayosConDatos.Count != 0)
            {
                ensayosConDatos.Add(br.GetEnsayosEspesor(datosReporte.IdOrden, datosReporte.IdCodigo, datosReporte.IdOP, protocoloSeleccionado.PesoMtsTeorico));
               
                foreach (var item in ensayosConDatos)
                {
                    var copiado = protocoloEnsayos.FirstOrDefault(e => e.Id == item.Id);
                    protocoloEnsayos.Remove(copiado);
                    protocoloEnsayos.Add(item);
                }
            }

            xrCertificadoReal protocolo = new xrCertificadoReal();
            dvProtocolos.DocumentSource = protocolo;
            dvProtocolos.InitiateDocumentCreation();
            gcFormatoValores.DataSource = protocoloEnsayos;

        }

        public void GetEnsayosRealizadosPorPallets(int certifica, int datos)
        {
            dvProtocolos.DocumentSource = null;
            protocoloEnsayos = br.GetEnsayosVaciosREEMPLAZAR(datosReporte.IdCodigo,protocoloSeleccionado.FormatoProtocolo);

            xrCertificadoReal protocolo = new xrCertificadoReal();
            dvProtocolos.DocumentSource = protocolo;
            dvProtocolos.InitiateDocumentCreation();
            gcFormatoValores.DataSource = protocoloEnsayos;

        }

        private void LimpiarFormularioEnsayo()
        {
            //tbValorEnsayo.Texts = string.Empty;
            //cbCorrecto.Checked = false;
            //gcAgregarEnsayo.Visible = false;
            //gcValorItem.Visible = false;
            //gcValidarValor.Visible = false;

        }

        private void LeerConfigSplitter()
        {
            var splitter01 = "";
            var splitter02 = "";

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(archivoINI);
            splitter01 = data["splitter01"]["FinRecorrido"];
            splitter02 = data["splitter02"]["FinRecorrido"];
            if (splitter01 != null) splitter1.SplitPosition = Convert.ToInt32(splitter01);
            if (splitter02 != null) splitter2.SplitPosition = Convert.ToInt32(splitter02);
        }

        private void GuardarPosicionSplitter(Splitter splitter, string seccion)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(archivoINI);
            data[seccion]["FinRecorrido"] = splitter.SplitPosition.ToString();
            parser.WriteFile(archivoINI, data);
        }
        private void GuardarParamsProtocolo()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(protocoloINI);
            data["PROTOCOLO"]["LOTE"] = datosReporte.Lote;
            data["PROTOCOLO"]["FECHA"] = "17/04/2025";
            data["PROTOCOLO"]["CLIENTE"] = datosReporte.Cliente;
            data["PROTOCOLO"]["PRODUCTO"] = datosReporte.Producto;
            data["PROTOCOLO"]["CODIGOCLIENTE"] =datosReporte.CodigoCliente;
            data["PROTOCOLO"]["SOLUCITUDCLIENTE"] = "0";
            var controlNum = 0;
            foreach (var item in protocoloEnsayos)
            {
                data["CONTROL:" + controlNum]["NOMBRE"] = item.Nombre;
                data["CONTROL:" + controlNum]["ESPECIFICACION"] = item.Especificacion + "";
                data["CONTROL:" + controlNum]["SIMBOLO"] = item.Simbolo;
                data["CONTROL:" + controlNum]["RESULTADO"] = item.Valor.ToString();
                data["CONTROL:" + controlNum]["UNIDAD"] = item.Unidad;
                controlNum++;
            }
            parser.WriteFile(protocoloINI, data);
        }

        private void splitter1_MouseUp(object sender, MouseEventArgs e)
        {
            GuardarPosicionSplitter(splitter1, "splitter01");
        }

        private void splitter2_MouseUp(object sender, MouseEventArgs e)
        {
            GuardarPosicionSplitter(splitter2, "splitter02");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenerarCertificado_Click(object sender, EventArgs e)
        {
            dvProtocolos.DocumentSource = null;
            xrCertificadoReal certificado = new xrCertificadoReal();
            dvProtocolos.DocumentSource = certificado;
            dvProtocolos.InitiateDocumentCreation();
        }

        private void lueItemEnsayos_EditValueChanged(object sender, EventArgs e)
        {
            //var lueNombreA = lueItemEnsayos.GetSelectedDataRow() as ProtocoloItem;

            //if (lueNombreA != null)
            //{
            //    if (lueNombreA.Simbolo == "C")
            //    {
            //        gcValorItem.Visible = false;
            //        gcValidarValor.Visible = true;
            //    }
            //    else
            //    {
            //        gcValorItem.Visible = true;
            //        gcValidarValor.Visible = false;
            //    }
            //}
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnMaxMin.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnMaxMin.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;

            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            formAgregarItems form = new formAgregarItems();
            Point locationOnScreen = btnAgregarItem.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X, locationOnScreen.Y + btnAgregarItem.Height + 5);
            form.Show();
        }

        int idCodigoAModificara = 0;
        private void gvProtocolos_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button.IsRight() & gvProtocolos.FocusedRowHandle >= 0)
            {
                GridView gridView = gvProtocolos;
                if (gridView != null)
                {
                    int rowIndex = gridView.FocusedRowHandle;
                    var s = gridView.GetRow(rowIndex) as Protocolo;
                    if (s != null)
                    {
                        idCodigoAModificara = s.Id;
                        bhiCabeceraNts.Caption = "Acciones para: " + s.Id;
                    }
                }
                posicionNts = MousePosition;
                pMenuGvNts.ShowPopup(MousePosition);
            }
        }

        private void btnModificarConstantes_Click(object sender, EventArgs e)
        {
            formModificarConstantes form = new formModificarConstantes();
            form.Width = dvProtocolos.Width;
            Point locationOnScreen = dvProtocolos.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X, dvProtocolos.Height - form.Height);
            form.Show();
        }

        private void btnVerCertificaONo_Click(object sender, EventArgs e)
        {
            //if (disposicion == 1) GetEnsayosRealizadosPorLote(datosReporte.Lote, 2, protocoloSeleccionado.Datos);
            //else GetEnsayosRealizados();
        }

        private void btnConProtocolo_Click(object sender, EventArgs e)
        {
            groupControl8.Text = "Códigos en producción con protocolo";
            GetCodigosConProtocolo();
        }

        private void btnSinProtocolo_Click(object sender, EventArgs e)
        {
            groupControl8.Text = "Códigos en producción sin protocolo";
            GetCodigosSinProtocolo();
        }
        private void abrir(string abrirArchivo)
        {

            Process process = new Process();
            try
            {
                process.StartInfo.FileName = abrirArchivo;
                process.Start();
                process.WaitForInputIdle();
            }
            catch { }
        }

        private void gvItemsValor_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as GridView;
            var focus = (ProtocoloItem)gvItemsValor.GetFocusedRow();
            if (view.FocusedColumn.FieldName == "Valor")
            {
                string valor = e.Value?.ToString();
                if (valor.Contains("."))
                {
                    valor = valor.Replace('.', ',');
                    e.Value = valor.Replace('.', ',');
                }

                if (!focus.EsConstante)
                {
                    if (focus.Medida == "Milimetro" || focus.Medida == "Entero")
                    {
                        if (!Utils.IsSoloNumerico(valor))
                        {
                            e.Valid = false;
                            e.ErrorText = "Solo numeros enteros.";
                        }
                    }
                    else if (focus.Medida == "Gramos")
                    {
                        if (!Utils.IsSoloNumODecimal(valor))
                        {
                            e.Valid = false;
                            e.ErrorText = "Solo numeros enteros o decimales.";
                        }
                    }
                    else if (focus.Medida == "Fuelle")
                    {
                        if (!Utils.IsSoloNumOP(valor))
                        {
                            e.Valid = false;
                            e.ErrorText = "Este valor es de fuelle, acepta 2 valores en formato a/b.";
                        }
                    }
                }
                else
                {
                    if (focus.Medida == "Caracter")
                    {
                        if (!Utils.IsSoloSignoA(valor))
                        {
                            e.Valid = false;
                            e.ErrorText = "Este valor es constante y solo permite (ok), (no ok) y (-).";
                        }
                    }

                }
            }
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
          
            // Obtener el reporte del DocumentViewer
            XtraReport reporte = dvProtocolos.DocumentSource as XtraReport;
            if (reporte != null)
            {
                var op = datosReporte.IdOrden + "-" + datosReporte.IdCodigo;
                var path = @"D:\Fuente_Sis\Calidad\Protocolos_PDF\" + op;
                protocoloINI = path + @"\params.ini";
                string rutaGuardado = path + @"\" + protocoloSeleccionado.Id + ".pdf";
                Directory.CreateDirectory(path);
                if (!File.Exists(protocoloINI)) File.Create(protocoloINI).Close();
                GuardarParamsProtocolo();
                reporte.ExportToPdf(rutaGuardado);
                abrir(@"D:\Fuente_Sis\Calidad\Protocolos_PDF\");
            }
            else
            {
            }
        }
    }
}
