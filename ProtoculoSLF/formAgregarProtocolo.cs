using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ProtoculoSLF.Model;
using ProtoculoSLF.Repository;
using ScrapKP.AAFControles;
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
    public partial class formAgregarProtocolo : Form
    {
        public List<Protocolo> protocolos = new List<Protocolo>();
        private List<ProtocoloItem> itemsTodos = new List<ProtocoloItem>();
        private List<ProtocoloItem> itemsAsignados = new List<ProtocoloItem>();

        string accion = "";

        public formAgregarProtocolo(string accion)
        {
            this.accion = accion;
            InitializeComponent();

            if (accion == "modificar")
            {
                btnAgregarProtocolo.Text = "Modificar Protocolo";
                tbNumeroProtocolo.Visible = false;
                lueProtocolos.Visible = true;
                groupControl4.Enabled = true;
                lueProtocolos.Properties.DataSource = Form1.instancia.br.GetFormatosProtocolos();
                lblMensaje.Text = "Esta modificando un protocolo";
                gcAgregar.Text = "   Asistente de configuración (MODIFICACION)";
            }
            else {
                idProtocolo = Form1.instancia.br.GetUltimoProtocolo() + 1;
                tbNumeroProtocolo.Texts = idProtocolo.ToString();
                groupControl7.Text = "  Items asignados a protocolo:" + tbNumeroProtocolo.Texts;
              
            }

            GenerarTablaItemsTodos();
            GenerarTablaProtocolos();
            GenerarTablaItemsAsignados();
        }
        private void formAgregarProtocolo_Load(object sender, EventArgs e)
        {
            //if (accion == "modificar")
            //{
            //}
            //else
            //{
                
            //}
            GetCodigosSinProtocolo();
            GetItemsTodos();
        }

        private void GetItemsDelProtocolo(int idProtocolo)
        {
            itemsAsignados = Form1.instancia.br.GetProtocolosItems(idProtocolo);
            gcItemsAsignados.DataSource = itemsAsignados;
        }

        private void GetCodigosSinProtocolo()
        {
            protocolos = Form1.instancia.br.GetClientesSinProtocolo().OrderBy(e=>e.Descripcion).ToList();
            gcCodigos.DataSource = protocolos;
        }
        private void GetItemsTodos()
        {
            itemsTodos = Form1.instancia.br.GetItems();
            gcTodosItems.DataSource = itemsTodos;
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
                            if (accion == "modificar")
                            {
                                itemsAsignados.Remove(pi);
                                gridView.RefreshData();
                                contadorOrden--;
                            }
                            else
                            {
                                protocoItems.Remove(pi);
                                gridView.RefreshData();
                                contadorOrden--;
                            }
                           
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

        }
        private void GenerarTablaProtocolos()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "Codigo";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;
            cId.Visible = true;

            GridColumn cDescripcion = new GridColumn();
            cDescripcion.FieldName = "Descripcion";
            cDescripcion.Caption = "Descripcion";
            cDescripcion.UnboundDataType = typeof(string);
            cDescripcion.Visible = true;
            cDescripcion.OptionsColumn.AllowEdit = false;

            GridColumn cCheck = new GridColumn();
            cCheck.FieldName = "Seleccionar";
            cCheck.Caption = " ";
            cCheck.Visible = true;
            cCheck.UnboundType = UnboundColumnType.Boolean;
            cCheck.Width = 16;

            gvCodigos.Columns.AddRange(new GridColumn[] { cId, cDescripcion, cCheck });

        }

        private void ConfigurarAutocompletar(AAFTextBox textBox, List<string> autoCompletable)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(autoCompletable.ToArray());
            textBox.AutoCompleteCustomSource = collection;
        }

        private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

            }
        }

        private void btnAgregarProtocolo_Click(object sender, EventArgs e)
        {
            if (accion == "modificar")
            {
                if (!ValidarFormularioItems()) return;
                var sqlUpdate = SQLUpdateIdProtocolo();
                var sqlInsert = SQLInsertProtocoloItem();
                if (Form1.instancia.br.InsertAProtocolo(protocoloACrear, sqlUpdate, sqlInsert, "modificar"))
                {
                    Form1.instancia.GetCodigosConProtocolo();
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se modifico correctamente el protocolo: " + protocoloACrear.FormatoProtocolo);
                    noti.Show();
                    Close();
                }
                else MessageBox.Show("ERROR");
            }
            else
            {
                if (!ValidarFormularioItems()) return;
                var sqlUpdate = SQLUpdateIdProtocolo();
                var sqlInsert = SQLInsertProtocoloItem();
                if (Form1.instancia.br.InsertAProtocolo(protocoloACrear, sqlUpdate, sqlInsert,"agregar"))
                {
                    Form1.instancia.GetCodigosConProtocolo();
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se genero correctamente el protocolo: " + protocoloACrear.FormatoProtocolo);
                    noti.Show();
                    Close();
                }
                else MessageBox.Show("ERROR");
            }

        }
        int idProtocolo = 0;
        private string SQLUpdateIdProtocolo()
        {
            List<Protocolo> seleccionados = protocolos.FindAll(ex => ex.Seleccionar == true).ToList();
            if (seleccionados.Count == 0) return "";
            var qry1 = $"UPDATE extrusion SET id_formato_protocolo = {idProtocolo}";
            var qry2 = " WHERE IdCodigo IN (";
            foreach (var s in seleccionados)
            {
                qry2 = qry2 + s.Id + ",";
            }
            qry2 = qry2.TrimEnd(',') + ");";
            qry1 = qry1 + qry2;

            return qry1;
        }
        private string SQLInsertProtocoloItem()
        {
            var borrarDuplicados = Form1.instancia.br.GetProtocolosItems(idProtocolo);
            var items = tbNumeroProtocolo.Visible == true ? protocoItems : itemsAsignados;
            if (borrarDuplicados.Count != 0) {
                var itemsDiferentes = items
                    .Concat(borrarDuplicados)
                    .GroupBy(x => x.Id)
                    .Where(g => g.Count() == 1)
                    .Select(g => g.First())
                    .ToList();
                items = itemsDiferentes;           
            }
            if (items.Count == 0) return "";
            string sqlInsertarProtocoloItem = "INSERT INTO formato_protocolo_item(id_protocolo,id_item,orden) VALUES ";
            string sqlInsertarProtocoloItem2 = "";
            foreach (var item in items)
            {
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{idProtocolo}','{item.Id}','{item.Orden}'),";
            }
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
            return sqlInsertarProtocoloItem;
        }

       

        Protocolo protocoloACrear = new Protocolo();
        private bool ValidarFormularioItems()
        {
            if (accion == "modificar")
            {
                var lueUnidadA = lueProtocolos.GetSelectedDataRow() as Protocolo;
                if (lueUnidadA == null)
                {
                    MostrarNotificacion("Debe seleccionar Protocolo a modificar.");
                    lueProtocolos.Focus();
                    return false;
                }protocoloACrear.FormatoProtocolo = lueUnidadA.FormatoProtocolo;
            }

            if (string.IsNullOrEmpty(tbNombreProtocolo.Texts))
            {
                MostrarNotificacion("Debe introducir nombre del protocolo");
                tbNombreProtocolo.Focus();
                return false;
            }
            else protocoloACrear.Nombre = tbNombreProtocolo.Texts;

            protocoloACrear.Descripcion = tbDescripcionProtocolo.Texts;
            if (rbPorLote.Checked) protocoloACrear.Disposicion = 1;
            if (rbPorPallet.Checked) protocoloACrear.Disposicion = 2;
            if (rbAuditor.Checked) protocoloACrear.Datos = 1;
            if (rbProduccion.Checked) protocoloACrear.Datos = 2;
            if (rbAmbos.Checked) protocoloACrear.Datos = 3;
            return true;
        }
        private void MostrarNotificacion(string mensaje)
        {
            formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", mensaje);
            noti.Show();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        List<ProtocoloItem> protocoItems = new List<ProtocoloItem>();
        int contadorOrden = 1;

        private void gcItemsAsignados_DragDrop(object sender, DragEventArgs e)
        {
            if (accion == "modificar")
            {
                var data = (ProtocoloItem)e.Data.GetData(typeof(ProtocoloItem));
                data.Orden = contadorOrden;
                itemsAsignados.Add(data);
                gvItemsAsignados.RefreshData();
                contadorOrden++;
            }
            else
            {
                var data = (ProtocoloItem)e.Data.GetData(typeof(ProtocoloItem));
                data.Orden = contadorOrden;
                protocoItems.Add(data);
                gvItemsAsignados.RefreshData();
                contadorOrden++;
            }

           
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

        private void lueProtocolos_EditValueChanged(object sender, EventArgs e)
        {
            var lueProtocoloA = lueProtocolos.GetSelectedDataRow() as Protocolo;
            if (lueProtocoloA != null)
            {
                groupControl7.Text = "  Items asignados a protocolo:" + lueProtocoloA.FormatoProtocolo;
                tbNombreProtocolo.Texts = lueProtocoloA.Nombre;
                tbDescripcionProtocolo.Texts = lueProtocoloA.Descripcion;
                if (lueProtocoloA.Disposicion == 1) rbPorLote.Checked = true;
                else rbPorPallet.Checked = true;
                GetItemsDelProtocolo(lueProtocoloA.FormatoProtocolo);
                contadorOrden = gvItemsAsignados.RowCount+1;
                idProtocolo = lueProtocoloA.FormatoProtocolo;
            }
        }
        bool esCheckTx = false;
        int cuentaCodigos = 0;



        private void btnCheckAllRemito_Click_1(object sender, EventArgs e)
        {
            lblTotalSeleccionado.Text = "";

            esCheckTx = !esCheckTx;
            if (esCheckTx)
            {
                cuentaCodigos = gvCodigos.RowCount;
                btnCheckAllRemito.BackgroundImage = Properties.Resources.changelabel_32x32;

                for (int i = 0; i < gvCodigos.RowCount; i++)
                {
                    var idSeleccionado = (int)gvCodigos.GetRowCellValue(i, "Id");
                    var TXEncontrado = protocolos.FirstOrDefault(d => d.Id == idSeleccionado);
                    TXEncontrado.Seleccionar = true;
                }
            }
            else
            {
                cuentaCodigos = 0;
                btnCheckAllRemito.BackgroundImage = Properties.Resources.checkbox2_32x32;
                protocolos.ForEach(s => s.Seleccionar = false);
            }
            lblTotalSeleccionado.Text = cuentaCodigos.ToString();
            gcCodigos.RefreshDataSource();
        }

        private void gvCodigos_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Seleccionar")
            {
                var idSeleccionado = (int)gvCodigos.GetRowCellValue(e.RowHandle, "Id");
                var TXEncontrado = protocolos.FirstOrDefault(d => d.Id == idSeleccionado);
                TXEncontrado.Seleccionar = !TXEncontrado.Seleccionar;
                cuentaCodigos = TXEncontrado.Seleccionar == true ? cuentaCodigos = cuentaCodigos +1 : cuentaCodigos = cuentaCodigos - 1;
                if (cuentaCodigos < 0) cuentaCodigos = 0;
            }
            lblTotalSeleccionado.Text = cuentaCodigos.ToString();
        }
    }
}
