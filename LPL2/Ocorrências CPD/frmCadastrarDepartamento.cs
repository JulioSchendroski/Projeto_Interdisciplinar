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
    public partial class frmCadastrarDepartamento : Form
    {
        //CONSTRUTOR
        Int32 id;
        Int32 depto;

        public frmCadastrarDepartamento(int id, int depto)
        {
            InitializeComponent();
            atualizarTabelas();
            habilitaControles(false);
            gerenciaBotoesBarra(true);
            this.id = id;
            this.depto = depto;
        }

        //INSTANCIAMENTO DE CLASSES
        csDiretor diretor = new csDiretor();
        csDepartamento departamento = new csDepartamento();

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas() //atualiza os dados da tabela
        {
            grdDepartamento.DataSource = departamento.selectTodosDepartamentos();
            formataGridDepartamentos();
        }

        private void formataGridDepartamentos() //formata as colunas da tabela departamento
        {
            grdDepartamento.Columns[0].HeaderText = "ID"; //id
            grdDepartamento.Columns[1].HeaderText = "Nome"; //nome
            grdDepartamento.Columns[2].HeaderText = "Descrição"; //descrição

            grdDepartamento.Columns[0].Width = 30; //matricula
            grdDepartamento.Columns[1].Width = 150; //nome
            grdDepartamento.Columns[2].Width = 500; //descrição

            grdDepartamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //EVENTOS DOS BOTÕES
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar a manutenção dos departamentos?", "Aviso!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (departamento.getIdDepartamento() != 0)
            {
                habilitaControles(true);
                gerenciaBotoesBarra(false);
                atualizarTabelas();
                txtCodigo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Selecione o Departamento para a alteração", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /* 
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (departamento.getIdDepartamento() != 0)
            {
                if (MessageBox.Show("Deseja tornar o Gerente selecionado inativo?", "Alteração",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    departamento.delete();
                    limparControles();
                    atualizarTabelas();
                }
            }
            else
            {
                MessageBox.Show("Selecione o Gerente para a exclusão", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       */

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaDados() == true)
            {
                salvarDepartamento();
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
        private void preencheDadosControles() //Altera os txtBox e cbx ao selecionario um departamento
        {
            departamento.selectDepartamento();

            txtNome.Text = departamento.getNomeDepartamento();
            txtCodigo.Text = departamento.getIdDepartamento().ToString();
            txtDescricao.Text = departamento.getDescricaoDepartamento();
        }
        private void limparControles() //limpa todos os dados das textbox e reseta o id do departamento
        {
            departamento.setIdDepartamento(0);
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtCodigo.Text = "";
        }

        private void habilitaControles(bool status) //habilita/desabilita as textbox
        {
            txtNome.Enabled = status;
            txtCodigo.Enabled = status;
            txtDescricao.Enabled = status;
        }

        private void gerenciaBotoesBarra(bool status) //habilita/desabilita os botões do menustrip
        {
            btnNovo.Enabled = status;
            btnAlterar.Enabled = status;
            btnExcluir.Enabled = status;
            sairToolStripMenuItem.Enabled = status;
            btnSalvar.Enabled = !status;
            btnCancelar.Enabled = !status;
        }

        //VALIDAÇÃO DOS DADOS
        private bool validaDados() //verifica se todos os dados foram preenchidos
        {
            if (txtNome.Text.Trim().Length <= 1)
            {
                MessageBox.Show("O nome do Departamento é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (txtCodigo.Text.Trim().Length < 1)
            {
                MessageBox.Show("O código do Departamento é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (txtDescricao.Text.Trim().Length < 1)
            {
                MessageBox.Show("A descrição do departamento é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            return true;
        }

        //SALVAR OS DEPARTAMENTOS NO BD
        private void salvarDepartamento()
        {
            if (departamento.getIdDepartamento() == 0)
            {
                //Novo departamento
                diretor.criaDepto(departamento, Convert.ToInt32(txtCodigo.Text), txtNome.Text, txtDescricao.Text);
            }
            else
            {
                //Atualizar departamento atual
                diretor.alteraDepto(departamento, txtNome.Text, txtDescricao.Text);
            }
        }

        //AÇÃO AO CLICAR NAS CELULAS DA TABELA DEPARTAMENTO
        private void grdDepartamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            try
            {
                departamento.setIdDepartamento(Convert.ToInt32(grdDepartamento.Rows[grdDepartamento.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            */
        }

        //AÇÃO AO FECHAR FORMULÁRIO
        private void frmCadastrarDepartamento_FormClosed(object sender, FormClosedEventArgs e) //abre janela diretor toda vez que o formulário é fechado
        {
            csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto);
            abrirJanelas.abrirJanelaDiretor();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (departamento.getIdDepartamento() != 0)
            {
                if (MessageBox.Show("Deseja Excluir o departamento?", "Alteração",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    diretor.deletaDepto(departamento);
                    limparControles();
                    atualizarTabelas();
                }
            }
            else
            {
                MessageBox.Show("Selecione o departamento para a exclusão", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdDepartamento_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                departamento.setIdDepartamento(Convert.ToInt32(grdDepartamento.Rows[grdDepartamento.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}