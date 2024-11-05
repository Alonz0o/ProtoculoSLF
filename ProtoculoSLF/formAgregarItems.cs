using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ProtoculoSLF.Model;
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

namespace ProtoculoSLF
{
    public partial class formAgregarItems : Form
    {
        private List<ProtocoloItem> items = new List<ProtocoloItem>();
        private ProtocoloItem protocoloItemSeleccionado = new ProtocoloItem();
        public string confirmar = "";

        public formAgregarItems()
        {
            InitializeComponent();
        }
        private void formAgregarItems_Load(object sender, EventArgs e)
        {
            GenerarTablaItems();
            GetItems();
            List<Unidad> unidades = new List<Unidad> {
                new Unidad{ Nombre="NA", Descripcion="No asigar" },
                new Unidad{ Nombre="Milimetro", Descripcion="mm" },
                new Unidad{ Nombre="Kg/pulgada", Descripcion="kg/in" },
                new Unidad{ Nombre="Micron", Descripcion="µm" },
            };
            List<Simbolo> simbolos = new List<Simbolo> { 
                //new Simbolo{ Caracter ="=",Significado="Igual a" },
                //new Simbolo{ Caracter ="≠",Significado="Diferente de" },
                new Simbolo{ Caracter ="<",Significado="Menor que" },
                new Simbolo{ Caracter =">",Significado="Mayor que" },
                //new Simbolo{ Caracter ="≤",Significado="Menor o igual a" },
                //new Simbolo{ Caracter ="≥",Significado="Mayor o igual a" },
                new Simbolo{ Caracter ="±",Significado="Más o menos" },
                //new Simbolo{ Caracter ="∓",Significado="Menos o más" },
                new Simbolo{ Caracter ="-",Significado="Entre A y B" },

            };
            List<string> proceso = new List<string> {
                "Extrusión",
                "Impresión",
                "Confección",
                "Rebobinado",
                "Wicket"

            };
            lueItemSimbolos.Properties.DataSource = simbolos;
            lueItemUnidades.Properties.DataSource = unidades;
            lueItemProcesos.Properties.DataSource = proceso;
        }
        private void GetItems()
        {
            items = Form1.instancia.br.GetItems();
            gcItems.DataSource = items;
        }
        private void cbCaracter_CheckedChanged(object sender, EventArgs e)
        {
            groupControl13.Visible = !cbConstante.Checked;
            gcSimbolo.Visible = !cbConstante.Checked;

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

            GridColumn cCertifica = new GridColumn();
            cCertifica.FieldName = "EsCertificadoSiNo";
            cCertifica.Caption = "Certifica";
            cCertifica.Visible = true;
            cCertifica.UnboundDataType = typeof(string);
            cCertifica.OptionsColumn.AllowEdit = false;

            GridColumn cSimbolo = new GridColumn();
            cSimbolo.FieldName = "Simbolo";
            cSimbolo.Caption = "SIM";
            cSimbolo.Width = 16;
            cSimbolo.Visible = true;

            GridColumn cBorrar = new GridColumn();
            cBorrar.FieldName = "FNBorrar";
            cBorrar.Caption = " ";
            cBorrar.Width = 16;
            cBorrar.Visible = true;

            GridColumn cModificar = new GridColumn();
            cModificar.FieldName = "FNModificar";
            cModificar.Caption = " ";
            cModificar.Width = 16;
            cModificar.Visible = true;

            gvItems.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cCertifica, cSimbolo,cBorrar, cModificar });
            gcItems.DataSource = items;

            RepositoryItemButtonEdit botonBorrar = new RepositoryItemButtonEdit();
            botonBorrar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonBorrar.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonBorrar.Buttons[0].Image = Properties.Resources.clear_16x16;
            gcItems.RepositoryItems.Add(botonBorrar);
            gvItems.Columns["FNBorrar"].ColumnEdit = botonBorrar;

            botonBorrar.ButtonClick += (sender, e) =>
            {
                ButtonEdit buttonEdit = sender as ButtonEdit;
                if (buttonEdit != null && e.Button.Index == 0)
                {
                    GridView gridView = gvItems;
                    if (gridView != null)
                    {
                        int rowIndex = gridView.FocusedRowHandle;
                        var pi = gridView.GetRow(rowIndex) as ProtocoloItem;
                        if (pi != null)
                        {
                            protocoloItemSeleccionado.Id = pi.Id;
                            protocoloItemSeleccionado.Nombre = pi.Nombre;
                            confirmar = "DELETEITEM";
                            gcConfirmar.Visible = true;
                            gcConfirmar.Size = new Size(388, 137);
                            tlpNoti.Visible = true;
                            lblNombreVentana.Text = "Borrar ítem: " + protocoloItemSeleccionado.Nombre;
                            lblTitulo.Text = "Esta a punto de borrar un ítem";
                            lblMensaje.Text = "Esto afectara a todos los protocolos relacionados con dicho ítem";
                        }
                    }
                }
            };

