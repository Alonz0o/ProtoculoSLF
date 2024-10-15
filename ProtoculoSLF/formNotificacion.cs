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
    public partial class formNotificacion : Form
    {
        double opacityStep = 0.1;
        Timer tIntervalo01, tVisible, tIntervalo02;
        int duracion10Seg = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;
        int duracion5Seg = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;

        Color success = Color.FromArgb(227, 242, 253);
        Color succesIcon = Color.FromArgb(63, 81, 181);

        Color danger = Color.FromArgb(220, 53, 69);
        Color warning = Color.FromArgb(255, 193, 7);
        Color info = Color.FromArgb(13, 110, 253);

        string tipo, titulo, mensaje;
        public formNotificacion(string tipo, string titulo, string mensaje)
        {
            this.tipo = tipo;
            this.titulo = titulo;
            this.mensaje = mensaje;
            InitializeComponent();
        }
        private void formNotificacion_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;

            lblMensaje.Select();

            switch (tipo)
            {
                case "success":
                    tlpNoti.BackColor = success;
                    gcNotificacion.Appearance.BorderColor = success;
                    pnlLineaVertical.BackColor = success;
                    iconoNotificacion.IconColor = succesIcon;
                    iconoNotificacion.IconChar = FontAwesome.Sharp.IconChar.Check;
                    break;
                case "danger":
                    tlpNoti.BackColor = danger;
                    gcNotificacion.Appearance.BorderColor = danger;
                    pnlLineaVertical.BackColor = danger;
                    iconoNotificacion.IconColor = danger;
                    iconoNotificacion.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
                    break;
                case "warning":
                    tlpNoti.BackColor = warning;
                    gcNotificacion.Appearance.BorderColor = warning;
                    pnlLineaVertical.BackColor = warning;
                    iconoNotificacion.IconColor = warning;
                    iconoNotificacion.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
                    break;
                case "info":
                    tlpNoti.BackColor = info;
                    gcNotificacion.Appearance.BorderColor = info;
                    pnlLineaVertical.BackColor = info;
                    iconoNotificacion.IconColor = info;
                    iconoNotificacion.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
                    break;

                default:
                    break;
            }

            gcNotificacion.Text = titulo;
            lblMensaje.Text = mensaje;

            Rectangle pantalla = Screen.PrimaryScreen.WorkingArea;
            int x = pantalla.Width - Width - 20;
            int y = pantalla.Height - Height - 20;
            Location = new Point(x, y);

            tIntervalo01 = new Timer();
            tIntervalo01.Interval = 10;
            tIntervalo01.Tick += TIntervalo01_Tick;
            tIntervalo01.Start();

            tVisible = new Timer();
            tVisible.Interval = duracion5Seg;
            tVisible.Tick += TiempoMostradoEfecto_Tick;

            tIntervalo02 = new Timer();
            tIntervalo02.Interval = 10;
            tIntervalo02.Tick += TIntervalo02_Tick;
        }
        private async Task MostrarNotificacion()
        {
            while (true)
            {

                if (Opacity < 1) Opacity += opacityStep;
                if (Opacity == 1)
                {
                    tVisible.Start();
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private async Task OcultarNotificacion()
        {
            while (true)
            {
                if (Opacity > 0) Opacity -= opacityStep;
                if (Opacity <= 0)
                {
                    Close();
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private async void TIntervalo01_Tick(object sender, EventArgs e)
        {
            await MostrarNotificacion();
            tIntervalo01.Stop();
        }
        private async void TIntervalo02_Tick(object sender, EventArgs e)
        {
            await OcultarNotificacion();
            tIntervalo02.Stop();
        }
        private void TiempoMostradoEfecto_Tick(object sender, EventArgs e)
        {
            tIntervalo02.Start();
            tVisible.Stop();
        }

        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
