namespace ProtoculoSLF
{
    partial class formNotificacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcNotificacion = new DevExpress.XtraEditors.GroupControl();
            this.btnCerrarMin = new FontAwesome.Sharp.IconButton();
            this.tlpNoti = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCuerpo = new System.Windows.Forms.TableLayoutPanel();
            this.iconoNotificacion = new FontAwesome.Sharp.IconButton();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlLineaVertical = new System.Windows.Forms.Panel();
            this.lblNombreVentana = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcNotificacion)).BeginInit();
            this.gcNotificacion.SuspendLayout();
            this.tlpNoti.SuspendLayout();
            this.tlpCuerpo.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcNotificacion
            // 
            this.gcNotificacion.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gcNotificacion.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.gcNotificacion.Appearance.Options.UseBackColor = true;
            this.gcNotificacion.Appearance.Options.UseBorderColor = true;
            this.gcNotificacion.Appearance.Options.UseForeColor = true;
            this.gcNotificacion.AppearanceCaption.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Bold);
            this.gcNotificacion.AppearanceCaption.Options.UseFont = true;
            this.gcNotificacion.Controls.Add(this.lblNombreVentana);
            this.gcNotificacion.Controls.Add(this.btnCerrarMin);
            this.gcNotificacion.Controls.Add(this.tlpNoti);
            this.gcNotificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNotificacion.Location = new System.Drawing.Point(0, 0);
            this.gcNotificacion.Name = "gcNotificacion";
            this.gcNotificacion.Size = new System.Drawing.Size(450, 100);
            this.gcNotificacion.TabIndex = 4;
            // 
            // btnCerrarMin
            // 
            this.btnCerrarMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarMin.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarMin.FlatAppearance.BorderSize = 0;
            this.btnCerrarMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarMin.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCerrarMin.IconColor = System.Drawing.Color.Azure;
            this.btnCerrarMin.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCerrarMin.IconSize = 15;
            this.btnCerrarMin.Location = new System.Drawing.Point(427, 1);
            this.btnCerrarMin.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrarMin.Name = "btnCerrarMin";
            this.btnCerrarMin.Size = new System.Drawing.Size(20, 20);
            this.btnCerrarMin.TabIndex = 36;
            this.btnCerrarMin.UseVisualStyleBackColor = false;
            this.btnCerrarMin.Click += new System.EventHandler(this.btnCerrarMin_Click);
            // 
            // tlpNoti
            // 
            this.tlpNoti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tlpNoti.ColumnCount = 2;
            this.tlpNoti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpNoti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNoti.Controls.Add(this.tlpCuerpo, 1, 0);
            this.tlpNoti.Controls.Add(this.pnlLineaVertical, 0, 0);
            this.tlpNoti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNoti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tlpNoti.Location = new System.Drawing.Point(2, 23);
            this.tlpNoti.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tlpNoti.Name = "tlpNoti";
            this.tlpNoti.RowCount = 1;
            this.tlpNoti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoti.Size = new System.Drawing.Size(446, 75);
            this.tlpNoti.TabIndex = 3;
            // 
            // tlpCuerpo
            // 
            this.tlpCuerpo.BackColor = System.Drawing.Color.Transparent;
            this.tlpCuerpo.ColumnCount = 2;
            this.tlpCuerpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpCuerpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCuerpo.Controls.Add(this.iconoNotificacion, 0, 0);
            this.tlpCuerpo.Controls.Add(this.pnlCuerpo, 1, 0);
            this.tlpCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCuerpo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tlpCuerpo.Location = new System.Drawing.Point(15, 3);
            this.tlpCuerpo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tlpCuerpo.Name = "tlpCuerpo";
            this.tlpCuerpo.RowCount = 1;
            this.tlpCuerpo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCuerpo.Size = new System.Drawing.Size(429, 69);
            this.tlpCuerpo.TabIndex = 4;
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.BackColor = System.Drawing.Color.Transparent;
            this.iconoNotificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconoNotificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconoNotificacion.FlatAppearance.BorderSize = 0;
            this.iconoNotificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconoNotificacion.IconChar = FontAwesome.Sharp.IconChar.Stethoscope;
            this.iconoNotificacion.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.iconoNotificacion.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconoNotificacion.Location = new System.Drawing.Point(0, 0);
            this.iconoNotificacion.Margin = new System.Windows.Forms.Padding(0);
            this.iconoNotificacion.Name = "iconoNotificacion";
            this.iconoNotificacion.Size = new System.Drawing.Size(53, 69);
            this.iconoNotificacion.TabIndex = 30;
            this.iconoNotificacion.UseVisualStyleBackColor = false;
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.Transparent;
            this.pnlCuerpo.Controls.Add(this.lblMensaje);
            this.pnlCuerpo.Controls.Add(this.lblTitulo);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(56, 3);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(370, 63);
            this.pnlCuerpo.TabIndex = 31;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMensaje.Location = new System.Drawing.Point(0, 22);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblMensaje.Size = new System.Drawing.Size(370, 41);
            this.lblMensaje.TabIndex = 40;
            this.lblMensaje.Text = "NOTIFICACION TEXT";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(370, 22);
            this.lblTitulo.TabIndex = 39;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLineaVertical
            // 
            this.pnlLineaVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.pnlLineaVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLineaVertical.Location = new System.Drawing.Point(3, 3);
            this.pnlLineaVertical.Name = "pnlLineaVertical";
            this.pnlLineaVertical.Size = new System.Drawing.Size(7, 69);
            this.pnlLineaVertical.TabIndex = 1;
            // 
            // lblNombreVentana
            // 
            this.lblNombreVentana.AutoSize = true;
            this.lblNombreVentana.Font = new System.Drawing.Font("Roboto Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreVentana.ForeColor = System.Drawing.Color.Black;
            this.lblNombreVentana.Location = new System.Drawing.Point(17, 3);
            this.lblNombreVentana.Name = "lblNombreVentana";
            this.lblNombreVentana.Size = new System.Drawing.Size(91, 15);
            this.lblNombreVentana.TabIndex = 37;
            this.lblNombreVentana.Text = "Notificacion ";
            // 
            // formNotificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 100);
            this.Controls.Add(this.gcNotificacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formNotificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formNotificacion";
            this.Load += new System.EventHandler(this.formNotificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcNotificacion)).EndInit();
            this.gcNotificacion.ResumeLayout(false);
            this.gcNotificacion.PerformLayout();
            this.tlpNoti.ResumeLayout(false);
            this.tlpCuerpo.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcNotificacion;
        private FontAwesome.Sharp.IconButton btnCerrarMin;
        private System.Windows.Forms.TableLayoutPanel tlpNoti;
        private System.Windows.Forms.Panel pnlLineaVertical;
        private System.Windows.Forms.TableLayoutPanel tlpCuerpo;
        private FontAwesome.Sharp.IconButton iconoNotificacion;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombreVentana;
    }
}