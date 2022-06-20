namespace Ocorrências_CPD
{
    partial class frmGerente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGerente));
            this.grdOcorrencias = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.cbxSituacao = new System.Windows.Forms.ComboBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.painelGerente = new System.Windows.Forms.Panel();
            this.btnResetar = new System.Windows.Forms.Button();
            this.grdFuncionarios = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).BeginInit();
            this.painelGerente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFuncionarios)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdOcorrencias
            // 
            this.grdOcorrencias.AllowUserToAddRows = false;
            this.grdOcorrencias.AllowUserToDeleteRows = false;
            this.grdOcorrencias.AllowUserToResizeColumns = false;
            this.grdOcorrencias.AllowUserToResizeRows = false;
            this.grdOcorrencias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdOcorrencias.BackgroundColor = System.Drawing.Color.White;
            this.grdOcorrencias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdOcorrencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOcorrencias.GridColor = System.Drawing.Color.DarkGray;
            this.grdOcorrencias.Location = new System.Drawing.Point(585, 117);
            this.grdOcorrencias.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.grdOcorrencias.Name = "grdOcorrencias";
            this.grdOcorrencias.ReadOnly = true;
            this.grdOcorrencias.RowHeadersVisible = false;
            this.grdOcorrencias.RowHeadersWidth = 51;
            this.grdOcorrencias.Size = new System.Drawing.Size(531, 346);
            this.grdOcorrencias.TabIndex = 7;
            this.grdOcorrencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOcorrencias_CellClick);
            this.grdOcorrencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOcorrencias_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(184, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Funcionários";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(771, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 29);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ocorrências";
            // 
            // cbxStatus
            // 
            this.cbxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Todos",
            "ativo",
            "inativo"});
            this.cbxStatus.Location = new System.Drawing.Point(4, 80);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(160, 28);
            this.cbxStatus.TabIndex = 22;
            this.cbxStatus.Text = "Todos";
            this.cbxStatus.SelectedIndexChanged += new System.EventHandler(this.cbxStatus_SelectedIndexChanged);
            // 
            // cbxSituacao
            // 
            this.cbxSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSituacao.FormattingEnabled = true;
            this.cbxSituacao.Items.AddRange(new object[] {
            "Todas",
            "aberta",
            "parcial_encerrada",
            "total_encerrada"});
            this.cbxSituacao.Location = new System.Drawing.Point(951, 80);
            this.cbxSituacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSituacao.Name = "cbxSituacao";
            this.cbxSituacao.Size = new System.Drawing.Size(160, 28);
            this.cbxSituacao.TabIndex = 23;
            this.cbxSituacao.Text = "Todas";
            this.cbxSituacao.SelectedIndexChanged += new System.EventHandler(this.cbxSituacao_SelectedIndexChanged);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFinalizar.Enabled = false;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(921, 484);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(191, 52);
            this.btnFinalizar.TabIndex = 25;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // painelGerente
            // 
            this.painelGerente.BackColor = System.Drawing.Color.Transparent;
            this.painelGerente.Controls.Add(this.btnResetar);
            this.painelGerente.Controls.Add(this.grdFuncionarios);
            this.painelGerente.Controls.Add(this.btnFinalizar);
            this.painelGerente.Controls.Add(this.cbxSituacao);
            this.painelGerente.Controls.Add(this.cbxStatus);
            this.painelGerente.Controls.Add(this.label2);
            this.painelGerente.Controls.Add(this.label1);
            this.painelGerente.Controls.Add(this.grdOcorrencias);
            this.painelGerente.Location = new System.Drawing.Point(17, 39);
            this.painelGerente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.painelGerente.Name = "painelGerente";
            this.painelGerente.Size = new System.Drawing.Size(1121, 543);
            this.painelGerente.TabIndex = 0;
            // 
            // btnResetar
            // 
            this.btnResetar.BackgroundImage = global::Ocorrências_CPD.Properties.Resources.refresh1;
            this.btnResetar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnResetar.Location = new System.Drawing.Point(605, 79);
            this.btnResetar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResetar.Name = "btnResetar";
            this.btnResetar.Size = new System.Drawing.Size(33, 31);
            this.btnResetar.TabIndex = 30;
            this.btnResetar.UseVisualStyleBackColor = true;
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click_1);
            // 
            // grdFuncionarios
            // 
            this.grdFuncionarios.AllowUserToAddRows = false;
            this.grdFuncionarios.AllowUserToDeleteRows = false;
            this.grdFuncionarios.AllowUserToResizeColumns = false;
            this.grdFuncionarios.AllowUserToResizeRows = false;
            this.grdFuncionarios.BackgroundColor = System.Drawing.Color.White;
            this.grdFuncionarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFuncionarios.GridColor = System.Drawing.Color.Gray;
            this.grdFuncionarios.Location = new System.Drawing.Point(4, 117);
            this.grdFuncionarios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdFuncionarios.Name = "grdFuncionarios";
            this.grdFuncionarios.ReadOnly = true;
            this.grdFuncionarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdFuncionarios.RowHeadersVisible = false;
            this.grdFuncionarios.RowHeadersWidth = 51;
            this.grdFuncionarios.Size = new System.Drawing.Size(532, 418);
            this.grdFuncionarios.TabIndex = 29;
            this.grdFuncionarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFuncionarios_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.departamentoToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 40);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(174, 36);
            this.toolStripMenuItem2.Text = "Cadastrar    |";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 36);
            this.toolStripMenuItem1.Text = "Funcionário";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.gerenteToolStripMenuItem_Click);
            // 
            // departamentoToolStripMenuItem1
            // 
            this.departamentoToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.departamentoToolStripMenuItem1.Name = "departamentoToolStripMenuItem1";
            this.departamentoToolStripMenuItem1.Size = new System.Drawing.Size(165, 36);
            this.departamentoToolStripMenuItem1.Text = "Ocorrências";
            this.departamentoToolStripMenuItem1.Click += new System.EventHandler(this.departamentoToolStripMenuItem_Click);
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.BackgroundImage = global::Ocorrências_CPD.Properties.Resources.desconectar;
            this.desconectarToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.desconectarToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectarToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.desconectarToolStripMenuItem.Location = new System.Drawing.Point(1101, 10);
            this.desconectarToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            this.desconectarToolStripMenuItem.Size = new System.Drawing.Size(33, 31);
            this.desconectarToolStripMenuItem.TabIndex = 31;
            this.desconectarToolStripMenuItem.UseVisualStyleBackColor = true;
            this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.desconectarToolStripMenuItem_Click);
            // 
            // frmGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ocorrências_CPD.Properties.Resources.bagkground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1155, 597);
            this.Controls.Add(this.desconectarToolStripMenuItem);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.painelGerente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmGerente";
            this.Text = "Ocorrências CPD - Gerente";
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).EndInit();
            this.painelGerente.ResumeLayout(false);
            this.painelGerente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFuncionarios)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grdOcorrencias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.ComboBox cbxSituacao;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Panel painelGerente;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView grdFuncionarios;
        private System.Windows.Forms.Button btnResetar;
        private System.Windows.Forms.Button desconectarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}