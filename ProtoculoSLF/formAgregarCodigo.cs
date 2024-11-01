using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
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
    public partial class formAgregarCodigo : Form
    {
        List<ProtocoloItem> itemsExtrusion = new List<ProtocoloItem>();
        List<ProtocoloItem> itemsConfeccion = new List<ProtocoloItem>();
        List<ProtocoloItem> itemsImpresion = new List<ProtocoloItem>();
        List<ProtocoloItem> protocoItems = new List<ProtocoloItem>();
        private List<ProtocoloItem> items = new List<ProtocoloItem>();

        List<ProtocoloItem> itemsSeleccionados = new List<ProtocoloItem>();
        int contadorOrden = 1;
        Protocolo protocoloSeleccionado = new Protocolo();
        public formAgregarCodigo(Protocolo p)
        {
            protocoloSeleccionado = p;
            InitializeComponent();
            GenerarTablaItems(gcItemsExtrusion,gvItemsExtrusion,itemsExtrusion);
            GenerarTablaItems(gcItemsImpresion, gvItemsImpresion, itemsImpresion);
            GenerarTablaItems(gcItemsConfeccion, gvItemsConfeccion, itemsConfeccion);
            GenerarTablaItemsAsignados();
            GetIdCodigoTolerancias();
            CargarDatosIdCodigo();
            GenerarTablaItemsTodos();

            GetItems();

            itemsSeleccionados.AddRange(itemsExtrusion);
            itemsSeleccionados.AddRange(itemsImpresion);
            itemsSeleccionados.AddRange(itemsConfeccion);

            items.RemoveAll(a => itemsSeleccionados.Any(p1 => p1.Nombre == a.Nombre));

        }
        private void GetItems()
        {
            items = Form1.instancia.br.GetItems();
            gcTodosItems.DataSource = items;
        }

        private void GenerarTablaItemsAsignados()
        {
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

            GridColumn cSimbolo = new GridColumn();
            cSimbolo.FieldName = "Simbolo";
            cSimbolo.Caption = "Simbolo";
            cSimbolo.Visible = true;
            cSimbolo.UnboundDataType = typeof(string);
            cSimbolo.OptionsColumn.AllowEdit = false;

            GridColumn cOrden = new GridColumn();
            cOrden.FieldName = "Orden";
            cOrden.Caption = "Orden";
            cOrden.Visible = true;
            cOrden.UnboundDataType = typeof(string);
            cOrden.OptionsColumn.AllowEdit = false;

            GridColumn cBorrar = new GridColumn();
            cBorrar.FieldName = "FNBorrar";
            cBorrar.Caption = " ";
            cBorrar.Width = 16;
            cBorrar.Visible = true;

            gvItemsAsignados.Columns.AddRange(new GridColumn[] { cNombre, cMedida, cCertifica, cSimbolo, cOrden, cBorrar });
            gcItemsAsignados.DataSource = protocoItems;

            RepositoryItemButtonEdit botonBorrar = new RepositoryItemButtonEdit();
            botonBorrar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonBorrar.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonBorrar.Buttons[0].Image = Properties.Resources.clear_16x16;
            gcItemsAsignados.RepositoryItems.Add(botonBorrar);
            gvItemsAsignados.Columns["FNBorrar"].ColumnEdit = botonBorrar;

            botonBorrar.ButtonClick += (sender, e) =>
            {
                ButtonEdit buttonEdit = sender as ButtonEdit;
                if (buttonEdit != null && e.Button.Index == 0)
                {
                    GridView gridView = gvItemsAsignados;
                    if (gridView != null)
                    {
                        int rowIndex = gridView.FocusedRowHandle;
                        var pi = gridView.GetRow(rowIndex) as ProtocoloItem;
                        if (pi != null)
                        {
                            protocoItems.Remove(pi);
                            gridView.RefreshData();
                            contadorOrden--;
                        }
                    }
                }
            };

        }

        private void GenerarTablaItemsTodos()
        {
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

            GridColumn cSimbolo = new GridColumn();
            cSimbolo.FieldName = "Simbolo";
            cSimbolo.Caption = "Simbolo";
            cSimbolo.Visible = true;
            cSimbolo.UnboundDataType = typeof(string);
            cSimbolo.OptionsColumn.AllowEdit = false;

            gvTodosItems.Columns.AddRange(new GridColumn[] { cNombre, cMedida, cCertifica, cSimbolo });
            gcTodosItems.DataSource = items;

        }
        private void CargarDatosIdCodigo()
        {
            lblTitulo.Text = "El codigo: " + protocoloSeleccionado.Id + " tiene protocolo asignado ("+ protocoloSeleccionado.FormatoProtocolo+") pero no tiene ítems";
           
            tbCliente.Texts = "CLIENTE";
            tbCodigo.Texts = protocoloSeleccionado.Id+"";
            tbNombreProtocolo.Texts = protocoloSeleccionado.Descripcion;
            tbNumeroProtocolo.Texts = protocoloSeleccionado.FormatoProtocolo + "";
            groupControl7.Text = "Ítems de protocolo: (" + protocoloSeleccionado.FormatoProtocolo+")";
            protocoItems = Form1.instancia.br.GetProtocolosItems(protocoloSeleccionado.FormatoProtocolo);
            gcItemsAsignados.DataSource = protocoItems;
        }

        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void GetIdCodigoTolerancias() {
            itemsExtrusion = Form1.instancia.br.GetExtrusionItems(protocoloSeleccionado.Id);
            gcItemsExtrusion.DataSource = itemsExtrusion;
            itemsImpresion = Form1.instancia.br.GetImpresionItems(protocoloSeleccionado.Id);
            gcItemsImpresion.DataSource = itemsImpresion;
            itemsConfeccion = Form1.instancia.br.GetConfeccionItems(protocoloSeleccionado.Id);
            gcItemsConfeccion.DataSource = itemsConfeccion;
        }

        private void GenerarTablaItems(GridControl gc, GridView gv, List<ProtocoloItem> items)
        {
            GridColumn cNombre = new GridColumn();
            cNombre.FieldName = "Nombre";
            cNombre.Caption = "Nombre";
            cNombre.UnboundDataType = typeof(string);
            cNombre.Visible = true;
            cNombre.OptionsColumn.AllowEdit = false;

            GridColumn cEspecificacion = new GridColumn();
            cEspecificacion.FieldName = "EspecificacionDato";
            cEspecificacion.Caption = "Especificación";
            cEspecificacion.Visible = true;
            cEspecificacion.UnboundDataType = typeof(string);
            cEspecificacion.OptionsColumn.AllowEdit = false;

            GridColumn cMedida = new GridColumn();
            cMedida.FieldName = "Medida";
            cMedida.Caption = "Medida";
            cMedida.UnboundDataType = typeof(string);
            cMedida.Visible = true;
            cMedida.OptionsColumn.AllowEdit = false;

            GridColumn cCheck = new GridColumn();
            cCheck.FieldName = "Seleccionar";
            cCheck.Caption = " ";
            cCheck.Visible = true;
            cCheck.UnboundType = UnboundColumnType.Boolean;
            cCheck.Width = 16;

            gv.Columns.AddRange(new GridColumn[] { cNombre, cEspecificacion,cMedida,cCheck });
            gc.DataSource = items;
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            List<ProtocoloItem> seleccionados = itemsSeleccionados.FindAll(ex => ex.Seleccionar == true).ToList();

            var disposicion = rbPorLote.Checked ? 1 : rbPorPallet.Checked ? 2 : 0;
            Form1.instancia.br.UpdateDisposicionProtocolo(disposicion,protocoloSeleccionado.FormatoProtocolo);
            foreach (var item in seleccionados)
            {
                item.IdProtocoloItem = Form1.instancia.br.GetIdProtocoloItemPorNombre(item.Nombre);
                if (item.IdProtocoloItem == 0) {
                    item.Id = Form1.instancia.br.AgregarItemFOREACHBORRAR(item);
                }
                item.IdProtocolo = protocoloSeleccionado.FormatoProtocolo;
                Form1.instancia.br.AgregarItemProtocolo(item, protocoloSeleccionado.Id);
            }
            Close();
        }

        private void gcItemsAsignados_DragDrop(object sender, DragEventArgs e)
        {
            var data = (ProtocoloItem)e.Data.GetData(typeof(ProtocoloItem));
            data.Orden = contadorOrden;
            protocoItems.Add(data);
            gvItemsAsignados.RefreshData();
            contadorOrden++;
        }

        private void gcItemsAsignados_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(ProtocoloItem))) e.Effect = DragDropEffects.Move;
            else e.Effect = DragDropEffects.None;
        }

        private void gvTodosItems_MouseMove(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            var hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.InRow && e.Button == MouseButtons.Left)
            {
                var data = view.GetRow(hitInfo.RowHandle);
                if (data != null)
                {
                    gcTodosItems.DoDragDrop(data, DragDropEffects.Move);
                }
            }
        }
    }
}
