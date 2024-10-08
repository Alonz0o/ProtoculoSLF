namespace ProtoculoSLF
{
    partial class formAsignarItemProtocolo
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
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelarCambios = new System.Windows.Forms.Button();
            this.btnConfirmarCambios = new System.Windows.Forms.Button();
            this.btnMostrarAgregarItem = new FontAwesome.Sharp.IconButton();
            this.gcItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcAgregarItem = new DevExpress.XtraEditors.GroupControl();
            this.cbCertificado = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbMedida = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbOrden = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lueItemSimbolos = new DevExpress.XtraEditors.LookUpEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAgregarItem)).BeginInit();
            this.gcAgregarItem.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemSimbolos.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.groupControl1);
            this.groupControl3.Controls.Add(this.btnMostrarAgregarItem);
            this.groupControl3.Controls.Add(this.gcItems);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(397, 216);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Protocolos Item";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tableLayoutPanel2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 155);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(393, 59);
            this.groupControl1.TabIndex = 34;
            this.groupControl1.Text = "Confirmar cambios";
            this.groupControl1.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancelarCambios, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnConfirmarCambios, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(389, 34);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnCancelarCambios
            // 
            this.btnCancelarCambios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelarCambios.Location = new System.Drawing.Point(197, 3);
            this.btnCancelarCambios.Name = "btnCancelarCambios";
            this.btnCancelarCambios.Size = new System.Drawing.Size(189, 28);
            this.btnCancelarCambios.TabIndex = 8;
            this.btnCancelarCambios.Text = "Cancelar";
            this.btnCancelarCambios.UseVisualStyleBackColor = true;
            this.btnCancelarCambios.Click += new System.EventHandler(this.btnCancelarCambios_Click);
            // 
            // btnConfirmarCambios
            // 
            this.btnConfirmarCambios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirmarCambios.Location = new System.Drawing.Point(3, 3);
            this.btnConfirmarCambios.Name = "btnConfirmarCambios";
            this.btnConfirmarCambios.Size = new System.Drawing.Size(188, 28);
            this.btnConfirmarCambios.TabIndex = 7;
            this.btnConfirmarCambios.Text = "Confirmar";
            this.btnConfirmarCambios.UseVisualStyleBackColor = true;
            this.btnConfirmarCambios.Click += new System.EventHandler(this.btnConfirmarCambios_Click);
            // 
            // btnMostrarAgregarItem
            // 
            this.btnMostrarAgregarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostrarAgregarItem.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarAgregarItem.BackgroundImage = global::ProtoculoSLF.Properties.Resources.add_16x16;
            this.btnMostrarAgregarItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMostrarAgregarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarAgregarItem.FlatAppearance.BorderSize = 0;
            this.btnMostrarAgregarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarAgregarItem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnMostrarAgregarItem.IconColor = System.Drawing.SystemColors.Highlight;
            this.btnMostrarAgregarItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarAgregarItem.IconSize = 20;
            this.btnMostrarAgregarItem.Location = new System.Drawing.Point(372, 1);
            this.btnMostrarAgregarItem.Name = "btnMostrarAgregarItem";
            this.btnMostrarAgregarItem.Size = new System.Drawing.Size(20, 20);
            this.btnMostrarAgregarItem.TabIndex = 33;
            this.btnMostrarAgregarItem.UseVisualStyleBackColor = false;
            this.btnMostrarAgregarItem.Click += new System.EventHandler(this.btnMostrarAgregarItem_Click);
            // 
            // gcItems
            // 
            this.gcItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItems.Location = new System.Drawing.Point(2, 23);
            this.gcItems.MainView = this.gvItems;
            this.gcItems.Name = "gcItems";
            this.gcItems.Size = new System.Drawing.Size(393, 191);
            this.gcItems.TabIndex = 1;
            this.gcItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.GridControl = this.gcItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            this.gvItems.OptionsView.ShowGroupPanel = false;
            this.gvItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gvItems_MouseMove);
            // 
            // gcAgregarItem
            // 
            this.gcAgregarItem.Controls.Add(this.tableLayoutPanel1);
            this.gcAgregarItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gcAgregarItem.Location = new System.Drawing.Point(0, 216);
            this.gcAgregarItem.Name = "gcAgregarItem";
            this.gcAgregarItem.Size = new System.Drawing.Size(397, 186);
            this.gcAgregarItem.TabIndex = 2;
            this.gcAgregarItem.Text = "Agregar items";
            this.gcAgregarItem.Visible = false;
            // 
            // cbCertificado
            // 
            this.cbCertificado.Location = new System.Drawing.Point(199, 43);
            this.cbCertificado.Name = "cbCertificado";
            this.cbCertificado.Size = new System.Drawing.Size(80, 17);
            this.cbCertificado.TabIndex = 9;
            this.cbCertificado.Text = "Certificado";
            this.cbCertificado.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarItem, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbCertificado, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(393, 161);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbMedida);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(199, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 34);
            this.panel3.TabIndex = 6;
            // 
            // tbMedida
            // 
            this.tbMedida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMedida.Location = new System.Drawing.Point(48, 4);
            this.tbMedida.Name = "tbMedida";
            this.tbMedida.Size = new System.Drawing.Size(135, 21);
            this.tbMedida.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unidad";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbNombre);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 34);
            this.panel2.TabIndex = 5;
            // 
            // tbNombre
            // 
            this.tbNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNombre.Location = new System.Drawing.Point(62, 4);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(125, 21);
            this.tbNombre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(199, 123);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(191, 28);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Location = new System.Drawing.Point(3, 123);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(190, 28);
            this.btnAgregarItem.TabIndex = 7;
            this.btnAgregarItem.Text = "Agregar";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 34);
            this.panel1.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbOrden);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(190, 34);
            this.panel5.TabIndex = 7;
            // 
            // tbOrden
            // 
            this.tbOrden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOrden.Location = new System.Drawing.Point(62, 4);
            this.tbOrden.Name = "tbOrden";
            this.tbOrden.Size = new System.Drawing.Size(125, 21);
            this.tbOrden.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Orden";
            // 
            // lueItemSimbolos
            // 
            this.lueItemSimbolos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lueItemSimbolos.EditValue = "";
            this.lueItemSimbolos.Location = new System.Drawing.Point(62, 4);
            this.lueItemSimbolos.Name = "lueItemSimbolos";
            this.lueItemSimbolos.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lueItemSimbolos.Properties.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lueItemSimbolos.Properties.Appearance.Options.UseFont = true;
            this.lueItemSimbolos.Properties.Appearance.Options.UseForeColor = true;
            this.lueItemSimbolos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueItemSimbolos.Properties.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lueItemSimbolos.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueItemSimbolos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueItemSimbolos.Size = new System.Drawing.Size(125, 22);
            this.lueItemSimbolos.TabIndex = 63;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lueItemSimbolos);
            this.panel4.Location = new System.Drawing.Point(3, 83);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(190, 34);
            this.panel4.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Caracter";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(199, 83);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(190, 34);
            this.panel6.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Media";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(48, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 21);
            this.textBox1.TabIndex = 65;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Media";
            // 
            // formAsignarItemProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 402);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.gcAgregarItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAsignarItemProtocolo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formAsignarItemProtocolo";
            this.Load += new System.EventHandler(this.formAsignarItemProtocolo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAgregarItem)).EndInit();
            this.gcAgregarItem.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemSimbolos.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private FontAwesome.Sharp.IconButton btnMostrarAgregarItem;
        private DevExpress.XtraGrid.GridControl gcItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraEditors.GroupControl gcAgregarItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbCertificado;
        private System.Windows.Forms.TextBox tbMedida;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbOrden;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancelarCambios;
        private System.Windows.Forms.Button btnConfirmarCambios;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lueItemSimbolos;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
    }
}