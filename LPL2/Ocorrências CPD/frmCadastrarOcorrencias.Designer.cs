namespace Ocorrências_CPD
{
    partial class frmCadastrarOcorrencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastrarOcorrencias));
            this.cbxDepartamento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdOcorrencias = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAlterar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSalvar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.cbxSituacao = new System.Windows.Forms.ComboBox();
            this.btnResetar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFiltroDepartamento = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxDepartamento
            // 
            this.cbxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDepartamento.FormattingEnabled = true;
            this.cbxDepartamento.Items.AddRange(new object[] {
            "Departamentos"});
            this.cbxDepartamento.Location = new System.Drawing.Point(19, 239);
            this.cbxDepartamento.Name = "cbxDepartamento";
            this.cbxDepartamento.Size = new System.Drawing.Size(247, 28);
            this.cbxDepartamento.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Departamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Funcionário";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.Location = new System.Drawing.Point(15, 97);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(44, 20);
            this.labelData.TabIndex = 33;
            this.labelData.Text = "Data";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(19, 311);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(426, 108);
            this.txtDescricao.TabIndex = 34;
            this.txtDescricao.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Descrição";
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
            this.grdOcorrencias.Location = new System.Drawing.Point(459, 73);
            this.grdOcorrencias.Margin = new System.Windows.Forms.Padding(4);
            this.grdOcorrencias.Name = "grdOcorrencias";
            this.grdOcorrencias.ReadOnly = true;
            this.grdOcorrencias.Size = new System.Drawing.Size(398, 417);
            this.grdOcorrencias.TabIndex = 49;
            this.grdOcorrencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOcorrencias_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.btnAlterar,
            this.btnSalvar,
            this.btnExcluir,
            this.btnCancelar,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(874, 29);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(60, 25);
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(69, 25);
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(65, 25);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(67, 25);
            this.btnExcluir.Text = "Excluir";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 25);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(49, 25);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(19, 175);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(58, 26);
            this.txtID.TabIndex = 51;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(83, 175);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(295, 26);
            this.txtNome.TabIndex = 52;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(385, 175);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(60, 26);
            this.btnPesquisar.TabIndex = 53;
            this.btnPesquisar.Text = "pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(19, 120);
            this.txtData.Mask = "00/00/0000";
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(88, 26);
            this.txtData.TabIndex = 54;
            // 
            // cbxSituacao
            // 
            this.cbxSituacao.FormattingEnabled = true;
            this.cbxSituacao.Items.AddRange(new object[] {
            "Todas",
            "aberta",
            "encerrada"});
            this.cbxSituacao.Location = new System.Drawing.Point(736, 45);
            this.cbxSituacao.Name = "cbxSituacao";
            this.cbxSituacao.Size = new System.Drawing.Size(121, 21);
            this.cbxSituacao.TabIndex = 55;
            this.cbxSituacao.Text = "Todas";
            this.cbxSituacao.SelectedIndexChanged += new System.EventHandler(this.cbxSituacao_SelectedIndexChanged);
            // 
            // btnResetar
            // 
            this.btnResetar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetar.Location = new System.Drawing.Point(549, 18);
            this.btnResetar.Name = "btnResetar";
            this.btnResetar.Size = new System.Drawing.Size(50, 24);
            this.btnResetar.TabIndex = 58;
            this.btnResetar.Text = "Resetar";
            this.btnResetar.UseVisualStyleBackColor = true;
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(458, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 57;
            this.label1.Text = "Departamentos";
            // 
            // cbxFiltroDepartamento
            // 
            this.cbxFiltroDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroDepartamento.FormattingEnabled = true;
            this.cbxFiltroDepartamento.Items.AddRange(new object[] {
            "Status",
            "ativo",
            "inativo"});
            this.cbxFiltroDepartamento.Location = new System.Drawing.Point(459, 45);
            this.cbxFiltroDepartamento.Name = "cbxFiltroDepartamento";
            this.cbxFiltroDepartamento.Size = new System.Drawing.Size(159, 21);
            this.cbxFiltroDepartamento.TabIndex = 56;
            this.cbxFiltroDepartamento.SelectedIndexChanged += new System.EventHandler(this.cbxFiltroDepartamento_SelectedIndexChanged);
            // 
            // frmCadastrarOcorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 493);
            this.Controls.Add(this.btnResetar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxFiltroDepartamento);
            this.Controls.Add(this.cbxSituacao);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.grdOcorrencias);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.cbxDepartamento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadastrarOcorrencias";
            this.Text = "Ocorrências CPD - Cadastrar Ocorrências";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCadastrarOcorrencias_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDepartamento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.RichTextBox txtDescricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdOcorrencias;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnNovo;
        private System.Windows.Forms.ToolStripMenuItem btnAlterar;
        private System.Windows.Forms.ToolStripMenuItem btnSalvar;
        private System.Windows.Forms.ToolStripMenuItem btnExcluir;
        private System.Windows.Forms.ToolStripMenuItem btnCancelar;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.ComboBox cbxSituacao;
        private System.Windows.Forms.Button btnResetar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFiltroDepartamento;
    }
}