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
        public Form1()
        {
            InitializeComponent();
            GenerarTablaProtocolos();
        }

        private void GenerarTablaProtocolos()
        {
            gcProtocolos.DataSource = null;

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
            gcProtocolos.DataSource = br.GetProtocolos().OrderByDescending(e => e.Fecha);

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
            MessageBox.Show($"Se arrastró: {data.Id}");
        }
    }
}
