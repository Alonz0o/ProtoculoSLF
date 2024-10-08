using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ProtoculoSLF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtoculoSLF
{
    public partial class formAsignarItemProtocolo : Form
    {
        public List<ProtocoloItem> items = new List<ProtocoloItem>();
        public static formAsignarItemProtocolo instancia;
        public List<ProtocoloItem> itemsAConfirmar = new List<ProtocoloItem>();

        public formAsignarItemProtocolo()
        {
            InitializeComponent();
            instancia = this;
            Deactivate += (s, e) => Close();
        }
        private void formAsignarItemProtocolo_Load(object sender, EventArgs e)
        {
            GenerarTablaItems();
            GetItems();
        }

        private void GenerarTablaItems()
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

            gvItems.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cCheck });
            gcItems.DataSource = items;
        }

        private void gvItems_MouseMove(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            var hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.InRow && e.Button == MouseButtons.Left)
            {
                var data = view.GetRow(hitInfo.RowHandle);
                if (data != null) gcItems.DoDragDrop(data, DragDropEffects.Move);
            }
        }

        private void btnMostrarAgregarItem_Click(object sender, EventArgs e)
        {
            gcAgregarItem.Visible = true;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gcAgregarItem.Visible = false;

        }

        public void RefrescarDatos()
        {
            gvItems.RefreshData();
            groupControl1.Visible = true;
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            ProtocoloItem pi = new ProtocoloItem();
            pi.Nombre = tbNombre.Text;
            pi.Medida = tbMedida.Text;
            pi.Orden = Convert.ToInt32(tbOrden.Text);
            pi.EsCertificado = cbCertificado.Checked;
            if (Form1.instancia.br.AgregarItemProtocolo(pi)) {
                GetItems();
            }
        }
        private void GetItems() {

            items = Form1.instancia.br.GetItems();

            var itemsDiferentes = items
                .Concat(Form1.instancia.protocoItems)
                .GroupBy(x => x.Id)
                .Where(g => g.Count() == 1)
                .Select(g => g.First())
                .ToList();

            items = itemsDiferentes;
            gcItems.DataSource = items;

        }

        private void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = false;
            Form1.instancia.protocoItems.RemoveAll(objB => itemsAConfirmar.Any(objA => objA.Id == objB.Id));
            Form1.instancia.RefrescarDatosGvItemsProtocolo();
            GetItems();
        }

        private void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            string sqlInsertarProtocoloItem = "INSERT INTO formatoprotocoloa_protocolo_item(id_protocolo,id_item) VALUES ";
            string sqlInsertarProtocoloItem2 = "";

            foreach (var item in itemsAConfirmar) {
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"( '{Form1.instancia.idProtocoloSeleccionado}','{item.Id}'),";
            }

            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
            if (Form1.instancia.br.InsertAProtocoloItem(sqlInsertarProtocoloItem)) { 
            
            }
        }
    }
}
