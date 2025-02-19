﻿using DevExpress.XtraReports.UI;
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
                foreach (var item in Form1.instancia.protocoloEnsayos)
                {
                    if(item!=null)AgregarFilaProceso(item);
                }
                
                var datos = Form1.instancia.datosReporte;
                var disposicion = Form1.instancia.disposicion;
                xrDatoLote.Text = datos.Lote;
                xrDatoCliente.Text = datos.Cliente;
                xrDatoProducto.Text = datos.Producto;
                xrDatoCantidad.Text = datos.Cantidad.ToString();
                xrDatoFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                xrDatoPallet.Text = disposicion == 1 ? "Lote": datos.Pallet.ToString();
                xrTableCell5.Text = disposicion == 1 ? "" : "PALLET:";
                xrDatoCodigoCliente.Text = datos.CodigoCliente;
                xrDatoRemitoN.Text= datos.Remito.ToString();
                xrDatoOCN.Text = datos.OrdenDeCompra.ToString();
                if (xrDatoRemitoN.Text == "0") {
                    xrLblEstado.Text = "EN CONSTRUCCIÓN";
                    xrLblEstado.Visible = true;
                }
            }
        }
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
                    xrLblEstado.Text = "FUERA DE TOLERANCIA";
                    xrLblEstado.Visible = true;
                }
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
                Text = pes.Nombre,
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
                Text = pes.ValorEnsayo,
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
            xrTablaEnsayos.Rows.Add(row);
        }
    }
}
