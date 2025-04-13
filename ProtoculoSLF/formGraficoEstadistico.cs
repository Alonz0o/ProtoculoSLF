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
using System.Windows.Forms.DataVisualization.Charting;

namespace ProtoculoSLF
{
    public partial class formGraficoEstadistico : Form
    {
        List<ProtocoloEnsayo> pes = new List<ProtocoloEnsayo>();
        public formGraficoEstadistico(List<ProtocoloEnsayo> pes)
        {
            InitializeComponent();
            this.pes = pes;
            CrearGrafico();
        }
        private void CrearGrafico()
        {
            double espMin = 0.0;
            double espMax = 0.0;

            espMin = pes.FirstOrDefault().Especificacion - pes.FirstOrDefault().EspecificacionMin;
            espMax = pes.FirstOrDefault().Especificacion + pes.FirstOrDefault().EspecificacionMax;

            var menoresEspecificacion = (from a in pes
                                         where Convert.ToInt32(a.ValorEnsayo) < espMin
                                         select new
                                         {
                                             valorMenor = Convert.ToDouble(a.ValorEnsayo)
                                         }).ToList();
            var igualesEspecificacion = (from a in pes
                                         where Convert.ToInt32(a.ValorEnsayo) >= espMin && Convert.ToInt32(a.ValorEnsayo) <= espMax
                                         select new
                                         {
                                             valorMedio = Convert.ToDouble(a.ValorEnsayo)
                                         }).ToList();
            var mayoresEspecificacion = (from a in pes
                                         where Convert.ToInt32(a.ValorEnsayo) > espMax
                                         select new
                                         {
                                             valorMayor = Convert.ToDouble(a.ValorEnsayo)
                                         }).ToList();

            Title titulo = new Title();
            titulo.Text = pes[0].Nombre + " | ensayos realizados: " + pes.Count;
            Chart chart = new Chart
            {
                Dock = DockStyle.Fill
            };
            chart.Titles.Add(titulo);
            ChartArea chartArea = new ChartArea();
            chartArea.AxisY.Minimum = espMin - 20;
            chartArea.AxisY.Maximum = espMax + 20;
            chartArea.AxisX.Enabled = AxisEnabled.False;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas.Add(chartArea);

            Series lineaMaximo = new Series
            {
                BorderDashStyle = ChartDashStyle.Dash,
                MarkerBorderColor = Color.Black,
                LabelForeColor = Color.Yellow,
                LabelBackColor = Color.CornflowerBlue,
                MarkerColor = Color.Yellow,
                MarkerSize = 6,
                ChartType = SeriesChartType.Line,
                Color = Color.Yellow,
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                Name = "Máximo",
                IsValueShownAsLabel = true
            };

            Series lineaMedio = new Series
            {
                BorderDashStyle = ChartDashStyle.Dash,
                LabelForeColor = Color.Green,
                MarkerColor = Color.Green,
                MarkerSize = 6,
                ChartType = SeriesChartType.Line,
                Color = Color.Green,
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                Name = "Medio",
                IsValueShownAsLabel = true
            };

            Series lineaMinimo = new Series
            {
                BorderDashStyle = ChartDashStyle.Dash,
                LabelForeColor = Color.Red,
                MarkerColor = Color.Red,
                MarkerSize = 6,
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                Name = "Mínimo",
                IsValueShownAsLabel = true
            };

            for (int i = 0; i < menoresEspecificacion.Count; i++)
            {
                lineaMaximo.Points.AddXY(i, menoresEspecificacion[i].valorMenor);
            }
            for (int i = 0; i < igualesEspecificacion.Count; i++)
            {
                lineaMedio.Points.AddXY(i, igualesEspecificacion[i].valorMedio);
            }
            for (int i = 0; i < mayoresEspecificacion.Count; i++)
            {
                lineaMinimo.Points.AddXY(i, mayoresEspecificacion[i].valorMayor);
            }

            chart.Series.Add(lineaMaximo);
            chart.Series.Add(lineaMedio);
            chart.Series.Add(lineaMinimo);

            Controls.Add(chart);
        }
    }
}
