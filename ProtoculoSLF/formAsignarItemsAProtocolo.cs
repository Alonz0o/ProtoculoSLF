using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    public partial class formAsignarItemsAProtocolo : Form
    {
        List<ProtocoloItem> protocoItems = new List<ProtocoloItem>();
        private List<ProtocoloItem> items = new List<ProtocoloItem>();
        Protocolo protocoloSeleccionado = new Protocolo();
        public formAsignarItemsAProtocolo(Protocolo p)
        {
            Form1.instancia.EsCanceladoFormAsignarItemAProtocolo = false;
            InitializeComponent();
            protocoloSeleccionado = p;

            //protocoItems = Form1.instancia.br.GetProtocolosItems();
            GenerarTablaItemsAsignados();
            GenerarTablaItemsTodos();
            GetItems();
            GetDatosProtocolo();
        }

        private void GetDatosProtocolo()
        {
            lblTitulo.Text = "El protocolo: ("+protocoloSeleccionado.FormatoProtocolo+ ") no tiene Ítems asignados.";
            lblMensaje.Text = "Es necesario agregar ítems al protocolo correspondiente.";
            groupControl7.Text = "Ítems asignados a: (" + protocoloSeleccionado.FormatoProtocolo + ")";
        }

        private void GetItems()
        {
            items = Form1.instancia.br.GetItems();
            gcTodosItems.DataSource = items;
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

            GridColumn cOrden = new GridColumn();
            cOrden.FieldName = "Orden";
            cOrden.Caption = "Orden";
            cOrden.Visible = true;
            cNombre.UnboundDataType = typeof(string);
            cNombre.Visible = true;
            cNombre.OptionsColumn.AllowEdit = false;

            gvTodosItems.Columns.AddRange(new GridColumn[] { cNombre, cMedida, cCertifica, cSimbolo, cOrden });
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

            gvItemsAsignados.Columns.AddRange(new GridColumn[] { cNombre, cMedida, cCertifica,cSimbolo, cOrden, cBorrar });
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
                        }
                    }
                }
            };

        }

        private void gcItemsAsignados_DragDrop(object sender, DragEventArgs e)
        {
            var data = (ProtocoloItem)e.Data.GetData(typeof(ProtocoloItem));
            protocoItems.Add(data);
            gvItemsAsignados.RefreshData();

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

        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Form1.instancia.EsCanceladoFormAsignarItemAProtocolo = true;
            Close();
        }

        private void btnAgregarItemAProtocolo_Click(object sender, EventArgs e)
        {
            int ultimaPosicion = Form1.instancia.br.GetUltimaPosicionProtocoloItem(Form1.instancia.idProtocoloSeleccionado) + 1;

            string sqlInsertarProtocoloItem = "INSERT INTO formato_protocolo_item(id_protocolo,id_item,orden) VALUES ";
            string sqlInsertarProtocoloItem2 = "";

            foreach (var item in protocoItems)
            {
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{Form1.instancia.idProtocoloSeleccionado}','{item.Id}','{ultimaPosicion}'),";
                ultimaPosicion++;
            }

            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
            if (Form1.instancia.br.InsertAProtocoloItem(sqlInsertarProtocoloItem))
            {
                Form1.instancia.GetProtocoloItems();
                formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se agregaron los ítem seleccionados al protocolo: " + Form1.instancia.idProtocoloSeleccionado);
                noti.Show();
                Close();
            }


        }
    }

}
