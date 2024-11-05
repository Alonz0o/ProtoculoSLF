using ProtoculoSLF.Model;
using ProtoculoSLF.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProtoculoSLF
{
    public partial class formAsignarItemProtocolo : Form
    {
        public List<ProtocoloItem> items = new List<ProtocoloItem>();
        public static formAsignarItemProtocolo instancia;

        public formAsignarItemProtocolo()
        {
            InitializeComponent();
            instancia = this;
            Deactivate += (s, e) => Close();
        }
        private void formAsignarItemProtocolo_Load(object sender, EventArgs e)
        {
            GetItems();
            lueNombreItem.Properties.DataSource = items;
            lblTitulo.Text = "Agregando un ítem especificado para: " + Form1.instancia.idCodigoSeleccionado;
        }

        private void GetItems()
        {

            items = Form1.instancia.br.GetItemsDelProtocoloNUEVO(Form1.instancia.idProtocoloSeleccionado);

            //var itemsDiferentes = items
            //    .Concat(Form1.instancia.protocoItems)
            //    .GroupBy(x => x.Id)
            //    .Where(g => g.Count() == 1)
            //    .Select(g => g.First())
            //    .ToList();

        }
            ProtocoloItem itemAgregar = new ProtocoloItem();

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            ValidarFormularioItems();
            itemAgregar.Nombre = lueNombreItem.Text;
            var lueControlA = lueNombreItem.GetSelectedDataRow() as ProtocoloItem;
            itemAgregar.Id = lueControlA.Id;
            itemAgregar.IdProtocolo = Form1.instancia.idProtocoloSeleccionado;
            itemAgregar.IdProtocoloItem = lueControlA.IdProtocoloItem;

            

            if (Form1.instancia.br.AgregarItemProtocolo(itemAgregar,Form1.instancia.idCodigoSeleccionado))
            {
                LimpiarFormularioAgregarItem();
                formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se agrego correctamente un nuevo item: " + itemAgregar.Nombre);
                noti.Show();
                Form1.instancia.GetProtocoloItems();
            }

        }

        private bool ValidarFormularioItems()
        {
            //VERIFICAR SIMBOLO
            var lueNombreA = lueNombreItem.GetSelectedDataRow() as ProtocoloItem;
            if (lueNombreA == null)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Debe seleccionar control.");
                noti.Show();
                lueNombreItem.Focus();
                return false;
            }

            if (tableLayoutPanel1.ColumnStyles[1].Width != 0) {
                if (tbEspMed.Texts == string.Empty)
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero de Especificación.");
                    noti.Show();
                    tbEspMed.Focus();
                    return false;
                }

                if (tbEspMed.Texts.Contains(".")) tbEspMed.Texts = tbEspMed.Texts.Replace('.', ','); ;

                if (!Utils.IsSoloNumODecimal(tbEspMed.Texts))
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
                    noti.Show();
                    tbEspMed.Focus();
                    return false;
                }
                else itemAgregar.Especificacion = Convert.ToDouble(tbEspMed.Texts);
            }
            if (tableLayoutPanel1.ColumnStyles[0].Width != 0)
            {
                if (tbEspMin.Texts == string.Empty)
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero de Especificación.");
                    noti.Show();
                    tbEspMed.Focus();
                    return false;
                }

                if (tbEspMin.Texts.Contains(".")) tbEspMin.Texts = tbEspMin.Texts.Replace('.', ','); ;

                if (!Utils.IsSoloNumODecimal(tbEspMin.Texts))
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
                    noti.Show();
                    tbEspMin.Focus();
                    return false;
                }else itemAgregar.EspecificacionMin = Convert.ToDouble(tbEspMin.Texts);
            }
            if (tableLayoutPanel1.ColumnStyles[2].Width != 0)
            {
                if (tbEspMax.Texts == string.Empty)
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero de Especificación.");
                    noti.Show();
                    tbEspMed.Focus();
                    return false;
                }

                if (tbEspMax.Texts.Contains(".")) tbEspMax.Texts = tbEspMax.Texts.Replace('.', ','); ;

                if (!Utils.IsSoloNumODecimal(tbEspMax.Texts))
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
                    noti.Show();
                    tbEspMax.Focus();
                    return false;
                }else itemAgregar.EspecificacionMax = Convert.ToDouble(tbEspMax.Texts);
            }
            //VERIFICAR NUMERO MIN
            if (tbSimboloSignificado.Texts == string.Empty)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Asignar Ítem", "Debe ingresar numero: "+ gcSimboloSignificado.Text+".");
                noti.Show();
                tbSimboloSignificado.Focus();
                return false;
            }

            if (tbSimboloSignificado.Texts.Contains(".")) tbSimboloSignificado.Texts = tbSimboloSignificado.Texts.Replace('.', ','); ;
            if (!Utils.IsSoloNumODecimal(tbSimboloSignificado.Texts))
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Deben ser numeros enteros o decimales separados por coma (,).");
                noti.Show();
                tbSimboloSignificado.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormularioAgregarItem()
        {
            lueNombreItem.Text = string.Empty;
            tbSimboloSignificado.Texts = string.Empty;
        }

        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lueNombreItem_EditValueChanged(object sender, EventArgs e)
        {
            Especificacion datosDeFicha = new Especificacion();
            var lueControlA = lueNombreItem.GetSelectedDataRow() as ProtocoloItem;
            if (lueControlA == null) return;
            if (lueControlA.Simbolo == "±")
            {
                gcSimboloSignificado.Text = "  Significado de símbolo (±)";
                tbSimboloSignificado.Texts = "(Más o menos) Se debe colocar especificación media y la tolerancia mínima y máxima.";
                tableLayoutPanel1.ColumnStyles[0].Width = 50F;
                tableLayoutPanel1.ColumnStyles[1].Width = 50F;
                tableLayoutPanel1.ColumnStyles[2].Width = 50F;

                if (lueControlA.Nombre.ToLower().Contains("ancho") && lueControlA.Nombre.ToLower().Contains("bolsa"))
                {
                    datosDeFicha = Form1.instancia.br.GetFichaLogisticaConfeccionAncho(Form1.instancia.idCodigoSeleccionado);
                    tbEspMed.Texts = datosDeFicha.Medio.ToString();
                    tbEspMin.Texts = datosDeFicha.Minimo.ToString();
                    tbEspMax.Texts = datosDeFicha.Maximo.ToString();

                }

                if (lueControlA.Nombre.ToLower().Contains("largo") && lueControlA.Nombre.ToLower().Contains("bolsa"))
                {
                    datosDeFicha = Form1.instancia.br.GetFichaLogisticaConfeccionLargo(Form1.instancia.idCodigoSeleccionado);
                    tbEspMed.Texts = datosDeFicha.Medio.ToString();
                    tbEspMin.Texts = datosDeFicha.Minimo.ToString();
                    tbEspMax.Texts = datosDeFicha.Maximo.ToString();

                }
                if (lueControlA.Nombre.ToLower().Equals("espesor confección"))
                {
                    datosDeFicha = Form1.instancia.br.GetFichaLogisticaConfeccionEspesor(Form1.instancia.idCodigoSeleccionado);
                    tbEspMed.Texts = datosDeFicha.Medio.ToString();
                    tbEspMin.Texts = datosDeFicha.Minimo.ToString();
                    tbEspMax.Texts = datosDeFicha.Maximo.ToString();

                }
                 
            }
            if (lueControlA.Simbolo == "-")
            {
                gcSimboloSignificado.Text = "  Significado de símbolo (-)";
                tbSimboloSignificado.Texts = "(Entre A y B) Se debe colocar solo tolerancia mínima y máxima.";
                tableLayoutPanel1.ColumnStyles[0].Width = 50F;
                tableLayoutPanel1.ColumnStyles[1].Width = 0F;
                tableLayoutPanel1.ColumnStyles[2].Width = 50F;

            }
            if (lueControlA.Simbolo == ">")
            {
                gcSimboloSignificado.Text = "  Significado de símbolo (>)";
                tbSimboloSignificado.Texts = "(Mayor que) Se debe colocar solo tolerancia máxima.";
                tableLayoutPanel1.ColumnStyles[0].Width = 0F;
                tableLayoutPanel1.ColumnStyles[1].Width = 0F;
                tableLayoutPanel1.ColumnStyles[2].Width = 100F;
            }
            if (lueControlA.Simbolo == "<")
            {
                gcSimboloSignificado.Text = "  Significado de símbolo (<)";
                tbSimboloSignificado.Texts = "(Menor que) Se debe colocar solo tolerancia mínima.";
                tableLayoutPanel1.ColumnStyles[0].Width = 100F;
                tableLayoutPanel1.ColumnStyles[1].Width = 0F;
                tableLayoutPanel1.ColumnStyles[2].Width = 0F;
            }


        }
    }
}
