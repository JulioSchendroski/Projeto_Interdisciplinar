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

        private Int32 idPessoa;
        private string cargo;

        csFuncionario func = new csFuncionario();
        

        //CONFERE OS DADOS DO LOGIN
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text == "diretor" || txtCargo.Text == "gerente" || txtCargo.Text == "funcionário") {
                try
                {
                    cargo = txtCargo.Text;
                    idPessoa = Convert.ToInt32(Convert.ToDouble(txtMatricula.Text));
                    func.selectEntrar(idPessoa, cargo);
                }
                catch (Exception) {
                  MessageBox.Show("Dados incorretos! Tente novamente:", "Erro!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Dados incorretos! Tente novamente:", "Erro!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }
    }
}
