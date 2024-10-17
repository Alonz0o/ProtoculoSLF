using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGauges.Core.Customization;
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
            List<Simbolo> simbolos = new List<Simbolo> { 
                new Simbolo{ Caracter ="=",Significado="Igual a" },
                new Simbolo{ Caracter ="≠",Significado="Diferente de" },
                new Simbolo{ Caracter ="<",Significado="Menor que" },
                new Simbolo{ Caracter =">",Significado="Mayor que" },
                new Simbolo{ Caracter ="≤",Significado="Menor o igual a" },
                new Simbolo{ Caracter ="≥",Significado="Mayor o igual a" },
                new Simbolo{ Caracter ="±",Significado="Más o menos" },
                new Simbolo{ Caracter ="∓",Significado="Menos o más" },
                new Simbolo{ Caracter ="-",Significado="Entre A y B" },

            };
            List<Unidad> unidades = new List<Unidad> {
                new Unidad{ Nombre="Milimetro", Descripcion="Milimetro" },
                new Unidad{ Nombre="Kg/pulgada", Descripcion="Diferente de" },
                new Unidad{ Nombre="Micron", Descripcion="Micron" },
                new Unidad{ Nombre="NA", Descripcion="No asigar" },
            };
            lueItemSimbolos.Properties.DataSource = simbolos;
            lueItemUnidad.Properties.DataSource = unidades;

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

            GridColumn cEspecificacion = new GridColumn();
            cEspecificacion.FieldName = "EspecificacionDato";
            cEspecificacion.Caption = "Especificación";
            cEspecificacion.Visible = true;
            cEspecificacion.UnboundDataType = typeof(string);
            cEspecificacion.OptionsColumn.AllowEdit = false;

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

            gvItems.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cCertifica, cEspecificacion, cBorrar,cModificar });
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
                        //CONFIRMAR OPERACION
                        //var mensaje = $"¿Desea borrar: {pi.Nombre}?";
                        //if (!ConfirmarMensaje(mensaje)) return;
                        if (pi != null)
                        {
                            //verificar mas tarde si se deben quitar todos los items ya asignados al protocolo
                            //var scrapsAnulados = br.GetScrapPorTX(pi.NTIntermedio).Select(s => s.Id).ToList();
                            //var consultaScraps = GenerarConsultaDeSeleccionarScraps(scrapsAnulados);

                            idItemSeleccionado = pi.Id;
                            nombreItemSeleccionado = pi.Nombre;
                            confirmar = "DELETEITEM";
                            gcConfirmar.Visible = true;
                            gcConfirmar.Size = new Size(388, 137);
                            tlpNoti.Visible = true;
                            lblNombreVentana.Text = "Borrar ítem: " + nombreItemSeleccionado;
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
                            idItemSeleccionado = pi.Id;
                            nombreItemSeleccionado = pi.Nombre;
                            confirmar = "UPDATEITEM";
                            //MODIFICAR ITEM FORM
                            //VER SACAR SI ES POSIBLE
                            cbMantener.Visible = true;
                            protocoloItemSeleccionado = pi;
                            gcAgregarItem.Visible = true;
                            tbNombre.Texts = protocoloItemSeleccionado.Nombre;
                            tbEspecificacion.Texts = protocoloItemSeleccionado.Especificacion + "";
                            tbEsp01.Texts = protocoloItemSeleccionado.EspecificacionMax+"";
                            cbCertificado.Checked = protocoloItemSeleccionado.EsCertificado;
                            lueItemSimbolos.ItemIndex = BuscarSimboloIndex(protocoloItemSeleccionado.Simbolo);
                            lueItemUnidad.ItemIndex = BuscarUnidadIndex(protocoloItemSeleccionado.Medida);
                        }
                    }
                }
            };
        }

        ProtocoloItem protocoloItemSeleccionado = new ProtocoloItem();
        private int BuscarUnidadIndex(string simbolo)
        {
            var dataSource = lueItemUnidad.Properties.DataSource as List<Unidad>;
            if (dataSource != null)
            {
                var index = dataSource.FindIndex(e => simbolo == e.Nombre);
                return index != -1 ? index : 0;
            }
            return 0;
        }
        private int BuscarSimboloIndex(string simbolo)
        {
            var dataSource = lueItemSimbolos.Properties.DataSource as List<Simbolo>;
            if (dataSource != null)
            {
                var index = dataSource.FindIndex(e => simbolo == e.Caracter);
                return index != -1 ? index : 0;
            }
            return 0;
        }

        int idItemSeleccionado = 0;
        string nombreItemSeleccionado = "";
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
            cbMantener.Visible = false;
            cbMantener.Checked = false;
            gcAgregarItem.Visible = true;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gcAgregarItem.Visible = false;

        }

        public void RefrescarDatos()
        {
            gvItems.RefreshData();
            gcConfirmar.Visible = true;
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
           
            if (!ValidarFormularioItems()) return;

            if (confirmar == "UPDATEITEM")
            {
                gcAgregarItem.Visible = false;
                gcConfirmar.Size = new Size(388, 137);
                tlpNoti.Visible = true;
                lblNombreVentana.Text = "Modificar ítem: " + nombreItemSeleccionado;
                lblTitulo.Text = "Esta a punto de modificar un ítem";
                lblMensaje.Text = "Esto afectara a todos los protocolos relacionados con dicho ítem";
                gcConfirmar.Visible = true;
                
            }
            else {

                ProtocoloItem pi = new ProtocoloItem();
                pi.Nombre = tbNombre.Texts;

                if (!Form1.instancia.br.GetNombreItemDuplicado(pi.Nombre.Trim().ToLower())) return;
                if (!cbCaracter.Checked)
                {
                    var lueCaracterA = lueItemSimbolos.GetSelectedDataRow() as Simbolo;
                    var lueUnidadA = lueItemUnidad.GetSelectedDataRow() as Unidad;
                    pi.Simbolo = lueCaracterA.Caracter;
                    pi.Medida = lueUnidadA.Nombre;
                    if (!string.IsNullOrEmpty(tbEsp02.Texts))
                    {
                        pi.EspecificacionMin = Convert.ToDouble(tbEsp01.Texts);
                        pi.EspecificacionMax = Convert.ToDouble(tbEsp02.Texts);
                    }
                    else pi.EspecificacionMax = Convert.ToDouble(tbEsp01.Texts);

                    if (!string.IsNullOrEmpty(tbEspecificacion.Texts))
                    {
                        pi.Especificacion = Convert.ToDouble(tbEspecificacion.Texts);
                    }
                }
                else pi.Simbolo = "N";
                pi.EsCertificado = cbCertificado.Checked;
                if (Form1.instancia.br.AgregarItemProtocolo(pi))
                {
                    GetItems();
                    LimpiarFormularioAgregarItem();
                    gcAgregarItem.Visible = false;
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se agrego correctamente un nuevo item: " + pi.Nombre);
                    noti.Show();
                }

            }


        }

        private bool ValidarFormularioItems()
        {
            if (!Utils.IsSoloLetrasMultipleEspacios(tbNombre.Texts))
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Debe ingresar nombre del ítem.");
                noti.Show();
                tbNombre.Focus();
                return false;
            }

            if (tbEspecificacion.Texts == string.Empty)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero de Especificación.");
                noti.Show();
                tbEspecificacion.Focus();
                return false;
            }

            if (tbEspecificacion.Texts.Contains(".")) tbEspecificacion.Texts = tbEspecificacion.Texts.Replace('.', ','); ;
            
            if (!Utils.IsSoloNumODecimal(tbEspecificacion.Texts))
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
                noti.Show();
                tbEspecificacion.Focus();
                return false;
            }
            //VERIFICAR SIMBOLO
            var lueSimboloA = lueItemSimbolos.GetSelectedDataRow() as Simbolo;
            if (lueSimboloA == null)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Debe seleccionar símbolo.");
                noti.Show();
                lueItemSimbolos.Focus();
                return false;
            }

            //VERIFICAR NUMERO MIN
            if (tbEsp01.Texts == string.Empty)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero: "+ gcSimboloSignificado.Text+".");
                noti.Show();
                tbEsp01.Focus();
                return false;
            }

            if (tbEsp01.Texts.Contains(".")) tbEsp01.Texts = tbEsp01.Texts.Replace('.', ','); ;
            if (!Utils.IsSoloNumODecimal(tbEsp01.Texts))
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
                noti.Show();
                tbEsp01.Focus();
                return false;
            }
            //VERIFICAR MEDIDA
            var lueMedidaA = lueItemUnidad.GetSelectedDataRow() as Unidad;
            if (lueMedidaA == null)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Debe seleccionar Unidad.");
                noti.Show();
                lueItemUnidad.Focus();
                return false;
            }
            return true;
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
            gvItems.BestFitColumns();

        }

        private void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            gcConfirmar.Visible = false;
            Form1.instancia.protocoItems.RemoveAll(objB => itemsAConfirmar.Any(objA => objA.Id == objB.Id));
            Form1.instancia.RefrescarDatosGvItemsProtocolo();
            GetItems();

            //MODIFICAR CANCELAR
            gcConfirmar.Size = new Size(388, 73);
            tlpNoti.Visible = false;
            //lblNombreVentana.Text = "Modificar ítem";
            //lblTitulo.Text = "Esta a punto de modificar un ítem";
            //lblMensaje.Text = "Esto afectara a todos los protocolos relacionados con dicho ítem";
        }
        public string confirmar = "";
        private void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            if (confirmar == "MOVERFILAS")
            {
                int ultimaPosicion = Form1.instancia.br.GetUltimaPosicionProtocoloItem(Form1.instancia.idProtocoloSeleccionado) + 1;
                string sqlInsertarProtocoloItem = "INSERT INTO formatoprotocoloa_protocolo_item(id_protocolo,id_item,orden) VALUES ";
                string sqlInsertarProtocoloItem2 = "";

                foreach (var item in itemsAConfirmar)
                {
                    sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{Form1.instancia.idProtocoloSeleccionado}','{item.Id}','{ultimaPosicion}'),";
                    ultimaPosicion++;
                }

                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
                sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
                if (Form1.instancia.br.InsertAProtocoloItem(sqlInsertarProtocoloItem))
                {
                    Form1.instancia.GetProtocoloItems();
                    gcAgregarItem.Visible = false;
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se agregaron los ítem seleccionados al protocolo: " + Form1.instancia.idProtocoloSeleccionado);
                    noti.Show();
                    gcConfirmar.Visible = false;
                }
                itemsAConfirmar.Clear();

            }


            if (confirmar == "DELETEITEM")
            {

                if (Form1.instancia.br.DeleteItem("NO", idItemSeleccionado))
                {
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se borro correctamente el ítem: " + nombreItemSeleccionado);
                    noti.Show();
                    gcConfirmar.Visible = false;
                    GetItems();
                }
            }

            if (confirmar == "UPDATEITEM")
            {
                ProtocoloItem pi = new ProtocoloItem();
                pi.Id = protocoloItemSeleccionado.Id;
                pi.Nombre = tbNombre.Texts;

                if (!Form1.instancia.br.GetNombreItemDuplicado(pi.Nombre.Trim().ToLower()) && !cbMantener.Checked) {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Ese nombre de control esta en uso.");
                    noti.Show();
                    return;
                }
                if (!cbCaracter.Checked)
                {
                    var lueCaracterA = lueItemSimbolos.GetSelectedDataRow() as Simbolo;
                    var lueUnidadA = lueItemUnidad.GetSelectedDataRow() as Unidad;
                    pi.Simbolo = lueCaracterA.Caracter;
                    pi.Medida = lueUnidadA.Nombre;
                    if (!string.IsNullOrEmpty(tbEsp02.Texts))
                    {
                        pi.EspecificacionMin = Convert.ToDouble(tbEsp01.Texts);
                        pi.EspecificacionMax = Convert.ToDouble(tbEsp02.Texts);
                    }
                    else pi.EspecificacionMax = Convert.ToDouble(tbEsp01.Texts);

                    if (!string.IsNullOrEmpty(tbEspecificacion.Texts))
                    {
                        pi.Especificacion = Convert.ToDouble(tbEspecificacion.Texts);
                    }
                }
                else pi.Simbolo = "N";
                pi.EsCertificado = cbCertificado.Checked;

                if (Form1.instancia.br.UpdateItem("NO", pi))
                {
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se modifico correctamente el ítem: " + nombreItemSeleccionado);
                    noti.Show();
                    gcConfirmar.Visible = false;
                    GetItems();
                    LimpiarFormularioAgregarItem();
                }
            }
        }

        private void LimpiarFormularioAgregarItem()
        {
            tbNombre.Texts = string.Empty;
            tbEspecificacion.Texts = string.Empty;
            tbEsp01.Texts = string.Empty;
            lueItemSimbolos.Text = string.Empty;
            lueItemUnidad.Text = string.Empty;
            cbCaracter.Checked = false;
            cbCertificado.Checked = false;
        }

        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbCaracter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCaracter.Checked)
            {
                tableLayoutPanel7.Visible = false;
                tableLayoutPanel8.Visible = false;
                gcAgregarItem.Height = gcAgregarItem.Height - tableLayoutPanel7.Height;
                gcAgregarItem.Height = gcAgregarItem.Height - tableLayoutPanel8.Height;

            }
            else {
                tableLayoutPanel7.Visible = true;
                tableLayoutPanel8.Visible = true;
                gcAgregarItem.Height = gcAgregarItem.Height + tableLayoutPanel7.Height;
                gcAgregarItem.Height = gcAgregarItem.Height + tableLayoutPanel8.Height;

            }
        }

        private void lueItemSimbolos_EditValueChanged(object sender, EventArgs e)
        {
            var lueSimbolosA = lueItemSimbolos.GetSelectedDataRow() as Simbolo;
            if (lueSimbolosA == null) return;
            gcSimboloSignificado.Text = lueSimbolosA.Significado;
            if (lueSimbolosA.Caracter == "-")
            {
                gcSimboloSignificado.Text = "Entre (A)";
                tableLayoutPanel7.ColumnStyles[0].Width = 0F;
                tableLayoutPanel7.ColumnStyles[1].Width = 100F;

                tableLayoutPanel8.ColumnStyles[0].Width = 50F;
                tableLayoutPanel8.ColumnStyles[1].Width = 50F;
                tableLayoutPanel8.ColumnStyles[2].Width = 50F;
            }
            else {
                tableLayoutPanel7.ColumnStyles[0].Width = 50F;
                tableLayoutPanel7.ColumnStyles[1].Width = 50F;

                tableLayoutPanel8.ColumnStyles[0].Width = 50F;
                tableLayoutPanel8.ColumnStyles[1].Width = 0F;
                tableLayoutPanel8.ColumnStyles[2].Width = 50F;

            }
        }
    }
}
