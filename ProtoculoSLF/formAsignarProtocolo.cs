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
        }

        private void formAsignarProtocolo_Load(object sender, EventArgs e)
        {
            lueTipo.Properties.DataSource = Form1.instancia.br.GetFormatosProtocolos().OrderByDescending(d => d.Fecha);
            lueTipo.Properties.PopulateColumns();
            lueTipo.Properties.Columns[0].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lueTipo.Text!="") {
                if (Form1.instancia.br.ModificarNtIdProtocolo(idNt, Convert.ToInt32(lueTipo.Text))) {
                    Form1.instancia.EsModificadoNtProtocolo = true;
                    Form1.instancia.nts.FirstOrDefault(n => n.Id == idNt).IdProtocolo = Convert.ToInt32(lueTipo.Text);

                    Close();
                }

            }
        }
    }
}
