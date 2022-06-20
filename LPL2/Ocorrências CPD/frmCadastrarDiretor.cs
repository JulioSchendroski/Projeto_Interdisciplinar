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
    public partial class frmCadastrarDiretor : Form
    {
        //CONTRUTORES
        Int32 id;
        Int32 depto;

        public frmCadastrarDiretor(int id, int depto)
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

        //CRIAÇÃO DE VARIAVEIS
        private string statusDiretor;

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas() //atualiza dados das tabelas
        {
            grdDiretor.DataSource = diretor.selectTodosDiretor();
            formataGridDiretor();
        }

        private void formataGridDiretor() //formata as colunas da tabela diretor
        {
            grdDiretor.Columns[0].HeaderText = "ID"; //matricula
            grdDiretor.Columns[1].HeaderText = "Nome"; //nome
            grdDiretor.Columns[2].HeaderText = "Status"; //status
            grdDiretor.Columns[3].HeaderText = "Cargo"; //cargo

            grdDiretor.Columns[0].Width = 30; //matricula
            grdDiretor.Columns[1].Width = 150; //nome
            grdDiretor.Columns[2].Width = 70; //status
            grdDiretor.Columns[3].Width = 70; //cargo

            grdDiretor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //POPULANDO COMBOBOX

        //EVENTOS DOS BOTÕES
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar a manutenção dos diretors?", "Aviso!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (diretor.getIdPessoa() != 0)
            {
                habilitaControles(true);
                gerenciaBotoesBarra(false);
                atualizarTabelas();
                txtMatricula.Enabled = false;
            }
            else
            {
                MessageBox.Show("Selecione o Diertor para a alteração", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e) //Torna o diretor inativo
        {
            if (diretor.getIdPessoa() != 0)
            {
                if (MessageBox.Show("Deseja tornar o Diretor selecionado inativo?", "Alteração",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    diretor.delete();
                    limparControles();
                    atualizarTabelas();
                }
            }
            else
            {
                MessageBox.Show("Selecione o Diretor para a exclusão", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                salvarDiretor();
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
        private void preencheDadosControles() //Altera os txtBox e cbx ao selecionario um diretor
        {
            diretor.selectDiretor();

            txtNome.Text = diretor.getNomePessoa();
            txtMatricula.Text = diretor.getIdPessoa().ToString();
            txtCargo.Text = "Diretor";
            cbxStatus.Text = diretor.getStatusPessoa();
        }
        private void limparControles() //limpa dos campos dos txtbox e cbx
        {
            diretor.setIdPessoa(0);
            txtMatricula.Text = "";
            txtNome.Text = "";
            cbxStatus.SelectedIndex = -1;
        }

        private void habilitaControles(bool status) //habilita/desabilita os txtbox e cbx
        {
            txtNome.Enabled = status;
            txtMatricula.Enabled = status;
            cbxStatus.Enabled = status;
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
        private bool validaDados() //verifica se todos os campos foram preenchidos
        {
            if (txtNome.Text.Trim().Length <= 1)
            {
                MessageBox.Show("O nome do Diretor é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (txtMatricula.Text.Trim().Length < 1)
            {
                MessageBox.Show("A matrícula do Diretor é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (cbxStatus.Text.Trim().Length < 1)
            {
                cbxStatus.Text = "ativo";
            }

            return true;
        }

        //SALVAR OS DIRETORES NO BD
        private void salvarDiretor()
        {
            //Sets do diretores
            diretor.setCargoPessoa(txtCargo.Text.ToLower());
            diretor.setNomePessoa(txtNome.Text);
            diretor.setStatusPessoa(cbxStatus.Text);


            if (diretor.getIdPessoa() == 0)
            {
                //Novo diretor
                diretor.setIdPessoa(Convert.ToInt32(txtMatricula.Text));
                diretor.inserir();
            }
            else
            {
                //Atualizar diertor atual
                diretor.update();
            }
        }

        //PREENCHIMENTO DA TABELA DIRETOR
        private void checkarSelectDiretor()
        { //Checka qual filtro deve ser aplicado para mostrar os diretor
            if (cbxFiltroStatus.Text == "Todos")
            { grdDiretor.DataSource = diretor.selectTodosDiretor(); }
            else if (cbxFiltroStatus.Text != "Todos")
            {
                statusDiretor = cbxFiltroStatus.Text;
                grdDiretor.DataSource = diretor.selectDiretorStatus(statusDiretor);
            }

        }

        //AÇÃO AO CLICAR NOS FILTROS 
        private void cbxFiltroDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        private void cbxFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkarSelectDiretor();
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {

            atualizarTabelas();
        }

        //AÇÃO AO CLICAR NAS CELULAS DA TABELA DIRETOR
        private void grdDiretor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                diretor.setIdPessoa(Convert.ToInt32(grdDiretor.Rows[grdDiretor.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        //AÇÃO AO FECHAR FORMULÁRIO
        private void frmCadastrarDiretor_FormClosed(object sender, FormClosedEventArgs e) //abre a janela diretor quando a janela é fechada
        {
            csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto);
            abrirJanelas.abrirJanelaDiretor();
        }
    }
}