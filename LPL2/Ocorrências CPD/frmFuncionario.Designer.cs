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
            this.label2 = new System.Windows.Forms.Label();
            this.grdOcorrencias = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.panelFuncionario.Controls.Add(this.label2);
            this.panelFuncionario.Controls.Add(this.grdOcorrencias);
            this.panelFuncionario.Controls.Add(this.label1);
            this.panelFuncionario.Controls.Add(this.button1);
            this.panelFuncionario.Controls.Add(this.grdFuncionarios);
            this.panelFuncionario.Location = new System.Drawing.Point(12, 12);
            this.panelFuncionario.Name = "panelFuncionario";
            this.panelFuncionario.Size = new System.Drawing.Size(838, 457);
            this.panelFuncionario.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(442, 14);
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
            this.grdOcorrencias.Location = new System.Drawing.Point(446, 38);
            this.grdOcorrencias.Margin = new System.Windows.Forms.Padding(4);
            this.grdOcorrencias.Name = "grdOcorrencias";
            this.grdOcorrencias.ReadOnly = true;
            this.grdOcorrencias.Size = new System.Drawing.Size(388, 415);
            this.grdOcorrencias.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Funcionários";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdOcorrencias;
        private System.Windows.Forms.Label label1;
    }
}