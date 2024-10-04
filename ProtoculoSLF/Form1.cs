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

namespace ProtoculoSLF
{
    public partial class Form1 : Form
    {
        BaseRepository br = new BaseRepository();
        public List<Protocolo> protocolos = new List<Protocolo>();
        public List<ProtocoloItem> protocoItems = new List<ProtocoloItem>();
        public List<NT> nts = new List<NT>();

        public static Form1 instancia;
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerarTablaProtocolos();
            GenerarTablaProtocolosItem();
            GenerarTablaNts();
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

            gvProtocolos.Columns.AddRange(new GridColumn[] { cId, cIdFormato, cFecha, cDescripcion });
            gcProtocolos.DataSource = protocolos.OrderByDescending(e => e.Fecha);
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

            GridColumn cFecha = new GridColumn();
            cFecha.FieldName = "Creado";
            cFecha.Caption = "Creado";
            cFecha.UnboundDataType = typeof(DateTime);
            cFecha.Visible = true;
            cFecha.OptionsColumn.AllowEdit = false;

            gvNts.Columns.AddRange(new GridColumn[] { cId, cNT, cOP, cPallet, cFecha, cCantBobina });
            gcNts.DataSource = protocoItems;

            GridColumnSortInfo[] sortInfo = {
                new GridColumnSortInfo(gvNts.Columns["OP"], ColumnSortOrder.Ascending),
                new GridColumnSortInfo(gvNts.Columns["NumPallet"], ColumnSortOrder.Ascending)};
            gvNts.SortInfo.ClearAndAddRange(sortInfo, 1);

        }

        private void gvProtocolos_MouseDown(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            var hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.InRow && e.Button == MouseButtons.Left)
            {
                var data = view.GetRow(hitInfo.RowHandle);
                if (data != null) gcProtocolos.DoDragDrop(data, DragDropEffects.Move);
            }
        }

        private void documentViewer1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Protocolo))) e.Effect = DragDropEffects.Move;
            else e.Effect = DragDropEffects.None;
        }

        private void documentViewer1_DragDrop(object sender, DragEventArgs e)
        {
            var data = (Protocolo)e.Data.GetData(typeof(Protocolo));
            protocoItems = br.GetProtocolosItems(data.FormatoProtocolo);
            gcItemsProtocolo.DataSource = protocoItems;
            if (protocoItems.Count != 0)
            {
                nts = br.GetNTs(data.Id);
                gcNts.DataSource = nts;
                var parametrosCodigo = nts.FirstOrDefault();
                lblCliente.Text = parametrosCodigo.Cliente;
            }
            else {
                gcNts.DataSource = null;
            }
        }
    }
}
