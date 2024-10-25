using DevExpress.Data;
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
        Protocolo protocoloSeleccionado = new Protocolo();
        public formAgregarCodigo(Protocolo p)
        {
            this.protocoloSeleccionado = p;
            InitializeComponent();
            GenerarTablaItems(gcItemsExtrusion,gvItemsExtrusion,itemsExtrusion);
            GenerarTablaItems(gcItemsImpresion, gvItemsImpresion, itemsImpresion);
            GenerarTablaItems(gcItemsConfeccion, gvItemsConfeccion, itemsConfeccion);
            GetIdCodigoTolerancias();
            CargarDatosIdCodigo();
        }

        private void CargarDatosIdCodigo()
        {
            lblTitulo.Text = "El codigo: " + protocoloSeleccionado.Id + "no tiene";
            tbCodigo.Texts = protocoloSeleccionado.Id+"";
            tbNombreProtocolo.Texts = protocoloSeleccionado.Descripcion;
            tbNumeroProtocolo.Texts = protocoloSeleccionado.FormatoProtocolo + "";
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
        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
           
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

        
    }
}
