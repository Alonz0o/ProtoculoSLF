using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using ProtoculoSLF.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.Data;
using ProtoculoSLF.Model;
using DevExpress.Utils;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils.Extensions;

namespace ProtoculoSLF
{
    public partial class Form1 : Form
    {
        public BaseRepository br = new BaseRepository();
        public List<Protocolo> protocolos = new List<Protocolo>();
        public List<ProtocoloItem> protocoItems = new List<ProtocoloItem>();
        public List<NT> nts = new List<NT>();
        public List<ProtocoloEnsayo> protocoloEnsayos = new List<ProtocoloEnsayo>();
        public static Form1 instancia;
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerarTablaProtocolos();
            GenerarTablaProtocolosItem();
            GenerarTablaNts();
            GenerarTablaEnsayos();
            gvProtocolos.BestFitColumns();
            gvItemsProtocolo.BestFitColumns();
            gvNts.BestFitColumns();
         
        }

        public Form1()
        {
            InitializeComponent();
            instancia = this;
            br.GetProtocolos();
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

            GridColumn cDescripcion = new GridColumn();
            cDescripcion.FieldName = "Descripcion";
            cDescripcion.Caption = "Descripcion";
            cDescripcion.UnboundDataType = typeof(string);
            cDescripcion.Visible = true;
            cDescripcion.OptionsColumn.AllowEdit = false;

            GridColumn cVerProtocolo = new GridColumn();
            cVerProtocolo.FieldName = "FNVerProtocolo";
            cVerProtocolo.Caption = " ";
            cVerProtocolo.Width = 16;
            cVerProtocolo.Visible = true;

            gvProtocolos.Columns.AddRange(new GridColumn[] { cId, cIdFormato, cFecha, cDescripcion, cVerProtocolo });
            gcProtocolos.DataSource = protocolos.OrderByDescending(e => e.Fecha);

            RepositoryItemButtonEdit botonVer = new RepositoryItemButtonEdit();
            botonVer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonVer.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonVer.Buttons[0].Image = Properties.Resources.show_16x16;
            gcProtocolos.RepositoryItems.Add(botonVer);
            gvProtocolos.Columns["FNVerProtocolo"].ColumnEdit = botonVer;

            botonVer.ButtonClick += (sender, e) =>
            {
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
                            idCodigoSeleccionado = p.Id;
                            nts = br.GetNTs(idCodigoSeleccionado);
                            if (nts.Count != 0)
                            {
                                gcNts.DataSource = nts;
                                var parametrosCodigo = nts.FirstOrDefault();
                                LimpiarMenuProtocolo();
                                lblCliente.Text = parametrosCodigo.Cliente;                       
                            }
                            else
                            {
                                gcItemsProtocolo.DataSource = null;
                                gcNts.DataSource = null;
                                if (protocoItems.Count != 0) gcItemsProtocolo.DataSource = null;
                            }
                        }
                    }
                }
            };

        }
        private void LimpiarMenuProtocolo()
        {
            lblCliente.Text = string.Empty;
            lblNtNum.Text = string.Empty;
            lblProtocoloId.Text = string.Empty;
            lblPalletNum.Text = string.Empty;
            groupControl3.Text = "Protocolo ITEMS";
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

            GridColumn cCheck = new GridColumn();
            cCheck.FieldName = "EsCertificado";
            cCheck.Caption = " ";
            cCheck.Visible = true;
            cCheck.UnboundType = UnboundColumnType.Boolean;

            gvItemsProtocolo.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cCheck });
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
            cCantBobina.Caption = "Bobina N°";
            cCantBobina.UnboundDataType = typeof(string);
            cCantBobina.Visible = true;
            cCantBobina.OptionsColumn.AllowEdit = false;

            GridColumn cIdProtocolo = new GridColumn();
            cIdProtocolo.FieldName = "IdProtocolo";
            cIdProtocolo.Caption = "Protocolo N°";
            cIdProtocolo.UnboundDataType = typeof(string);
            cIdProtocolo.Visible = true;
            cIdProtocolo.OptionsColumn.AllowEdit = false;

            GridColumn cFecha = new GridColumn();
            cFecha.FieldName = "Creado";
            cFecha.Caption = "Creado";
            cFecha.UnboundDataType = typeof(DateTime);
            cFecha.Visible = true;
            cFecha.OptionsColumn.AllowEdit = false;

            gvNts.Columns.AddRange(new GridColumn[] { cId, cNT, cOP, cPallet, cIdProtocolo, cCantBobina, cFecha });
            gcNts.DataSource = protocoItems;

            GridColumnSortInfo[] sortInfo = {
                new GridColumnSortInfo(gvNts.Columns["OP"], ColumnSortOrder.Ascending),
                new GridColumnSortInfo(gvNts.Columns["NumPallet"], ColumnSortOrder.Ascending)};
            gvNts.SortInfo.ClearAndAddRange(sortInfo, 1);

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

            GridColumn cCorrecto = new GridColumn();
            cCorrecto.FieldName = "NumPallet";
            cCorrecto.Caption = "Pallet N°";
            cCorrecto.UnboundDataType = typeof(string);
            cCorrecto.Visible = true;
            cCorrecto.OptionsColumn.AllowEdit = false;

            gvFormatoValores.Columns.AddRange(new GridColumn[] { cId, cNombre, cValor, cCorrecto });
            gcFormatoValores.DataSource = protocoloEnsayos;

            //GridColumnSortInfo[] sortInfo = {
            //    new GridColumnSortInfo(gvNts.Columns["OP"], ColumnSortOrder.Ascending),
            //    new GridColumnSortInfo(gvNts.Columns["NumPallet"], ColumnSortOrder.Ascending)};
            //gvNts.SortInfo.ClearAndAddRange(sortInfo, 1);

        }

        int idCodigoSeleccionado = 0;
        public int idProtocoloSeleccionado = 0;

        private void dvProtocolos_DragDrop(object sender, DragEventArgs e)
        {
            var data = (NT)e.Data.GetData(typeof(NT));
            idProtocoloSeleccionado = data.IdProtocolo;
            idNtSeleccionado = data.NumNT;
            groupControl3.Text = "Protocolo N° " + idProtocoloSeleccionado + " | ITEMS";
            lblNtNum.Text = "NT N° " + data.NumNT;
            lblProtocoloId.Text = "Protocolo N° " + data.IdProtocolo;
            lblPalletNum.Text = "Pallet N° " + data.NumPallet;
            protocoItems = br.GetProtocolosItems(idProtocoloSeleccionado);
            gcItemsProtocolo.DataSource = protocoItems;
            protocoloEnsayos = br.GetEnsayosItems(idProtocoloSeleccionado);
            gcFormatoValores.DataSource = protocoloEnsayos;

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
                MessageBox.Show("Protocolo N° Modificado");
            }
        }

        private void btnAsignarItem_Click(object sender, EventArgs e)
        {
            formAsignarItemProtocolo form = new formAsignarItemProtocolo();
            form.Size = groupControl3.Size;
            Point locationOnScreen = groupControl3.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X - groupControl3.Size.Width - 8, locationOnScreen.Y);
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
                formAsignarItemProtocolo.instancia.RefrescarDatos();
                formAsignarItemProtocolo.instancia.itemsAConfirmar.Add(data);
            }

        }

        public void RefrescarDatosGvItemsProtocolo() {
            gvItemsProtocolo.RefreshData();

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

        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {

            lueItemEnsayos.Properties.DataSource = br.GetProtocolosItems(idProtocoloSeleccionado);
            gcAgregarEnsayo.Visible = true;
        }

        private void btnCancelarEnsayo_Click(object sender, EventArgs e)
        {
            gcAgregarEnsayo.Visible = false;

        }

        private void btnAgregarEnsayoValor_Click(object sender, EventArgs e)
        {
            var valorEnsayo = Convert.ToDouble(tbValorEnsayo.Text);
            var lueItemA = lueItemEnsayos.GetSelectedDataRow() as ProtocoloItem;

            br.InsertEnsayo(idNtSeleccionado, idProtocoloSeleccionado, lueItemA.Id, valorEnsayo);
            var pp = "";
        }
    }
}
