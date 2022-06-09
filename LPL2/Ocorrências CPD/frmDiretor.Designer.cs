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
            this.grdGerentes = new System.Windows.Forms.DataGridView();
            this.grdDepartamentos = new System.Windows.Forms.DataGridView();
            this.painelDiretor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGerentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // painelDiretor
            // 
            this.painelDiretor.Controls.Add(this.grdDepartamentos);
            this.painelDiretor.Controls.Add(this.grdGerentes);
            this.painelDiretor.Location = new System.Drawing.Point(13, 12);
            this.painelDiretor.Name = "painelDiretor";
            this.painelDiretor.Size = new System.Drawing.Size(841, 461);
            this.painelDiretor.TabIndex = 0;
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
            this.grdGerentes.Location = new System.Drawing.Point(4, 44);
            this.grdGerentes.Margin = new System.Windows.Forms.Padding(4);
            this.grdGerentes.Name = "grdGerentes";
            this.grdGerentes.ReadOnly = true;
            this.grdGerentes.Size = new System.Drawing.Size(398, 380);
            this.grdGerentes.TabIndex = 7;
            // 
            // grdDepartamentos
            // 
            this.grdDepartamentos.AllowUserToAddRows = false;
            this.grdDepartamentos.AllowUserToDeleteRows = false;
            this.grdDepartamentos.AllowUserToResizeColumns = false;
            this.grdDepartamentos.AllowUserToResizeRows = false;
            this.grdDepartamentos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDepartamentos.BackgroundColor = System.Drawing.Color.White;
            this.grdDepartamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDepartamentos.GridColor = System.Drawing.Color.DarkGray;
            this.grdDepartamentos.Location = new System.Drawing.Point(428, 118);
            this.grdDepartamentos.Margin = new System.Windows.Forms.Padding(4);
            this.grdDepartamentos.Name = "grdDepartamentos";
            this.grdDepartamentos.ReadOnly = true;
            this.grdDepartamentos.Size = new System.Drawing.Size(398, 306);
            this.grdDepartamentos.TabIndex = 8;
            // 
            // frmDiretor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 485);
            this.Controls.Add(this.painelDiretor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDiretor";
            this.Text = "Ocorrências CPD - Diretor";
            this.painelDiretor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGerentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel painelDiretor;
        private System.Windows.Forms.DataGridView grdDepartamentos;
        private System.Windows.Forms.DataGridView grdGerentes;
    }
}