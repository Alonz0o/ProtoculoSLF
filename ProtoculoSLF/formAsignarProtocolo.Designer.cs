namespace ProtoculoSLF
{
    partial class formAsignarProtocolo
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
            this.gcPoe = new DevExpress.XtraEditors.GroupControl();
            this.btnCerrarMin = new FontAwesome.Sharp.IconButton();
            this.tlpRealizados = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPendientes = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregarItem = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnCancelar = new ProtoculoSLF.AAFControles.AAFBoton();
            this.gcCliente = new DevExpress.XtraEditors.GroupControl();
            this.lueProtocolo = new DevExpress.XtraEditors.LookUpEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gcPoe)).BeginInit();
            this.gcPoe.SuspendLayout();
            this.tlpRealizados.SuspendLayout();
            this.pnlPendientes.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).BeginInit();
            this.gcCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProtocolo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPoe
            // 
            this.gcPoe.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.gcPoe.Appearance.Options.UseBorderColor = true;
            this.gcPoe.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.gcPoe.AppearanceCaption.Options.UseFont = true;
            this.gcPoe.Controls.Add(this.btnCerrarMin);
            this.gcPoe.Controls.Add(this.tlpRealizados);
            this.gcPoe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPoe.Location = new System.Drawing.Point(0, 0);
            this.gcPoe.Name = "gcPoe";
            this.gcPoe.Size = new System.Drawing.Size(300, 136);
            this.gcPoe.TabIndex = 68;
            this.gcPoe.Text = "Asignar protocolo";
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
            this.btnCerrarMin.Location = new System.Drawing.Point(277, 1);
            this.btnCerrarMin.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrarMin.Name = "btnCerrarMin";
            this.btnCerrarMin.Size = new System.Drawing.Size(20, 20);
            this.btnCerrarMin.TabIndex = 36;
            this.btnCerrarMin.UseVisualStyleBackColor = false;
            this.btnCerrarMin.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tlpRealizados
            // 
            this.tlpRealizados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tlpRealizados.ColumnCount = 2;
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRealizados.Controls.Add(this.pnlPendientes, 1, 0);
            this.tlpRealizados.Controls.Add(this.panel2, 0, 0);
            this.tlpRealizados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRealizados.Location = new System.Drawing.Point(2, 23);
            this.tlpRealizados.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tlpRealizados.Name = "tlpRealizados";
            this.tlpRealizados.RowCount = 1;
            this.tlpRealizados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRealizados.Size = new System.Drawing.Size(296, 111);
            this.tlpRealizados.TabIndex = 3;
            // 
            // pnlPendientes
            // 
            this.pnlPendientes.AutoScroll = true;
            this.pnlPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel2);
            this.pnlPendientes.Controls.Add(this.gcCliente);
            this.pnlPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendientes.Location = new System.Drawing.Point(16, 3);
            this.pnlPendientes.Name = "pnlPendientes";
            this.pnlPendientes.Size = new System.Drawing.Size(277, 105);
            this.pnlPendientes.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnAgregarItem, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 62);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(277, 43);
            this.tableLayoutPanel2.TabIndex = 68;
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarItem.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAgregarItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItem.BorderRadius = 4;
            this.btnAgregarItem.BorderSize = 3;
            this.btnAgregarItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarItem.FlatAppearance.BorderSize = 0;
            this.btnAgregarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarItem.Font = new System.Drawing.Font("Roboto Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItem.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(132, 37);
            this.btnAgregarItem.TabIndex = 1;
            this.btnAgregarItem.Text = "Asignar";
            this.btnAgregarItem.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItem.UseVisualStyleBackColor = false;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.BorderRadius = 4;
            this.btnCancelar.BorderSize = 3;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Roboto Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.Location = new System.Drawing.Point(141, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 37);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gcCliente
            // 
            this.gcCliente.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.gcCliente.Appearance.Options.UseBorderColor = true;
            this.gcCliente.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcCliente.AppearanceCaption.Options.UseFont = true;
            this.gcCliente.Controls.Add(this.lueProtocolo);
            this.gcCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcCliente.Location = new System.Drawing.Point(0, 0);
            this.gcCliente.Name = "gcCliente";
            this.gcCliente.Size = new System.Drawing.Size(277, 59);
            this.gcCliente.TabIndex = 67;
            this.gcCliente.Text = "  Seleccione protocolo";
            // 
            // lueProtocolo
            // 
            this.lueProtocolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueProtocolo.EditValue = "";
            this.lueProtocolo.Location = new System.Drawing.Point(2, 23);
            this.lueProtocolo.Name = "lueProtocolo";
            this.lueProtocolo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lueProtocolo.Properties.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lueProtocolo.Properties.Appearance.Options.UseFont = true;
            this.lueProtocolo.Properties.Appearance.Options.UseForeColor = true;
            this.lueProtocolo.Properties.AutoHeight = false;
            this.lueProtocolo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProtocolo.Properties.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lueProtocolo.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueProtocolo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueProtocolo.Size = new System.Drawing.Size(273, 34);
            this.lueProtocolo.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 105);
            this.panel2.TabIndex = 1;
            // 
            // formAsignarProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 136);
            this.Controls.Add(this.gcPoe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAsignarProtocolo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formAsignarProtocolo";
            this.Load += new System.EventHandler(this.formAsignarProtocolo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcPoe)).EndInit();
            this.gcPoe.ResumeLayout(false);
            this.tlpRealizados.ResumeLayout(false);
            this.pnlPendientes.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).EndInit();
            this.gcCliente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueProtocolo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl gcPoe;
        private FontAwesome.Sharp.IconButton btnCerrarMin;
        private System.Windows.Forms.TableLayoutPanel tlpRealizados;
        private System.Windows.Forms.Panel pnlPendientes;
        private DevExpress.XtraEditors.GroupControl gcCliente;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LookUpEdit lueProtocolo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private AAFControles.AAFBoton btnAgregarItem;
        private AAFControles.AAFBoton btnCancelar;
    }
}