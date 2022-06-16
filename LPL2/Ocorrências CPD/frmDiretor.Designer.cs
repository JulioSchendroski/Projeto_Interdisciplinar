namespace Ocorrências_CPD
{
    partial class frmDiretor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiretor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.painelGerente = new System.Windows.Forms.Panel();
            this.grdGerentes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDepartamento = new System.Windows.Forms.ComboBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdDepartamento = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.diretorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.painelGerente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGerentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartamento)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.diretorToolStripMenuItem1,
            this.gerenteToolStripMenuItem1,
            this.departamentoToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 33);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // painelGerente
            // 
            this.painelGerente.BackColor = System.Drawing.Color.Transparent;
            this.painelGerente.Controls.Add(this.button1);
            this.painelGerente.Controls.Add(this.grdGerentes);
            this.painelGerente.Controls.Add(this.label3);
            this.painelGerente.Controls.Add(this.cbxDepartamento);
            this.painelGerente.Controls.Add(this.cbxStatus);
            this.painelGerente.Controls.Add(this.label2);
            this.painelGerente.Controls.Add(this.label1);
            this.painelGerente.Controls.Add(this.grdDepartamento);
            this.painelGerente.Location = new System.Drawing.Point(13, 22);
            this.painelGerente.Name = "painelGerente";
            this.painelGerente.Size = new System.Drawing.Size(841, 441);
            this.painelGerente.TabIndex = 0;
            // 
            // grdGerentes
            // 
            this.grdGerentes.AllowUserToAddRows = false;
            this.grdGerentes.AllowUserToDeleteRows = false;
            this.grdGerentes.AllowUserToResizeColumns = false;
            this.grdGerentes.AllowUserToResizeRows = false;
            this.grdGerentes.BackgroundColor = System.Drawing.Color.White;
            this.grdGerentes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdGerentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGerentes.Location = new System.Drawing.Point(3, 99);
            this.grdGerentes.Name = "grdGerentes";
            this.grdGerentes.ReadOnly = true;
            this.grdGerentes.RowHeadersVisible = false;
            this.grdGerentes.Size = new System.Drawing.Size(399, 336);
            this.grdGerentes.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Departamentos";
            // 
            // cbxDepartamento
            // 
            this.cbxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDepartamento.FormattingEnabled = true;
            this.cbxDepartamento.Items.AddRange(new object[] {
            "Status",
            "ativo",
            "inativo"});
            this.cbxDepartamento.Location = new System.Drawing.Point(4, 69);
            this.cbxDepartamento.Name = "cbxDepartamento";
            this.cbxDepartamento.Size = new System.Drawing.Size(159, 24);
            this.cbxDepartamento.TabIndex = 27;
            this.cbxDepartamento.SelectedIndexChanged += new System.EventHandler(this.cbxDepartamento_SelectedIndexChanged_1);
            // 
            // cbxStatus
            // 
            this.cbxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Todos",
            "ativo",
            "inativo"});
            this.cbxStatus.Location = new System.Drawing.Point(253, 69);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(121, 24);
            this.cbxStatus.TabIndex = 22;
            this.cbxStatus.Text = "Todos";
            this.cbxStatus.SelectedIndexChanged += new System.EventHandler(this.cbxStatus_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(571, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Departamentos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(150, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Gerentes";
            // 
            // grdDepartamento
            // 
            this.grdDepartamento.AllowUserToAddRows = false;
            this.grdDepartamento.AllowUserToDeleteRows = false;
            this.grdDepartamento.AllowUserToResizeColumns = false;
            this.grdDepartamento.AllowUserToResizeRows = false;
            this.grdDepartamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDepartamento.BackgroundColor = System.Drawing.Color.White;
            this.grdDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdDepartamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDepartamento.GridColor = System.Drawing.Color.DarkGray;
            this.grdDepartamento.Location = new System.Drawing.Point(439, 99);
            this.grdDepartamento.Margin = new System.Windows.Forms.Padding(4);
            this.grdDepartamento.Name = "grdDepartamento";
            this.grdDepartamento.ReadOnly = true;
            this.grdDepartamento.RowHeadersVisible = false;
            this.grdDepartamento.Size = new System.Drawing.Size(398, 336);
            this.grdDepartamento.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Ocorrências_CPD.Properties.Resources.refresh1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(169, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 32;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnResetar_Click);
            // 
            // diretorToolStripMenuItem1
            // 
            this.diretorToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.diretorToolStripMenuItem1.Name = "diretorToolStripMenuItem1";
            this.diretorToolStripMenuItem1.Size = new System.Drawing.Size(88, 29);
            this.diretorToolStripMenuItem1.Text = "Diretor";
            this.diretorToolStripMenuItem1.Click += new System.EventHandler(this.diretorToolStripMenuItem_Click);
            // 
            // gerenteToolStripMenuItem1
            // 
            this.gerenteToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.gerenteToolStripMenuItem1.Name = "gerenteToolStripMenuItem1";
            this.gerenteToolStripMenuItem1.Size = new System.Drawing.Size(95, 29);
            this.gerenteToolStripMenuItem1.Text = "Gerente";
            this.gerenteToolStripMenuItem1.Click += new System.EventHandler(this.gerenteToolStripMenuItem_Click);
            // 
            // departamentoToolStripMenuItem1
            // 
            this.departamentoToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.departamentoToolStripMenuItem1.Name = "departamentoToolStripMenuItem1";
            this.departamentoToolStripMenuItem1.Size = new System.Drawing.Size(154, 29);
            this.departamentoToolStripMenuItem1.Text = "Departamento";
            this.departamentoToolStripMenuItem1.Click += new System.EventHandler(this.departamentoToolStripMenuItem_Click);
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.Enabled = false;
            this.cadastrarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(140, 29);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar     |";
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.BackgroundImage = global::Ocorrências_CPD.Properties.Resources.desconectar;
            this.desconectarToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.desconectarToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectarToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.desconectarToolStripMenuItem.Location = new System.Drawing.Point(829, 8);
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            this.desconectarToolStripMenuItem.Size = new System.Drawing.Size(25, 25);
            this.desconectarToolStripMenuItem.TabIndex = 32;
            this.desconectarToolStripMenuItem.UseVisualStyleBackColor = true;
            this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.desconectarToolStripMenuItem_Click);
            // 
            // frmDiretor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ocorrências_CPD.Properties.Resources.bagkground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(866, 485);
            this.Controls.Add(this.desconectarToolStripMenuItem);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.painelGerente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDiretor";
            this.Text = "Ocorrências CPD - Diretor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.painelGerente.ResumeLayout(false);
            this.painelGerente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGerentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel painelGerente;
        private System.Windows.Forms.DataGridView grdGerentes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDepartamento;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdDepartamento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diretorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gerenteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem1;
        private System.Windows.Forms.Button desconectarToolStripMenuItem;
    }
}