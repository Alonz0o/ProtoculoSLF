using DevExpress.XtraReports.UI;
using ProtoculoSLF.Model;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace ProtoculoSLF.Report
{
    public partial class xrCertificadoReal : XtraReport
    {
        public xrCertificadoReal()
        {
            InitializeComponent();
            if (Form1.instancia.protocoloEnsayos.Count != 0)
            {
                xrTablaEnsayos.BeginInit();
                foreach (var item in Form1.instancia.protocoloEnsayos)
                {
                    if(item!=null)AgregarFilaProceso(item);
                }
                 xrTablaEnsayos.EndInit();
                var datos = Form1.instancia.datosReporte;
                var disposicion = Form1.instancia.protocoloSeleccionado.Disposicion;
                //var pp = Form1.instancia.br.GetOrderCompra(Convert.ToInt32(datos.Lote), Form1.instancia.protocoloSeleccionado.Id);
                if (disposicion == 1)
                {

                }
                else {
                    xrTableCell5.Visible = true;
                    xrDatoPallet.Visible = true;
                    xrDatoPallet.Text = datos.Pallet.ToString();
                }
                xrDatoLote.Text = datos.Lote;
                xrDatoCliente.Text = datos.Cliente;
                xrDatoProducto.Text = Form1.instancia.protocoloSeleccionado.Descripcion;
                xrDatoCantidad.Text = datos.Cantidad.ToString();
                xrDatoFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                xrDatoCodigoCliente.Text = datos.CodigoCliente;
                xrDatoRemitoN.Text= datos.Remito.ToString();
                //xrDatoOCN.Text = pp.ToString();
                if (fueraTolen) {
                    xrLblEstado.Text = "EN CONSTRUCCIÓN";
                    xrLblEstado.Visible = true;
                }
            }
        }
        bool fueraTolen = false;
        private void AgregarFilaProceso(ProtocoloEnsayo pes)
        {
            double espMin = 0.0;
            double espMax = 0.0;
            double tolerancia = 0.0;

            if (!pes.EsConstante) {
                tolerancia = Convert.ToDouble(pes.ValorEnsayo);
                espMin = pes.Especificacion - pes.EspecificacionMin;
                espMax = pes.Especificacion + pes.EspecificacionMax;
                if (tolerancia >= espMin && tolerancia <= espMax)
                {

                }
                else fueraTolen = true;
            }
         

            XRTableRow row = new XRTableRow
            {
                Dpi = 100F,
                Weight = 1D,
                BackColor = (tolerancia >= espMin && tolerancia <= espMax) ? Color.White : Color.FromArgb(176, 0, 32),
                ForeColor = (tolerancia >= espMin && tolerancia <= espMax) ? Color.Black : Color.White
            };

            XRTableCell cell1 = new XRTableCell
            {
                Text = pes.Nombre.ToUpper(),
                Dpi = 100F,
                Weight = 1.4969318327356558D,
                Font = new DevExpress.Drawing.DXFont("Calibri", 10.75F)
            };
            row.Cells.Add(cell1);
            var EspecificacionDato = pes.Simbolo == "-" ? pes.EspecificacionMin + " - " + pes.EspecificacionMax : pes.Simbolo == "C" ? "PASS/FAIL" : pes.Especificacion + " " + pes.Simbolo + " " + pes.EspecificacionMax;

            XRTableCell cell2 = new XRTableCell
            {
                Text = EspecificacionDato,
                Dpi = 100F,
                Weight = 1.0552150038422132D,
                Font = new DevExpress.Drawing.DXFont("Calibri", 10.75F)
            };
            row.Cells.Add(cell2);

            XRTableCell cell3 = new XRTableCell
            {
                Text = Math.Round(Convert.ToDouble(pes.ValorEnsayo),2).ToString(),
                Dpi = 100F,
                Weight = 0.94703189036885238D,
                Font = new DevExpress.Drawing.DXFont("Calibri", 10.75F),
              
            };
            row.Cells.Add(cell3);

            XRTableCell cell4 = new XRTableCell
            {
                Text = pes.Unidad,
                Dpi = 100F,
                Weight = 0.50082127305327861D,
                Font = new DevExpress.Drawing.DXFont("Calibri", 10.75F)
            };
            row.Cells.Add(cell4);
            if (Form1.instancia.protocoloEnsayos.LastOrDefault() == pes) {
                row.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            }
            if (Form1.instancia.protocoloEnsayos.FirstOrDefault() == pes)
            {
                row.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            }
            xrTablaEnsayos.Rows.Add(row);
        }
    }
}
