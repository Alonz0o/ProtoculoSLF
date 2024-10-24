﻿using DevExpress.Data;
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

            lueItemSimbolos.Properties.DataSource = simbolos;
            lueNombreItem.Properties.DataSource = Form1.instancia.br.GetItems();

        }


        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            ValidarFormularioItems();
            ProtocoloItem pi = new ProtocoloItem();
            pi.Nombre = lueNombreItem.Text;
            var lueControlA = lueNombreItem.GetSelectedDataRow() as ProtocoloItem;
            pi.Id = lueControlA.Id;
            pi.IdProtocolo = Form1.instancia.idProtocoloSeleccionado;
            var lueCaracterA = lueItemSimbolos.GetSelectedDataRow() as Simbolo;

            pi.Simbolo = lueCaracterA.Caracter;
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

            if (Form1.instancia.br.AgregarItemProtocolo(pi))
            {
                LimpiarFormularioAgregarItem();
                formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se agrego correctamente un nuevo item: " + pi.Nombre);
                noti.Show();
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

            return true;
        }

        private void LimpiarFormularioAgregarItem()
        {
            lueNombreItem.Text = string.Empty;
            tbEspecificacion.Texts = string.Empty;
            tbEsp01.Texts = string.Empty;
            lueItemSimbolos.Text = string.Empty;
        }

        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Close();
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
