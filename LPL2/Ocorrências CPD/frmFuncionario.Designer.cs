namespace Ocorrências_CPD
{
    partial class frmFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFuncionario));
            this.painelFuncionario = new System.Windows.Forms.Panel();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cbxSituacao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdOcorrencias = new System.Windows.Forms.DataGridView();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.Button();
            this.painelFuncionario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).BeginInit();
            this.SuspendLayout();
            // 
            // painelFuncionario
            // 
            this.painelFuncionario.BackColor = System.Drawing.Color.Transparent;
            this.painelFuncionario.Controls.Add(this.btnFinalizar);
            this.painelFuncionario.Controls.Add(this.txtStatus);
            this.painelFuncionario.Controls.Add(this.txtCargo);
            this.painelFuncionario.Controls.Add(this.txtMatricula);
            this.painelFuncionario.Controls.Add(this.txtDepartamento);
            this.painelFuncionario.Controls.Add(this.txtNome);
            this.painelFuncionario.Controls.Add(this.cbxSituacao);
            this.painelFuncionario.Controls.Add(this.label2);
            this.painelFuncionario.Controls.Add(this.grdOcorrencias);
            this.painelFuncionario.Location = new System.Drawing.Point(15, 25);
            this.painelFuncionario.Margin = new System.Windows.Forms.Padding(4);
            this.painelFuncionario.Name = "painelFuncionario";
            this.painelFuncionario.Size = new System.Drawing.Size(1121, 543);
            this.painelFuncionario.TabIndex = 1;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFinalizar.Enabled = false;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(905, 481);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(191, 52);
            this.btnFinalizar.TabIndex = 31;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click_1);
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(292, 96);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(253, 34);
            this.txtStatus.TabIndex = 30;
            this.txtStatus.Text = "Status";
            // 
            // txtCargo
            // 
            this.txtCargo.Enabled = false;
            this.txtCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargo.Location = new System.Drawing.Point(27, 96);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(253, 34);
            this.txtCargo.TabIndex = 29;
            this.txtCargo.Text = "Cargo";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Enabled = false;
            this.txtMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(483, 36);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(63, 34);
            this.txtMatricula.TabIndex = 28;
            this.txtMatricula.Text = "ID";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Enabled = false;
            this.txtDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartamento.Location = new System.Drawing.Point(27, 159);
            this.txtDepartamento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(401, 34);
            this.txtDepartamento.TabIndex = 27;
            this.txtDepartamento.Text = "Departamento";
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(27, 36);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(447, 34);
            this.txtNome.TabIndex = 26;
            this.txtNome.Text = "Nome";
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
            this.cbxSituacao.Location = new System.Drawing.Point(935, 218);
            this.cbxSituacao.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSituacao.Name = "cbxSituacao";
            this.cbxSituacao.Size = new System.Drawing.Size(160, 28);
            this.cbxSituacao.TabIndex = 23;
            this.cbxSituacao.Text = "Todas";
            this.cbxSituacao.SelectedIndexChanged += new System.EventHandler(this.cbxSituacao_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(509, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 29);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ocorrências";
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
            this.grdOcorrencias.Location = new System.Drawing.Point(27, 256);
            this.grdOcorrencias.Margin = new System.Windows.Forms.Padding(5);
            this.grdOcorrencias.Name = "grdOcorrencias";
            this.grdOcorrencias.ReadOnly = true;
            this.grdOcorrencias.RowHeadersVisible = false;
            this.grdOcorrencias.RowHeadersWidth = 51;
            this.grdOcorrencias.Size = new System.Drawing.Size(1069, 204);
            this.grdOcorrencias.TabIndex = 7;
            this.grdOcorrencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOcorrencias_CellClick);
            this.grdOcorrencias.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdOcorrencias_CellMouseClick);
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.BackgroundImage = global::Ocorrências_CPD.Properties.Resources.desconectar;
            this.desconectarToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.desconectarToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectarToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.desconectarToolStripMenuItem.Location = new System.Drawing.Point(1101, 11);
            this.desconectarToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4);
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            this.desconectarToolStripMenuItem.Size = new System.Drawing.Size(33, 31);
            this.desconectarToolStripMenuItem.TabIndex = 33;
            this.desconectarToolStripMenuItem.UseVisualStyleBackColor = true;
            this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.desconectarToolStripMenuItem_Click);
            // 
            // frmFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ocorrências_CPD.Properties.Resources.bagkground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1149, 592);
            this.Controls.Add(this.desconectarToolStripMenuItem);
            this.Controls.Add(this.painelFuncionario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmFuncionario";
            this.Text = "Ocorrências CPD - Funcionário";
            this.painelFuncionario.ResumeLayout(false);
            this.painelFuncionario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel painelFuncionario;
        private System.Windows.Forms.ComboBox cbxSituacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdOcorrencias;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button desconectarToolStripMenuItem;
        private System.Windows.Forms.Button btnFinalizar;
    }
}