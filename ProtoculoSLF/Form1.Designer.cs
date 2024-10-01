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
            this.pnlContenedorTodo = new System.Windows.Forms.Panel();
            this.scPrincipal = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tlpContornoAPP.SuspendLayout();
            this.pnlContenedorTodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPrincipal)).BeginInit();
            this.scPrincipal.Panel1.SuspendLayout();
            this.scPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
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
            this.scPrincipal.Panel1.Controls.Add(this.gridControl1);
            this.scPrincipal.Panel1MinSize = 50;
            this.scPrincipal.Size = new System.Drawing.Size(950, 593);
            this.scPrincipal.SplitterDistance = 224;
            this.scPrincipal.SplitterIncrement = 20;
            this.scPrincipal.SplitterWidth = 1;
            this.scPrincipal.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(224, 593);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(961, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Panel1MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(234, 593);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.SplitterIncrement = 20;
            this.splitContainer1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 601);
            this.Controls.Add(this.tlpContornoAPP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tlpContornoAPP.ResumeLayout(false);
            this.pnlContenedorTodo.ResumeLayout(false);
            this.scPrincipal.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scPrincipal)).EndInit();
            this.scPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContornoAPP;
        private System.Windows.Forms.Panel pnlContenedorTodo;
        private System.Windows.Forms.SplitContainer scPrincipal;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

