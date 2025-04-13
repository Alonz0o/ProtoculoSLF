using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ProtoculoSLF.Model;
using ProtoculoSLF.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProtoculoSLF
{
    public partial class formDeleteUpdateItem : Form
    {
        List<ProtocoloEnsayo> protocoloEnsayos = new List<ProtocoloEnsayo>();
        ProtocoloEnsayo pi = new ProtocoloEnsayo();

        string confirmar="";
        ProtocoloEnsayo ensayoItemSeleccionado = new ProtocoloEnsayo();
        public formDeleteUpdateItem(List<ProtocoloEnsayo> protocoloEnsayo,ProtocoloEnsayo pi)
        {

            InitializeComponent();
            this.protocoloEnsayos = protocoloEnsayo;
            this.pi = pi;
            gcBMEnsayo.Text = "  Ensayos de Ítem: " + pi.Nombre;
            lueEnsayoNombre.Properties.DataSource = Form1.instancia.br.GetProtocolosItemsEspecificacionPorCodigo(Form1.instancia.protocoloSeleccionado.Id);
            //Deactivate += (s, e) => Close();
            GenerarTablaItems();
        }

        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            gcConfirmar.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gcAgregarItem.Visible = false;

        }

        private void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            if (confirmar == "UPDATEITEM")
            {
                ProtocoloEnsayo pi = new ProtocoloEnsayo();
                pi.Id = ensayoItemSeleccionado.Id;
                pi.ValorEnsayo = tbValorEnsayo.Texts;
                pi.Correcto = Convert.ToInt32(cbCertificado.Checked);
                var lueCaracterA = lueEnsayoNombre.GetSelectedDataRow() as ProtocoloItem;

                if (Form1.instancia.br.UpdateEnsayo(pi))
                {
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se modifico correctamente el ensayo: " + ensayoItemSeleccionado.Nombre);
                    noti.Show();
                    gcConfirmar.Visible = false;
                    GetEnsayos();
                    Form1.instancia.GetEnsayosRealizados();
                    LimpiarFormularioEnsayo();
                }
            }

            if (confirmar == "DELETEITEM")
            {

                if (Form1.instancia.br.DeleteEnsayo(ensayoItemSeleccionado.Id))
                {
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se borro correctamente el ensayo: " + ensayoItemSeleccionado.Nombre);
                    noti.Show();
                    gcConfirmar.Visible = false;
                    Form1.instancia.GetEnsayosRealizadosPorLote(1, 3);
                    GetEnsayos();
                }
            }
        }

        private void GetEnsayos()
        {
            protocoloEnsayos = Form1.instancia.protocoloEnsayos;
            gcItems.DataSource = protocoloEnsayos;
        }

        private void LimpiarFormularioEnsayo()
        {
            tbValorEnsayo.Texts = string.Empty;
            lueEnsayoNombre.Text = string.Empty;
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioEnsayo()) return;
            if (confirmar == "UPDATEITEM")
            {
                gcAgregarItem.Visible = false;
                gcConfirmar.Size = new Size(388, 137);
                tlpNoti.Visible = true;
                lblNombreVentana.Text = "Modificar ítem: " + ensayoItemSeleccionado.Nombre;
                lblTitulo.Text = "Esta a punto de modificar un ítem";
                lblMensaje.Text = "Esto afectara a todos los protocolos relacionados con dicho ítem";
                gcConfirmar.Visible = true;
            }
        }

        private bool ValidarFormularioEnsayo()
        {
            //VERIFICAR SIMBOLO
            var lueNombreA = lueEnsayoNombre.GetSelectedDataRow() as ProtocoloItem;
            if (lueNombreA == null)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Modificar ensayo", "Debe seleccionar control.");
                noti.Show();
                lueEnsayoNombre.Focus();
                return false;
            }
            //VERIFICAR NUMERO MIN
            if (tbValorEnsayo.Texts == string.Empty)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero." );
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
            return true;
        }
        private int BuscarNombreIndex(string nombre)
        {
            var dataSource = lueEnsayoNombre.Properties.DataSource as List<ProtocoloItem>;
            if (dataSource != null)
            {
                var index = dataSource.FindIndex(e => nombre == e.Nombre);
                return index != -1 ? index : 0;
            }
            return 0;
        }

        private void GenerarTablaItems()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "Item";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cValor = new GridColumn();
            cValor.FieldName = "ValorEnsayo";
            cValor.Caption = "Valor";
            cValor.UnboundDataType = typeof(double);
            cValor.Visible = true;
            cValor.OptionsColumn.AllowEdit = false;

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

            gvItems.Columns.AddRange(new GridColumn[] { cId, cValor, cBorrar, cModificar });
            gcItems.DataSource = protocoloEnsayos;

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
                        var pi = gridView.GetRow(rowIndex) as ProtocoloEnsayo;
                        if (pi != null)
                        {
                            ensayoItemSeleccionado.Id = pi.Id;
                            ensayoItemSeleccionado.Nombre = pi.Nombre;
                            confirmar = "DELETEITEM";
                            gcConfirmar.Visible = true;
                            gcConfirmar.Size = new Size(388, 137);
                            tlpNoti.Visible = true;
                            lblNombreVentana.Text = "Borrar ensayo: " + ensayoItemSeleccionado.Nombre;
                            lblTitulo.Text = "Esta a punto de borrar un ensayo";
                            lblMensaje.Text = "Esto afectara al resultado de todos los protocolos relacionados con dicho ensayo";
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
                        var pe = gridView.GetRow(rowIndex) as ProtocoloEnsayo;
                        if (pe != null)
                        {
                            ensayoItemSeleccionado = pe;
                            ensayoItemSeleccionado.Nombre = pi.Nombre;
                            confirmar = "UPDATEITEM";
                            //MODIFICAR ITEM FORM
                            //VER SACAR SI ES POSIBLE
                            gcAgregarItem.Visible = true;
                            tbValorEnsayo.Texts = ensayoItemSeleccionado.ValorEnsayo;
                            lueEnsayoNombre.ItemIndex = BuscarNombreIndex(ensayoItemSeleccionado.Nombre);
                        }
                    }
                }
            };
        }
    }
}
