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
    public partial class frmCadastrarGerente : Form
    {
        //CONTRUTORES
        Int32 id;
        Int32 depto_cod;

        public frmCadastrarGerente(int id, int depto_cod)
        {
            InitializeComponent();
            atualizarTabelas();
            habilitaControles(false);
            gerenciaBotoesBarra(true);
            popularComboX();
            this.id = id;
            this.depto_cod = depto_cod;
        }

        //INSTANCIAMENTO DE CLASSES
        csDiretor diretor = new csDiretor();
        csGerente geren = new csGerente();
        csDepartamento departamento = new csDepartamento();

        //CRIAÇÃO DE VARIAVEIS
        private string statusGeren;
        private int numeroDepartamento;

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas() //atualiza dados das tabelas
        {
            grdGerentes.DataSource = geren.selectTodosGerentes();
            checkarSelectGerente();
            formataGridGerentes();
        }

        private void formataGridGerentes() //formata as colunas da tabela gerente
        {
            grdGerentes.Columns[0].HeaderText = "ID"; //matricula
            grdGerentes.Columns[1].HeaderText = "Nome"; //nome
            grdGerentes.Columns[2].HeaderText = "Status"; //status
            grdGerentes.Columns[3].HeaderText = "Cargo"; //cargo
            grdGerentes.Columns[4].HeaderText = "Departamento"; //departamento

            grdGerentes.Columns[0].Width = 30; //matricula
            grdGerentes.Columns[1].Width = 150; //nome
            grdGerentes.Columns[2].Width = 70; //status
            grdGerentes.Columns[3].Width = 70; //cargo
            grdGerentes.Columns[4].Width = 150; //departamento

            grdGerentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //POPULANDO COMBOBOX
        private void popularComboX()
        {
            //populando combobox do departamento
            cbxDepartamento.DataSource = departamento.selectTodosDepartamentos();
            cbxDepartamento.ValueMember = "codigo";
            cbxDepartamento.DisplayMember = "nome";

            cbxDepartamento.SelectedIndex = -1;

            cbxFiltroDepartamento.DataSource = departamento.selectTodosDepartamentos();
            cbxFiltroDepartamento.ValueMember = "codigo";
            cbxFiltroDepartamento.DisplayMember = "nome";

            cbxFiltroDepartamento.SelectedIndex = -1;
        }

        //EVENTOS DOS BOTÕES
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar a manutenção dos gerentes?", "Aviso!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (geren.getIdPessoa() != 0)
            {
                habilitaControles(true);
                gerenciaBotoesBarra(false);
                atualizarTabelas();
                txtMatricula.Enabled = false;
            }
            else
            {
                MessageBox.Show("Selecione o Gerente para a alteração", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) //Torna o gerente inativo
        {
            if (geren.getIdPessoa() != 0)
            {
                if (MessageBox.Show("Deseja tornar o Gerente selecionado inativo?", "Alteração",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    diretor.inativaGerente(geren);
                    limparControles();
                    atualizarTabelas();
                }
            }
            else
            {
                MessageBox.Show("Selecione o Gerente para a exclusão", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                salvarGerente();
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
        private void preencheDadosControles() //Altera os txtBox e cbx ao selecionario um gerentes
        {
            geren.selectGeren();

            txtNome.Text = geren.getNomePessoa();
            txtMatricula.Text = geren.getIdPessoa().ToString();
            txtCargo.Text = "Gerente";
            cbxDepartamento.Text = geren.getDepartamentoPessoa();
            cbxStatus.Text = geren.getStatusPessoa();
        }
        private void limparControles() //limpa dos campos dos txtbox e cbx
        {
            geren.setIdPessoa(0);
            txtMatricula.Text = "";
            txtNome.Text = "";
            cbxDepartamento.SelectedIndex = -1;
            cbxStatus.SelectedIndex = -1;
        }

        private void habilitaControles(bool status) //habilita/desabilita os txtbox e cbx
        {
            txtNome.Enabled = status;
            txtMatricula.Enabled = status;
            cbxDepartamento.Enabled = status;
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
                MessageBox.Show("O nome do gerente é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (txtMatricula.Text.Trim().Length < 1)
            {
                MessageBox.Show("A matrícula do gerente é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (cbxDepartamento.Text.Trim().Length < 1)
            {
                MessageBox.Show("O departamento do gerente é obrigatório.",
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

        //SALVAR OS GERENTES NO BD
        private void salvarGerente()
        {
            if (geren.getIdPessoa() == 0)
            {
                //Novo gerentes
                diretor.criaGerente(geren, Convert.ToInt32(txtMatricula.Text), txtNome.Text, cbxStatus.Text, txtCargo.Text.ToLower(),
                    cbxDepartamento.SelectedIndex);
            }
            else
            {
                //Atualizar gerentes atual
                diretor.alteraGerente(geren, txtNome.Text, cbxStatus.Text, cbxDepartamento.SelectedIndex);
            }

        }

        //PREENCHIMENTO DA TABELA GERENTE
        private void checkarSelectGerente()
        {
            //Checka qual filtro deve ser aplicado para mostrar os gerentes
            if (cbxStatus.Text == "Todos" && cbxDepartamento.Text == "")
            {
                grdGerentes.DataSource = geren.selectTodosGerentes();
            }
            else if (cbxFiltroStatus.Text != "Todos" && cbxFiltroDepartamento.Text == "")
            {
                statusGeren = cbxFiltroStatus.Text;
                grdGerentes.DataSource = geren.selectGerentesStatus(statusGeren);
            }
            else if (cbxFiltroStatus.Text == "Todos" && cbxFiltroDepartamento.Text != "")
            {
                numeroDepartamento = cbxFiltroDepartamento.SelectedIndex;
                grdGerentes.DataSource = geren.selectGerentesDepartamento(numeroDepartamento);
            }
            else if (cbxFiltroStatus.Text != "Todos" && cbxFiltroDepartamento.Text != "")
            {
                statusGeren = cbxFiltroStatus.Text;
                numeroDepartamento = cbxFiltroDepartamento.SelectedIndex;
                grdGerentes.DataSource = geren.selectGerentesStatusDepartamentos(statusGeren, numeroDepartamento);
            }
        }

        //AÇÃO AO CLICAR NOS FILTROS 
        private void cbxFiltroDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        private void cbxFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            cbxFiltroDepartamento.SelectedIndex = -1;
            atualizarTabelas();
        }

        //AÇÃO AO CLICAR NAS CELULAS DA TABELA GERENTE
        private void grdGerentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                geren.setIdPessoa(Convert.ToInt32(grdGerentes.Rows[grdGerentes.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }

            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        //AÇÃO AO FECHAR FORMULÁRIO
        private void frmCadastrarGerente_FormClosed(object sender, FormClosedEventArgs e) //abre a janela diretor quando a janela é fechada
        {
            csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto_cod);
            abrirJanelas.abrirJanelaDiretor();
        }
    }
}