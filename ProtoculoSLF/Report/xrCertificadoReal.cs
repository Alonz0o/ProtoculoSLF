using DevExpress.XtraReports.UI;
using ProtoculoSLF.Model;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ProtoculoSLF.Report
{
    public partial class xrCertificadoReal : DevExpress.XtraReports.UI.XtraReport
    {
        public xrCertificadoReal()
        {
            InitializeComponent();
            if (Form1.instancia.protocoloEnsayos.Count != 0)
            {
                foreach (var item in Form1.instancia.protocoloEnsayos)
                {
                    AgregarFilaProceso(item);
                }
            }
        }
        private void AgregarFilaProceso(ProtocoloEnsayo datosCodigoExt)
        {
            XRTableRow row = new XRTableRow
            {
                Dpi = 100F,
                Weight = 1D
            };

            XRTableCell cell1 = new XRTableCell
            {
                Text = datosCodigoExt.Nombre,
                Dpi = 100F,
                Weight = 1.3333331665706281D
            };
            row.Cells.Add(cell1);

            XRTableCell cell2 = new XRTableCell
            {
                Text = datosCodigoExt.Especificacion + datosCodigoExt.Caracter,
                Dpi = 100F,
                Weight = 0.93989048292911881D
            };
            row.Cells.Add(cell2);

            XRTableCell cell3 = new XRTableCell
            {
                Text = datosCodigoExt.ValorEnsayo + "",
                Dpi = 100F,
                Weight = 0.843531203308789D
            };
            row.Cells.Add(cell3);

            XRTableCell cell4 = new XRTableCell
            {
                Text = datosCodigoExt.Unidad,
                Dpi = 100F,
                Weight = 0.44608638746173584D
            };
            row.Cells.Add(cell4);
            xrTablaEnsayos.Rows.Add(row);
        }
    }
}
