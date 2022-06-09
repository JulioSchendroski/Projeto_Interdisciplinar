using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocorrências_CPD
{
    public partial class ocorrenciasCPD : Form
    {
        public ocorrenciasCPD()
        {
            InitializeComponent();
        }
        
        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            frmFuncionario fFuncionario = new frmFuncionario();
            fFuncionario.ShowDialog();
        }

        private void btnDiretor_Click(object sender, EventArgs e)
        {
            frmDiretor fDiretor = new frmDiretor();
            fDiretor.ShowDialog();
        }

        private void btnGerente_Click(object sender, EventArgs e)
        {
           frmGerente fGerente = new frmGerente();
           fGerente.ShowDialog();
        }
    }
}
