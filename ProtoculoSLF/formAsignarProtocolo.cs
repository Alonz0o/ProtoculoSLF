using DevExpress.XtraEditors;
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
    public partial class formAsignarProtocolo : Form
    {
        int idNt = 0;
        public formAsignarProtocolo(int idNt)
        {
            InitializeComponent();
            this.idNt = idNt;
            Deactivate += (s, e) => Close();

        }

        private void formAsignarProtocolo_Load(object sender, EventArgs e)
        {
            lueProtocolo.Properties.DataSource = Form1.instancia.br.GetFormatosProtocolos().OrderByDescending(d => d.Fecha);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var lueProtocoloA = lueProtocolo.GetSelectedDataRow() as Protocolo;
            if (lueProtocoloA == null)
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Protocolo","Debe seleccionar algún protocolo.");
                noti.Show();
                lueProtocolo.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(lueProtocoloA.Id.ToString()))
            {
                if (Form1.instancia.br.ModificarNtIdProtocolo(idNt, lueProtocoloA.FormatoProtocolo))
                {
                    Form1.instancia.EsModificadoNtProtocolo = true;
                    Form1.instancia.nts.FirstOrDefault(n => n.Id == idNt).IdProtocolo = lueProtocoloA.FormatoProtocolo;
                    Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
