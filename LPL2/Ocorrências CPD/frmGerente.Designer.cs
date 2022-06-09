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
            this.painelGerente = new System.Windows.Forms.Panel();
            this.grdFuncionarios = new System.Windows.Forms.DataGridView();
            this.grdOcorrencias = new System.Windows.Forms.DataGridView();
            this.painelGerente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFuncionarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).BeginInit();
            this.SuspendLayout();
            // 
            // painelGerente
            // 
            this.painelGerente.Controls.Add(this.grdOcorrencias);
            this.painelGerente.Controls.Add(this.grdFuncionarios);
            this.painelGerente.Location = new System.Drawing.Point(13, 12);
            this.painelGerente.Name = "painelGerente";
            this.painelGerente.Size = new System.Drawing.Size(841, 461);
            this.painelGerente.TabIndex = 0;
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
            this.grdFuncionarios.Location = new System.Drawing.Point(4, 151);
            this.grdFuncionarios.Margin = new System.Windows.Forms.Padding(4);
            this.grdFuncionarios.Name = "grdFuncionarios";
            this.grdFuncionarios.ReadOnly = true;
            this.grdFuncionarios.Size = new System.Drawing.Size(398, 306);
            this.grdFuncionarios.TabIndex = 6;
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
            this.grdOcorrencias.Location = new System.Drawing.Point(439, 151);
            this.grdOcorrencias.Margin = new System.Windows.Forms.Padding(4);
            this.grdOcorrencias.Name = "grdOcorrencias";
            this.grdOcorrencias.ReadOnly = true;
            this.grdOcorrencias.Size = new System.Drawing.Size(398, 306);
            this.grdOcorrencias.TabIndex = 7;
            // 
            // frmGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 485);
            this.Controls.Add(this.painelGerente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGerente";
            this.Text = "Ocorrências CPD - Gerente";
            this.painelGerente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFuncionarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel painelGerente;
        private System.Windows.Forms.DataGridView grdOcorrencias;
        private System.Windows.Forms.DataGridView grdFuncionarios;
    }
}