            RepositoryItemButtonEdit botonModificar = new RepositoryItemButtonEdit();
            botonModificar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonModificar.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonModificar.Buttons[0].Image = Properties.Resources.editname_16x16;
            gcItems.RepositoryItems.Add(botonModificar);
            gvItems.Columns["FNModificar"].ColumnEdit = botonModificar;
            botonModificar.ButtonClick += (sender, e) =>
            {
                ButtonEdit buttonEdit = sender as ButtonEdit;
                if (buttonEdit != null && e.Button.Index == 0)
                {
                    GridView gridView = gvItems;
                    if (gridView != null)
                    {
                        int rowIndex = gridView.FocusedRowHandle;
                        var pi = gridView.GetRow(rowIndex) as ProtocoloItem;
                        if (pi != null)
                        {
                            protocoloItemSeleccionado.Id = pi.Id;
                            protocoloItemSeleccionado.Nombre = pi.Nombre;
                            confirmar = "UPDATEITEM";
                            cbMantener.Visible = true;
                            protocoloItemSeleccionado = pi;
                            gcAgregarItem.Visible = true;
                            tbNombre.Texts = protocoloItemSeleccionado.Nombre;
                            cbCertificado.Checked = protocoloItemSeleccionado.EsCertificado;
                            cbConstante.Checked = protocoloItemSeleccionado.EsConstante;
                            lueItemUnidades.ItemIndex = BuscarUnidadIndex(protocoloItemSeleccionado.Medida);
                        }
                    }
                }
            };
        }
        private int BuscarUnidadIndex(string medida)
        {
            var dataSource = lueItemUnidades.Properties.DataSource as List<Unidad>;
            if (dataSource != null)
            {
                var index = dataSource.FindIndex(e => medida == e.Nombre);
                return index != -1 ? index : 0;
            }
            return 0;
        }

        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrarConfirmar_Click(object sender, EventArgs e)
        {
            gcConfirmar.Visible = false;
            GetItems();
            gcConfirmar.Size = new Size(388, 73);
            tlpNoti.Visible = false;
        }

        private void btnCerrarAgregar_Click(object sender, EventArgs e)
        {
            gcAgregarItem.Visible = false;

        }

        private void btnMostrarAgregarItem_Click(object sender, EventArgs e)
        {
            cbMantener.Visible = false;
            cbMantener.Checked = false;
            gcAgregarItem.Visible = true;
        }

        private bool ValidarFormularioItems()
        {
            if (!Utils.IsSoloLetrasMultipleEspacios(tbNombre.Texts))
            {
                MostrarNotificacion("Debe introducir nombre de control");
                tbNombre.Focus();
                return false;
            }
            else piAgregar.Nombre = tbNombre.Texts;

            if (!cbConstante.Checked)
            {
                var lueSimboloA = lueItemSimbolos.GetSelectedDataRow() as Simbolo;
                if (lueSimboloA == null)
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Debe seleccionar símbolo.");
                    noti.Show();
                    lueItemSimbolos.Focus();
                    return false;
                }
                else piAgregar.Simbolo = lueSimboloA.Caracter;
                var lueUnidadA = lueItemUnidades.GetSelectedDataRow() as Unidad;
                if (lueUnidadA == null)
                {
                    MostrarNotificacion("Debe seleccionar Unidad.");
                    lueItemUnidades.Focus();
                    return false;
                }
                else piAgregar.Medida = lueUnidadA.Nombre;                
                var lueProcesoA = lueItemProcesos.GetSelectedDataRow() as string;
                if (lueProcesoA == null)
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Debe seleccionar proceso.");
                    noti.Show();
                    lueItemProcesos.Focus();
                    return false;
                }
                else piAgregar.Proceso = lueProcesoA;
            }
            return true;
        }
        private void MostrarNotificacion(string mensaje)
        {
            formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", mensaje);
            noti.Show();
        }

        ProtocoloItem piAgregar = new ProtocoloItem();

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioItems()) return;
            piAgregar.EsCertificado = cbCertificado.Checked;
            if (cbConstante.Checked) piAgregar.Simbolo = "C";
            piAgregar.EsConstante = cbConstante.Checked;
            if (Form1.instancia.br.AgregarItem(piAgregar))
            {
                LimpiarFormularioAgregarItem();
                formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se agrego correctamente un nuevo item: " + piAgregar.Nombre);
                GetItems();
                noti.Show();
            }
        }
        private void LimpiarFormularioAgregarItem()
        {
            tbNombre.Texts = string.Empty;
            lueItemUnidades.Text = string.Empty;
            lueItemSimbolos.Text = string.Empty;
            lueItemProcesos.Text = string.Empty;
            cbCertificado.Checked = false;
            cbConstante.Checked = false;
        }
    }
}
