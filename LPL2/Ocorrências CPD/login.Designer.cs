namespace Ocorrências_CPD
{
    partial class ocorrenciasCPD
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ocorrenciasCPD));
            this.btnFuncionario = new System.Windows.Forms.Button();
            this.btnDiretor = new System.Windows.Forms.Button();
            this.btnGerente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.Location = new System.Drawing.Point(103, 184);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Size = new System.Drawing.Size(163, 103);
            this.btnFuncionario.TabIndex = 0;
            this.btnFuncionario.Text = "Funcionário";
            this.btnFuncionario.UseVisualStyleBackColor = true;
            this.btnFuncionario.Click += new System.EventHandler(this.btnFuncionario_Click);
            // 
            // btnDiretor
            // 
            this.btnDiretor.Location = new System.Drawing.Point(342, 184);
            this.btnDiretor.Name = "btnDiretor";
            this.btnDiretor.Size = new System.Drawing.Size(163, 103);
            this.btnDiretor.TabIndex = 1;
            this.btnDiretor.Text = "Diretor";
            this.btnDiretor.UseVisualStyleBackColor = true;
            this.btnDiretor.Click += new System.EventHandler(this.btnDiretor_Click);
            // 
            // btnGerente
            // 
            this.btnGerente.Location = new System.Drawing.Point(590, 184);
            this.btnGerente.Name = "btnGerente";
            this.btnGerente.Size = new System.Drawing.Size(163, 103);
            this.btnGerente.TabIndex = 2;
            this.btnGerente.Text = "Gerente";
            this.btnGerente.UseVisualStyleBackColor = true;
            this.btnGerente.Click += new System.EventHandler(this.btnGerente_Click);
            // 
            // ocorrenciasCPD
            // 
            this.ClientSize = new System.Drawing.Size(862, 481);
            this.Controls.Add(this.btnGerente);
            this.Controls.Add(this.btnDiretor);
            this.Controls.Add(this.btnFuncionario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ocorrenciasCPD";
            this.Text = "Ocorrências CPD";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel painelLogin;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnFuncionario;
        private System.Windows.Forms.Button btnDiretor;
        private System.Windows.Forms.Button btnGerente;
    }
}

