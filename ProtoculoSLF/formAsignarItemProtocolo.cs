using DevExpress.Data;
using DevExpress.XtraGauges.Core.Customization;
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

            gvItems.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cCertifica, cEspecificacion });
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
            groupControl2.Visible = true;
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            ProtocoloItem pi = new ProtocoloItem();
            pi.Nombre = tbNombre.Texts;

            if (!Form1.instancia.br.GetNombreItemDuplicado(pi.Nombre.Trim().ToLower())) return;
            if (!cbCaracter.Checked)
            {
                var lueCaracterA = lueItemSimbolos.GetSelectedDataRow() as Simbolo;
                var lueUnidadA = lueItemUnidad.GetSelectedDataRow() as Unidad;
                pi.Simbolo = lueCaracterA.Caracter;
                pi.Medida = lueUnidadA.Nombre;
                if (!string.IsNullOrEmpty(tbEsp02.Texts)) {
                    pi.EspecificacionMin = Convert.ToDouble(tbEsp01.Texts);
                    pi.EspecificacionMax = Convert.ToDouble(tbEsp02.Texts);
                }
                else pi.EspecificacionMax = Convert.ToDouble(tbEsp01.Texts);

                if (!string.IsNullOrEmpty(tbEspecificacion.Texts)) {
                    pi.Especificacion = Convert.ToDouble(tbEspecificacion.Texts);
                }
            }
            else pi.Simbolo = "N";
            //pi.Orden = Convert.ToInt32(tbOrden.Texts);
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
            gvItems.BestFitColumns();

        }

        private void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            groupControl2.Visible = false;
            Form1.instancia.protocoItems.RemoveAll(objB => itemsAConfirmar.Any(objA => objA.Id == objB.Id));
            Form1.instancia.RefrescarDatosGvItemsProtocolo();
            GetItems();
        }

        private void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            int ultimaPosicion = Form1.instancia.br.GetUltimaPosicionProtocoloItem(Form1.instancia.idProtocoloSeleccionado)+1;
            string sqlInsertarProtocoloItem = "INSERT INTO formatoprotocoloa_protocolo_item(id_protocolo,id_item,orden) VALUES ";
            string sqlInsertarProtocoloItem2 = "";

            foreach (var item in itemsAConfirmar) {
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{Form1.instancia.idProtocoloSeleccionado}','{item.Id}','{ultimaPosicion}'),";
                ultimaPosicion++;
            }

            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
            if (Form1.instancia.br.InsertAProtocoloItem(sqlInsertarProtocoloItem)) {
                Form1.instancia.GetProtocoloItems();
                groupControl2.Visible=false;
            }
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
