using DevExpress.Data;
using DevExpress.XtraEditors;
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
            cSimbolo.Caption = "SIM";
            cSimbolo.Visible = true;
            cSimbolo.UnboundDataType = typeof(string);
            cSimbolo.Visible = true;
            cSimbolo.OptionsColumn.AllowEdit = false;

            GridColumn cOrden = new GridColumn();
            cOrden.FieldName = "Orden";
            cOrden.Caption = "Orden";
            cOrden.Visible = true;
            cOrden.UnboundDataType = typeof(string);
            cOrden.Visible = true;
            cOrden.OptionsColumn.AllowEdit = false;

            gvItemsAsignados.Columns.AddRange(new GridColumn[] { cNombre, cMedida, cCertifica, cSimbolo,cOrden });
            gcItemsAsignados.DataSource = protocoItems;
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
            List<ProtocoloItem> itemsSeleccionados = new List<ProtocoloItem>();
            itemsSeleccionados.AddRange(itemsExtrusion.FindAll(ex => ex.Seleccionar == true).ToList());
            itemsSeleccionados.AddRange(itemsImpresion.FindAll(ex => ex.Seleccionar == true).ToList());
            itemsSeleccionados.AddRange(itemsConfeccion.FindAll(ex => ex.Seleccionar == true).ToList());
            foreach (var item in itemsSeleccionados)
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
    }
}
