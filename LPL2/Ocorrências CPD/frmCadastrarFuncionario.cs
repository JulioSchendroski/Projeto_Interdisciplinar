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
    public partial class frmCadastrarFuncionario : Form
    {
        public frmCadastrarFuncionario()
        {
            InitializeComponent();
            atualizarTabelas();
        }

        csFuncionario func = new csFuncionario();

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas()
        {
            grdFuncionarios.DataSource = func.selectFuncionariosStatus("ativo");
            formataGridFuncionarios();

        }
        private void formataGridFuncionarios()
        {
            grdFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            grdFuncionarios.Columns[0].HeaderText = "Produto";
            grdFuncionarios.Columns[1].HeaderText = "Quantidade";
            grdFuncionarios.Columns[2].HeaderText = "Produto";
            grdFuncionarios.Columns[3].HeaderText = "Quantidade";


            grdFuncionarios.Columns[0].Width = 250;
            grdFuncionarios.Columns[1].Width = 80;

        }

        //EVENTOS DOS BOTÕES
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar a manutenção dos funcionários?", "Aviso!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            habilitaControles(true);
            gerenciaBotoesBarra(false);
            atualizarTabelas();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (/*prod.getIdProd()*/0 != 0)
            {
                if (MessageBox.Show("Deseja excluir o funcionário selecionado?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //excluiProduto();
                    limparControles();
                    atualizarTabelas();
                }
            }
            else
            {
                MessageBox.Show("Selecione o funcionário para a exclusão", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaDados() == true)
            {
                salvarFuncionario();
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
                atualizarTabelas();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitaControles(true);
            limparControles();
            gerenciaBotoesBarra(false);
        }

        //CONTROLE DA GRID
        private void limparControles() {
            func.setIdFuncionario(0);
            txtMatricula.Text = "";
            txtNome.Text = "";
            cbxDepartamento.SelectedIndex = -1;
            cbxStatus.SelectedIndex = -1;
        }

        private void habilitaControles(bool status)
        {
            txtNome.Enabled = status;
            txtMatricula.Enabled = status;
            cbxDepartamento.Enabled = status;
            cbxStatus.Enabled = status;
        }

        private void gerenciaBotoesBarra(bool status)
        {
            btnNovo.Enabled = status;
            btnAlterar.Enabled = status;
            btnExcluir.Enabled = status;
            sairToolStripMenuItem.Enabled = status;
            btnSalvar.Enabled = !status;
            btnCancelar.Enabled = !status;
        }

        //VALIDAÇÃO DOS DADOS
        private bool validaDados()
        {
            if (txtNome.Text.Trim().Length <= 1)
            {
                MessageBox.Show("O nome do funcionário é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (txtMatricula.Text.Trim().Length < 1)
            {
                MessageBox.Show("A matrícula do funcionário é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }
            if (cbxDepartamento.Text.Trim().Length < 1)
            {
                MessageBox.Show("O departamento do funcionário é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }
            if (cbxStatus.Text.Trim().Length < 1)
            {
                MessageBox.Show("O status do funcionário é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            return true;
        }

        //SALVAR OS FUNCIONÁRIOS NO BD
        private void salvarFuncionario()
        {
        }

        
    }
}

