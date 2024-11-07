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
using DevExpress.XtraExport.Helpers;

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
        public static Form1 instancia;
        public int idCodigoSeleccionado = 0;
        public bool esPorLote;
        public int idProtocoloSeleccionado = 0;
        private int disposicion;

      

        private async Task GetEnsayosTask()
        {
            while (true)
            {
                if (br.GetCambios() > 0)
                {
                    MessageBox.Show("sadsa");
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
           
            GenerarTablaEnsayos();
            if (!File.Exists(archivoINI)) File.Create(archivoINI).Close();
            LeerConfigSplitter();
            instancia = this;
            GetProtocolos();

        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await GetEnsayosTask();
        }
        private void GenerarTablaProtocolos()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "Codigo";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;
            cId.Visible = true;

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

            GridColumn cVerProtocolo = new GridColumn();
            cVerProtocolo.FieldName = "FNVerProtocolo";
            cVerProtocolo.Caption = " ";
            cVerProtocolo.Width = 16;
            cVerProtocolo.Visible = true;

            gvProtocolos.Columns.AddRange(new GridColumn[] { cId, cIdFormato, cFecha, cNombre, cVerProtocolo });
            gcProtocolos.DataSource = protocolos.OrderByDescending(e => e.Fecha);

            RepositoryItemButtonEdit botonVer = new RepositoryItemButtonEdit();
            botonVer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonVer.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonVer.Buttons[0].Image = Properties.Resources.show_16x16;
            gcProtocolos.RepositoryItems.Add(botonVer);
            gvProtocolos.Columns["FNVerProtocolo"].ColumnEdit = botonVer;

            botonVer.ButtonClick += (sender, e) =>
            {
                idNtSeleccionado = 0;
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
                            gvNts.Columns.Clear();
                            if (p.Disposicion == 1) GenerarTablaNtsPorLote();
                            else GenerarTablaNts();

                            idCodigoSeleccionado = p.Id;
                            idProtocoloSeleccionado = p.FormatoProtocolo;
                            disposicion = p.Disposicion;
                            GetProtocoloItems();

                            if (p.Disposicion == 1)  GetProtocoloNtsPorPallets();                          
                            else GetProtocoloNts();

                            LimpiarMenuProtocolo();
                            protocoloEnsayos.Clear();
                            gvFormatoValores.RefreshData();
                            dvProtocolos.DocumentSource = null;

                            if (nts.Count != 0)
                            {
                                datosReporte.Producto = p.Descripcion;
                                datosReporte.CodigoCliente = p.CodigoCliente;
                                var parametrosCodigo = nts.FirstOrDefault();
                            }
                            lblCliente.Text = p.Cliente;
                            lblProtocoloId.Text = "Protocolo N° " + idProtocoloSeleccionado;
                            lblPalletNum.Text = disposicion == 1 ? "Por lote" : "Por pallet";
                        }
                    }
                }
            };
        }

        public bool EsCanceladoFormAsignarItemAProtocolo = false;
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
        private void GenerarTablaNts()
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

            GridColumn cOP = new GridColumn();
            cOP.FieldName = "OP";
            cOP.Caption = "OP";
            cOP.UnboundDataType = typeof(string);
            cOP.Visible = true;
            cOP.OptionsColumn.AllowEdit = false;

            GridColumn cPallet = new GridColumn();
            cPallet.FieldName = "NumPallet";
            cPallet.Caption = "Pallet N°";
            cPallet.UnboundDataType = typeof(string);
            cPallet.Visible = true;
            cPallet.OptionsColumn.AllowEdit = false;

            GridColumn cCantBobina = new GridColumn();
            cCantBobina.FieldName = "CantidadBobinas";
            cCantBobina.Caption = "Cantidad N°";
            cCantBobina.UnboundDataType = typeof(string);
            cCantBobina.Visible = true;
            cCantBobina.OptionsColumn.AllowEdit = false;       

            GridColumn cFecha = new GridColumn();
            cFecha.FieldName = "Creado";
            cFecha.Caption = "Creado";
            cFecha.UnboundDataType = typeof(DateTime);
            cFecha.Visible = true;
            cFecha.OptionsColumn.AllowEdit = false;

            gvNts.Columns.AddRange(new GridColumn[] { cId, cNT, cOP, cPallet, cCantBobina, cFecha });
            gcNts.DataSource = nts;

            GridColumnSortInfo[] sortInfo = {
                new GridColumnSortInfo(gvNts.Columns["OP"], ColumnSortOrder.Ascending),
                new GridColumnSortInfo(gvNts.Columns["NumPallet"], ColumnSortOrder.Ascending)};
            gvNts.SortInfo.ClearAndAddRange(sortInfo, 1);
        }

        private void GenerarTablaNtsPorLote()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cOP = new GridColumn();
            cOP.FieldName = "OP";
            cOP.Caption = "OP";
            cOP.UnboundDataType = typeof(string);
            cOP.Visible = true;
            cOP.OptionsColumn.AllowEdit = false;

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

            GridColumn cCantBobina = new GridColumn();
            cCantBobina.FieldName = "CantidadBobinas";
            cCantBobina.Caption = "Cantidad N°";
            cCantBobina.UnboundDataType = typeof(string);
            cCantBobina.Visible = true;
            cCantBobina.OptionsColumn.AllowEdit = false;

            //GridColumn cFecha = new GridColumn();
            //cFecha.FieldName = "Creado";
            //cFecha.Caption = "Creado";
            //cFecha.UnboundDataType = typeof(DateTime);
            //cFecha.Visible = true;
            //cFecha.OptionsColumn.AllowEdit = false;

            gvNts.Columns.AddRange(new GridColumn[] { cId, cOP, cNT, cPallet,cCantBobina });
            gcNts.DataSource = nts;

           
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


            gvFormatoValores.Columns.AddRange(new GridColumn[] { cId, cNombre, cValor, cAcciones,cVerGrafico });
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
                            formDeleteUpdateItem form = new formDeleteUpdateItem(br.GetEnsayosPorIdProtocoloItem(pi.IdProtocoloItem));
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
                            formGraficoEstadistico form = new formGraficoEstadistico(br.GetEnsayosPorIdProtocoloItem(peSeleccionado));
                            form.Size = new Size(panel7.Width, gcEnsayos.Height);
                            Point locationOnScreen = gcEnsayos.PointToScreen(Point.Empty);
                            form.Location = new Point(locationOnScreen.X - panel7.Size.Width + 2, locationOnScreen.Y);
                            form.Show();
                        }
                    }
                }
            };

        }
        int idOrden = 0;
        private void dvProtocolos_DragDrop(object sender, DragEventArgs e)
        {
            var data = (NT)e.Data.GetData(typeof(NT));
            idNtSeleccionado = data.NumNT;
            datosReporte.Cliente = data.Cliente;
            datosReporte.Lote = data.OP + "/" + data.NumPallet;
            datosReporte.Pallet = data.NumPallet;
            idOrden = Convert.ToInt32(data.OP.Split('/')[0]);
            gcFormatoItems.Text = "Protocolo N° " + idProtocoloSeleccionado + " | ITEMS";
            lblNtNum.Text = "NT N° " + data.NumNT;
            lblPalletNum.Text = disposicion == 1 ? "Por lote" : "Por pallet: " + data.NumPallet;

            if (disposicion == 1) GetEnsayosRealizadosPorLote(data.OP);
            else GetEnsayosRealizados();
        }

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
        int idNtSeleccionado = 0;
        public bool EsModificadoNtProtocolo = false;
        private void gvNts_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button.IsRight() & gvNts.FocusedRowHandle >= 0)
            {
                GridView gridView = gvNts;
                if (gridView != null)
                {
                    int rowIndex = gridView.FocusedRowHandle;
                    var s = gridView.GetRow(rowIndex) as NT;
                    if (s != null)
                    {
                        idNtSeleccionado = s.Id;
                        bhiCabeceraNts.Caption = "Acciones para: "+s.NumNT;
                    }
                }
                posicionNts = MousePosition;
                pMenuGvNts.ShowPopup(MousePosition);
            }
        }

        private void bbiAsignarProtocolo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EsModificadoNtProtocolo = false;
            formAsignarProtocolo form = new formAsignarProtocolo(idNtSeleccionado);
            form.Location = posicionNts;
            form.ShowDialog();
            if (EsModificadoNtProtocolo)
            {
                gvProtocolos.RefreshData();
                formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se modifico correctamente.");
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
        public void GetProtocolos()
        {
            protocolos = br.GetProtocolos();            
            gcProtocolos.DataSource = protocolos;
        }
        public void GetProtocoloNts()
        {
            nts = br.GetNTs(idCodigoSeleccionado);
            gcNts.DataSource = nts;
        }
        public void GetProtocoloNtsPorPallets()
        {
            nts = br.GetNTsPorLote(idCodigoSeleccionado);
            gcNts.DataSource = nts;
        }
        
        public void GetProtocoloItems() {
            protocoItems = br.GetProtocolosItemsEspecificacionPorCodigo(idCodigoSeleccionado);
            gcItemsProtocolo.DataSource = protocoItems;
        }
        public void RefrescarDatosGvItemsProtocolo() {
            gvItemsProtocolo.RefreshData();

        }

     

        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {
            if (idCodigoSeleccionado == 0 || idNtSeleccionado==0) return;
            lueItemEnsayos.Properties.DataSource = br.GetProtocolosItemsEspecificacionPorCodigo(idCodigoSeleccionado);
            gcAgregarEnsayo.Visible = true;
        }

        private void btnCancelarEnsayo_Click(object sender, EventArgs e)
        {
            gcAgregarEnsayo.Visible = false;

        }

        private void btnAgregarEnsayoValor_Click(object sender, EventArgs e)
        {
            if(!ValidarFormularioEnsayo())return;
            var esCorrecto = cbCorrecto.Checked;
            double valorEnsayo = 0;
            if (!string.IsNullOrEmpty(tbValorEnsayo.Texts)) valorEnsayo = Convert.ToDouble(tbValorEnsayo.Texts);

            var lueItemA = lueItemEnsayos.GetSelectedDataRow() as ProtocoloItem;
            if (esCorrecto) valorEnsayo = 0;

            if (br.InsertEnsayo(idNtSeleccionado, lueItemA.IdProtocoloItem, valorEnsayo, Convert.ToInt32(cbCorrecto.Checked)))
            {
                LimpiarFormularioEnsayo();
                GetEnsayosRealizados();
            }
        }
        private bool ValidarFormularioEnsayo()
        {
            //VERIFICAR SIMBOLO
            var lueNombreA = lueItemEnsayos.GetSelectedDataRow() as ProtocoloItem;
            if (lueNombreA == null)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Modificar ensayo", "Debe seleccionar control.");
                noti.Show();
                lueItemEnsayos.Focus();
                return false;
            }
            if (lueNombreA.Simbolo!="C") {
                //VERIFICAR NUMERO MIN
                if (tbValorEnsayo.Texts == string.Empty)
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero.");
                    noti.Show();
                    tbValorEnsayo.Focus();
                    return false;
                }
                if (tbValorEnsayo.Texts.Contains(".")) tbValorEnsayo.Texts = tbValorEnsayo.Texts.Replace('.', ','); ;
                if (!Utils.IsSoloNumODecimal(tbValorEnsayo.Texts))
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
                    noti.Show();
                    tbValorEnsayo.Focus();
                    return false;
                }
            }

            return true;
        }

        public void GetEnsayosRealizados()
        {
            dvProtocolos.DocumentSource = null;

            var pp = br.GetItemsDelProtocolo(idProtocoloSeleccionado);
            if (pp.Contains("Ancho de bolsa")) protocoloEnsayos.AddRange(br.GetEnsayosItemsAnchoBolsa("Ancho de bolsa",idOrden,idCodigoSeleccionado));

            if (protocoloEnsayos.Count != 0)
            {
                xrCertificadoReal protocolo = new xrCertificadoReal();
                dvProtocolos.DocumentSource = protocolo;
                dvProtocolos.InitiateDocumentCreation();
            }
            gcFormatoValores.DataSource = protocoloEnsayos;
        }

        public void GetEnsayosRealizadosPorLote(string op)
        {
            dvProtocolos.DocumentSource = null;
            protocoloEnsayos = br.GetEnsayosPorLote(op);

            if (protocoloEnsayos.Count != 0)
            {
                xrCertificadoReal protocolo = new xrCertificadoReal();
                dvProtocolos.DocumentSource = protocolo;
                dvProtocolos.InitiateDocumentCreation();
            }
            gcFormatoValores.DataSource = protocoloEnsayos;
        }

        private void LimpiarFormularioEnsayo()
        {
            tbValorEnsayo.Texts = string.Empty;
            cbCorrecto.Checked = false;
            gcAgregarEnsayo.Visible = false;
            gcValorItem.Visible = false;
            gcValidarValor.Visible = false;

        }

        string archivoINI = Directory.GetCurrentDirectory() + @"\config.ini";
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
            var lueNombreA = lueItemEnsayos.GetSelectedDataRow() as ProtocoloItem;

            if (lueNombreA!=null) {
                if (lueNombreA.Simbolo == "C")
                {
                    gcValorItem.Visible = false;
                    gcValidarValor.Visible = true;
                }
                else {
                    gcValorItem.Visible = true;
                    gcValidarValor.Visible = false;
                }        
            }
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

        private void btnAsignarCodigo_Click(object sender, EventArgs e)
        {
         
        }
        private void btnAgregarProtocolo_Click(object sender, EventArgs e)
        {
            formAgregarProtocolo form = new formAgregarProtocolo();
            form.Size = panel7.Size;
            Point locationOnScreen = panel7.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X, locationOnScreen.Y);
            form.Show();
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            formAgregarItems form = new formAgregarItems();
            Point locationOnScreen = btnAgregarItem.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X, locationOnScreen.Y + btnAgregarItem.Height + 5);
            form.Show();
        }

       
    }
}
