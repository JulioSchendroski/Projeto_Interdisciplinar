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
            this.painelDiretor = new System.Windows.Forms.Panel();
            this.cbxOrdenarOcorrencias = new System.Windows.Forms.ComboBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.cbxDepartamento = new System.Windows.Forms.ComboBox();
            this.cbxOrdenarFuncionarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdDepartamentos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.grdGerentes = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.painelDiretor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGerentes)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // painelDiretor
            // 
            this.painelDiretor.Controls.Add(this.cbxOrdenarOcorrencias);
            this.painelDiretor.Controls.Add(this.cbxStatus);
            this.painelDiretor.Controls.Add(this.cbxDepartamento);
            this.painelDiretor.Controls.Add(this.cbxOrdenarFuncionarios);
            this.painelDiretor.Controls.Add(this.label2);
            this.painelDiretor.Controls.Add(this.grdDepartamentos);
            this.painelDiretor.Controls.Add(this.label1);
            this.painelDiretor.Controls.Add(this.btnAtualizar);
            this.painelDiretor.Controls.Add(this.grdGerentes);
            this.painelDiretor.Location = new System.Drawing.Point(13, 27);
            this.painelDiretor.Name = "painelDiretor";
            this.painelDiretor.Size = new System.Drawing.Size(841, 446);
            this.painelDiretor.TabIndex = 1;
            // 
            // cbxOrdenarOcorrencias
            // 
            this.cbxOrdenarOcorrencias.FormattingEnabled = true;
            this.cbxOrdenarOcorrencias.Items.AddRange(new object[] {
            "Ordenar",
            "Data",
            "Status",
            "Funcionário",
            "Departamento"});
            this.cbxOrdenarOcorrencias.Location = new System.Drawing.Point(714, 112);
            this.cbxOrdenarOcorrencias.Name = "cbxOrdenarOcorrencias";
            this.cbxOrdenarOcorrencias.Size = new System.Drawing.Size(121, 21);
            this.cbxOrdenarOcorrencias.TabIndex = 25;
            this.cbxOrdenarOcorrencias.Text = "Ordenar";
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Status",
            "Ativo",
            "Inativo"});
            this.cbxStatus.Location = new System.Drawing.Point(146, 112);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(121, 21);
            this.cbxStatus.TabIndex = 23;
            this.cbxStatus.Text = "Status";
            // 
            // cbxDepartamento
            // 
            this.cbxDepartamento.FormattingEnabled = true;
            this.cbxDepartamento.Location = new System.Drawing.Point(8, 112);
            this.cbxDepartamento.Name = "cbxDepartamento";
            this.cbxDepartamento.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartamento.TabIndex = 22;
            this.cbxDepartamento.Text = "Departamento";
            // 
            // cbxOrdenarFuncionarios
            // 
            this.cbxOrdenarFuncionarios.FormattingEnabled = true;
            this.cbxOrdenarFuncionarios.Items.AddRange(new object[] {
            "Ordenar",
            "Funcionário",
            "Departamento",
            "Status"});
            this.cbxOrdenarFuncionarios.Location = new System.Drawing.Point(282, 112);
            this.cbxOrdenarFuncionarios.Name = "cbxOrdenarFuncionarios";
            this.cbxOrdenarFuncionarios.Size = new System.Drawing.Size(121, 21);
            this.cbxOrdenarFuncionarios.TabIndex = 21;
            this.cbxOrdenarFuncionarios.Text = "Ordenar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(590, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Departamentos";
            // 
            // grdDepartamentos
            // 
            this.grdDepartamentos.AllowUserToAddRows = false;
            this.grdDepartamentos.AllowUserToDeleteRows = false;
            this.grdDepartamentos.AllowUserToResizeColumns = false;
            this.grdDepartamentos.AllowUserToResizeRows = false;
            this.grdDepartamentos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDepartamentos.BackgroundColor = System.Drawing.Color.White;
            this.grdDepartamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDepartamentos.GridColor = System.Drawing.Color.DarkGray;
            this.grdDepartamentos.Location = new System.Drawing.Point(447, 136);
            this.grdDepartamentos.Margin = new System.Windows.Forms.Padding(4);
            this.grdDepartamentos.Name = "grdDepartamentos";
            this.grdDepartamentos.ReadOnly = true;
            this.grdDepartamentos.Size = new System.Drawing.Size(388, 291);
            this.grdDepartamentos.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Gerentes";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(692, 18);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(143, 34);
            this.btnAtualizar.TabIndex = 17;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // grdGerentes
            // 
            this.grdGerentes.AllowUserToAddRows = false;
            this.grdGerentes.AllowUserToDeleteRows = false;
            this.grdGerentes.AllowUserToResizeColumns = false;
            this.grdGerentes.AllowUserToResizeRows = false;
            this.grdGerentes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdGerentes.BackgroundColor = System.Drawing.Color.White;
            this.grdGerentes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdGerentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGerentes.GridColor = System.Drawing.Color.DarkGray;
            this.grdGerentes.Location = new System.Drawing.Point(5, 136);
            this.grdGerentes.Margin = new System.Windows.Forms.Padding(4);
            this.grdGerentes.Name = "grdGerentes";
            this.grdGerentes.ReadOnly = true;
            this.grdGerentes.Size = new System.Drawing.Size(398, 291);
            this.grdGerentes.TabIndex = 16;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 29);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenteToolStripMenuItem,
            this.departamentoToolStripMenuItem});
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar";
            // 
            // gerenteToolStripMenuItem
            // 
            this.gerenteToolStripMenuItem.Name = "gerenteToolStripMenuItem";
            this.gerenteToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.gerenteToolStripMenuItem.Text = "Gerente";
            // 
            // departamentoToolStripMenuItem
            // 
            this.departamentoToolStripMenuItem.Name = "departamentoToolStripMenuItem";
            this.departamentoToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.departamentoToolStripMenuItem.Text = "Departamento";
            // 
            // frmDiretor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 485);
            this.Controls.Add(this.painelDiretor);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDiretor";
            this.Text = "Ocorrências CPD - Diretor";
            this.painelDiretor.ResumeLayout(false);
            this.painelDiretor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGerentes)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel painelDiretor;
        private System.Windows.Forms.ComboBox cbxOrdenarOcorrencias;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.ComboBox cbxDepartamento;
        private System.Windows.Forms.ComboBox cbxOrdenarFuncionarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdDepartamentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridView grdGerentes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem;
    }
}