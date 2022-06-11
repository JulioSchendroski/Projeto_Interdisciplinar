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
            this.panelFuncionario = new System.Windows.Forms.Panel();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.cbxOrdenarOcorrencias = new System.Windows.Forms.ComboBox();
            this.cbxSituacao = new System.Windows.Forms.ComboBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.cbxDepartamento = new System.Windows.Forms.ComboBox();
            this.cbxOrdenarFuncionarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdOcorrencias = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.grdFuncionarios = new System.Windows.Forms.DataGridView();
            this.panelFuncionario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFuncionarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFuncionario
            // 
            this.panelFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFuncionario.Controls.Add(this.btnFinalizar);
            this.panelFuncionario.Controls.Add(this.cbxOrdenarOcorrencias);
            this.panelFuncionario.Controls.Add(this.cbxSituacao);
            this.panelFuncionario.Controls.Add(this.cbxStatus);
            this.panelFuncionario.Controls.Add(this.cbxDepartamento);
            this.panelFuncionario.Controls.Add(this.cbxOrdenarFuncionarios);
            this.panelFuncionario.Controls.Add(this.label2);
            this.panelFuncionario.Controls.Add(this.grdOcorrencias);
            this.panelFuncionario.Controls.Add(this.label1);
            this.panelFuncionario.Controls.Add(this.btnAtualizar);
            this.panelFuncionario.Controls.Add(this.grdFuncionarios);
            this.panelFuncionario.Location = new System.Drawing.Point(12, 12);
            this.panelFuncionario.Name = "panelFuncionario";
            this.panelFuncionario.Size = new System.Drawing.Size(838, 457);
            this.panelFuncionario.TabIndex = 0;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(691, 407);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(143, 32);
            this.btnFinalizar.TabIndex = 16;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
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
            this.cbxOrdenarOcorrencias.Location = new System.Drawing.Point(713, 123);
            this.cbxOrdenarOcorrencias.Name = "cbxOrdenarOcorrencias";
            this.cbxOrdenarOcorrencias.Size = new System.Drawing.Size(121, 21);
            this.cbxOrdenarOcorrencias.TabIndex = 15;
            this.cbxOrdenarOcorrencias.Text = "Ordenar";
            // 
            // cbxSituacao
            // 
            this.cbxSituacao.FormattingEnabled = true;
            this.cbxSituacao.Items.AddRange(new object[] {
            "Situação",
            "Pendente",
            "Concluída"});
            this.cbxSituacao.Location = new System.Drawing.Point(582, 123);
            this.cbxSituacao.Name = "cbxSituacao";
            this.cbxSituacao.Size = new System.Drawing.Size(121, 21);
            this.cbxSituacao.TabIndex = 14;
            this.cbxSituacao.Text = "Situação";
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Status",
            "ativo",
            "inativo"});
            this.cbxStatus.Location = new System.Drawing.Point(145, 123);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(121, 21);
            this.cbxStatus.TabIndex = 12;
            this.cbxStatus.Text = "Status";
            // 
            // cbxDepartamento
            // 
            this.cbxDepartamento.FormattingEnabled = true;
            this.cbxDepartamento.Location = new System.Drawing.Point(7, 123);
            this.cbxDepartamento.Name = "cbxDepartamento";
            this.cbxDepartamento.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartamento.TabIndex = 11;
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
            this.cbxOrdenarFuncionarios.Location = new System.Drawing.Point(281, 123);
            this.cbxOrdenarFuncionarios.Name = "cbxOrdenarFuncionarios";
            this.cbxOrdenarFuncionarios.Size = new System.Drawing.Size(121, 21);
            this.cbxOrdenarFuncionarios.TabIndex = 10;
            this.cbxOrdenarFuncionarios.Text = "Ordenar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(589, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ocorrências";
            // 
            // grdOcorrencias
            // 
            this.grdOcorrencias.AllowUserToAddRows = false;
            this.grdOcorrencias.AllowUserToDeleteRows = false;
            this.grdOcorrencias.AllowUserToResizeColumns = false;
            this.grdOcorrencias.AllowUserToResizeRows = false;
            this.grdOcorrencias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOcorrencias.BackgroundColor = System.Drawing.Color.White;
            this.grdOcorrencias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdOcorrencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOcorrencias.GridColor = System.Drawing.Color.DarkGray;
            this.grdOcorrencias.Location = new System.Drawing.Point(446, 147);
            this.grdOcorrencias.Margin = new System.Windows.Forms.Padding(4);
            this.grdOcorrencias.Name = "grdOcorrencias";
            this.grdOcorrencias.ReadOnly = true;
            this.grdOcorrencias.Size = new System.Drawing.Size(388, 253);
            this.grdOcorrencias.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Funcionários";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(691, 29);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(143, 34);
            this.btnAtualizar.TabIndex = 6;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // grdFuncionarios
            // 
            this.grdFuncionarios.AllowUserToAddRows = false;
            this.grdFuncionarios.AllowUserToDeleteRows = false;
            this.grdFuncionarios.AllowUserToResizeColumns = false;
            this.grdFuncionarios.AllowUserToResizeRows = false;
            this.grdFuncionarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdFuncionarios.BackgroundColor = System.Drawing.Color.White;
            this.grdFuncionarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFuncionarios.GridColor = System.Drawing.Color.DarkGray;
            this.grdFuncionarios.Location = new System.Drawing.Point(4, 147);
            this.grdFuncionarios.Margin = new System.Windows.Forms.Padding(4);
            this.grdFuncionarios.Name = "grdFuncionarios";
            this.grdFuncionarios.ReadOnly = true;
            this.grdFuncionarios.Size = new System.Drawing.Size(398, 306);
            this.grdFuncionarios.TabIndex = 5;
            // 
            // frmFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 481);
            this.Controls.Add(this.panelFuncionario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFuncionario";
            this.Text = "Ocorrências CPD - Funcionário";
            this.panelFuncionario.ResumeLayout(false);
            this.panelFuncionario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFuncionarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFuncionario;
        private System.Windows.Forms.DataGridView grdFuncionarios;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdOcorrencias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxOrdenarOcorrencias;
        private System.Windows.Forms.ComboBox cbxSituacao;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.ComboBox cbxDepartamento;
        private System.Windows.Forms.ComboBox cbxOrdenarFuncionarios;
        private System.Windows.Forms.Button btnFinalizar;
    }
}