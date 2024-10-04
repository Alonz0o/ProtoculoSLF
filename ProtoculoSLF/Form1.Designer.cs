namespace ProtoculoSLF
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpContornoAPP = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gcItemsProtocolo = new DevExpress.XtraGrid.GridControl();
            this.gvItemsProtocolo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlContenedorTodo = new System.Windows.Forms.Panel();
            this.scPrincipal = new System.Windows.Forms.SplitContainer();
            this.gcProtocolos = new DevExpress.XtraGrid.GridControl();
            this.gvProtocolos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dvProtocolos = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.gcNts = new DevExpress.XtraGrid.GridControl();
            this.gvNts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tlpContornoAPP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemsProtocolo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemsProtocolo)).BeginInit();
            this.pnlContenedorTodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPrincipal)).BeginInit();
            this.scPrincipal.Panel1.SuspendLayout();
            this.scPrincipal.Panel2.SuspendLayout();
            this.scPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProtocolos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProtocolos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNts)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpContornoAPP
            // 
            this.tlpContornoAPP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tlpContornoAPP.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpContornoAPP.ColumnCount = 2;
            this.tlpContornoAPP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.96661F));
            this.tlpContornoAPP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.03339F));
            this.tlpContornoAPP.Controls.Add(this.splitContainer1, 1, 0);
            this.tlpContornoAPP.Controls.Add(this.pnlContenedorTodo, 0, 0);
            this.tlpContornoAPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContornoAPP.Location = new System.Drawing.Point(0, 0);
            this.tlpContornoAPP.Name = "tlpContornoAPP";
            this.tlpContornoAPP.RowCount = 1;
            this.tlpContornoAPP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContornoAPP.Size = new System.Drawing.Size(1199, 601);
            this.tlpContornoAPP.TabIndex = 44;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(961, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcItemsProtocolo);
            this.splitContainer1.Panel1MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(234, 593);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.SplitterIncrement = 20;
            this.splitContainer1.TabIndex = 6;
            // 
            // gcItemsProtocolo
            // 
            this.gcItemsProtocolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItemsProtocolo.Location = new System.Drawing.Point(0, 0);
            this.gcItemsProtocolo.MainView = this.gvItemsProtocolo;
            this.gcItemsProtocolo.Name = "gcItemsProtocolo";
            this.gcItemsProtocolo.Size = new System.Drawing.Size(234, 295);
            this.gcItemsProtocolo.TabIndex = 1;
            this.gcItemsProtocolo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItemsProtocolo});
            // 
            // gvItemsProtocolo
            // 
            this.gvItemsProtocolo.GridControl = this.gcItemsProtocolo;
            this.gvItemsProtocolo.Name = "gvItemsProtocolo";
            this.gvItemsProtocolo.OptionsFind.AlwaysVisible = true;
            this.gvItemsProtocolo.OptionsView.ShowGroupPanel = false;
            // 
            // pnlContenedorTodo
            // 
            this.pnlContenedorTodo.Controls.Add(this.scPrincipal);
            this.pnlContenedorTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorTodo.Location = new System.Drawing.Point(4, 4);
            this.pnlContenedorTodo.Name = "pnlContenedorTodo";
            this.pnlContenedorTodo.Size = new System.Drawing.Size(950, 593);
            this.pnlContenedorTodo.TabIndex = 0;
            // 
            // scPrincipal
            // 
            this.scPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPrincipal.Location = new System.Drawing.Point(0, 0);
            this.scPrincipal.Name = "scPrincipal";
            // 
            // scPrincipal.Panel1
            // 
            this.scPrincipal.Panel1.Controls.Add(this.splitContainer2);
            this.scPrincipal.Panel1MinSize = 50;
            // 
            // scPrincipal.Panel2
            // 
            this.scPrincipal.Panel2.Controls.Add(this.dvProtocolos);
            this.scPrincipal.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.scPrincipal.Size = new System.Drawing.Size(950, 593);
            this.scPrincipal.SplitterDistance = 224;
            this.scPrincipal.SplitterIncrement = 20;
            this.scPrincipal.SplitterWidth = 1;
            this.scPrincipal.TabIndex = 5;
            // 
            // gcProtocolos
            // 
            this.gcProtocolos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProtocolos.Location = new System.Drawing.Point(2, 23);
            this.gcProtocolos.MainView = this.gvProtocolos;
            this.gcProtocolos.Name = "gcProtocolos";
            this.gcProtocolos.Size = new System.Drawing.Size(220, 257);
            this.gcProtocolos.TabIndex = 0;
            this.gcProtocolos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProtocolos});
            // 
            // gvProtocolos
            // 
            this.gvProtocolos.GridControl = this.gcProtocolos;
            this.gvProtocolos.Name = "gvProtocolos";
            this.gvProtocolos.OptionsFind.AlwaysVisible = true;
            this.gvProtocolos.OptionsView.ShowGroupPanel = false;
            this.gvProtocolos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvProtocolos_MouseDown);
            // 
            // dvProtocolos
            // 
            this.dvProtocolos.AllowDrop = true;
            this.dvProtocolos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvProtocolos.IsMetric = true;
            this.dvProtocolos.Location = new System.Drawing.Point(0, 30);
            this.dvProtocolos.Name = "dvProtocolos";
            this.dvProtocolos.Size = new System.Drawing.Size(725, 563);
            this.dvProtocolos.TabIndex = 0;
            this.dvProtocolos.DragDrop += new System.Windows.Forms.DragEventHandler(this.documentViewer1_DragDrop);
            this.dvProtocolos.DragEnter += new System.Windows.Forms.DragEventHandler(this.documentViewer1_DragEnter);
            // 
            // gcNts
            // 
            this.gcNts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNts.Location = new System.Drawing.Point(2, 23);
            this.gcNts.MainView = this.gvNts;
            this.gcNts.Name = "gcNts";
            this.gcNts.Size = new System.Drawing.Size(220, 282);
            this.gcNts.TabIndex = 2;
            this.gcNts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNts});
            // 
            // gvNts
            // 
            this.gvNts.GridControl = this.gcNts;
            this.gvNts.Name = "gvNts";
            this.gvNts.OptionsFind.AlwaysVisible = true;
            this.gvNts.OptionsView.ShowGroupPanel = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCliente, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 30);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblCliente.Location = new System.Drawing.Point(3, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(175, 30);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(184, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 30);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(365, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 30);
            this.label2.TabIndex = 2;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(546, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 30);
            this.label3.TabIndex = 3;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupControl2);
            this.splitContainer2.Size = new System.Drawing.Size(224, 593);
            this.splitContainer2.SplitterDistance = 282;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcProtocolos);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(224, 282);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Codigos";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcNts);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(224, 307);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Pallets";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 601);
            this.Controls.Add(this.tlpContornoAPP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tlpContornoAPP.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItemsProtocolo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemsProtocolo)).EndInit();
            this.pnlContenedorTodo.ResumeLayout(false);
            this.scPrincipal.Panel1.ResumeLayout(false);
            this.scPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scPrincipal)).EndInit();
            this.scPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProtocolos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProtocolos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNts)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContornoAPP;
        private System.Windows.Forms.Panel pnlContenedorTodo;
        private System.Windows.Forms.SplitContainer scPrincipal;
        private DevExpress.XtraGrid.GridControl gcProtocolos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProtocolos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraPrinting.Preview.DocumentViewer dvProtocolos;
        private DevExpress.XtraGrid.GridControl gcItemsProtocolo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItemsProtocolo;
        private DevExpress.XtraGrid.GridControl gcNts;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}

