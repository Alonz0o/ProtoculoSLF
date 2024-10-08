using DevExpress.XtraReports.UI;
using ProtoculoSLF.Model;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ProtoculoSLF.Report
{
    public partial class xrProtocoloCertificado : XtraReport
    {
        public xrProtocoloCertificado()
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
                Weight = 1.457650306576588D
            };
            row.Cells.Add(cell1);

            XRTableCell cell2 = new XRTableCell
            {
                Text = "datosCodigoExt.",
                Dpi = 100F,
                Weight = 0.80191260165855527D
            };
            row.Cells.Add(cell2);

            XRTableCell cell3 = new XRTableCell
            {
                Text = "datosCodigoEx()",
                Dpi = 100F,            
                Weight = 1.0478141409451847D
            };
            row.Cells.Add(cell3);

            XRTableCell cell4 = new XRTableCell
            {
                Text = datosCodigoExt.ValorEnsayo+"",
                Dpi = 100F,
                Weight = 0.69262295081967218D
            };
            row.Cells.Add(cell4);

            xrTablaEnsayos.Rows.Add(row);
        }
    }
}
