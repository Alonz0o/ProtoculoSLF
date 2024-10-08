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
            this.gcFiltroTipo = new DevExpress.XtraEditors.GroupControl();
            this.lueTipo = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gcFiltroTipo)).BeginInit();
            this.gcFiltroTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipo.Properties)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcFiltroTipo
            // 
            this.gcFiltroTipo.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.gcFiltroTipo.Appearance.Options.UseBorderColor = true;
            this.gcFiltroTipo.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcFiltroTipo.AppearanceCaption.Options.UseFont = true;
            this.gcFiltroTipo.Controls.Add(this.lueTipo);
            this.gcFiltroTipo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcFiltroTipo.Location = new System.Drawing.Point(0, 0);
            this.gcFiltroTipo.Name = "gcFiltroTipo";
            this.gcFiltroTipo.Size = new System.Drawing.Size(276, 48);
            this.gcFiltroTipo.TabIndex = 62;
            this.gcFiltroTipo.Text = "  Seleccionar protocolo";
            // 
            // lueTipo
            // 
            this.lueTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueTipo.EditValue = "";
            this.lueTipo.Location = new System.Drawing.Point(2, 23);
            this.lueTipo.Name = "lueTipo";
            this.lueTipo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lueTipo.Properties.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lueTipo.Properties.Appearance.Options.UseFont = true;
            this.lueTipo.Properties.Appearance.Options.UseForeColor = true;
            this.lueTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipo.Properties.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lueTipo.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueTipo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueTipo.Size = new System.Drawing.Size(272, 22);
            this.lueTipo.TabIndex = 61;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btnAgregar, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnSalir, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(276, 43);
            this.tableLayoutPanel5.TabIndex = 67;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(132, 37);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Asignar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalir.Location = new System.Drawing.Point(141, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(132, 37);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // formAsignarProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 96);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.gcFiltroTipo);
            this.Name = "formAsignarProtocolo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formAsignarProtocolo";
            this.Load += new System.EventHandler(this.formAsignarProtocolo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcFiltroTipo)).EndInit();
            this.gcFiltroTipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueTipo.Properties)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcFiltroTipo;
        private DevExpress.XtraEditors.LookUpEdit lueTipo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
    }
}