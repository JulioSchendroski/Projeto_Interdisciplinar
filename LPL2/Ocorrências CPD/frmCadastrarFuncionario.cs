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
        Int32 depto;
        Int32 id;
        //CONTRUTOR
        public frmCadastrarFuncionario(int id, int depto)
        {
            this.id = id;
            this.depto = depto;
            InitializeComponent();
            atualizarTabelas();
            habilitaControles(false);
            gerenciaBotoesBarra(true);
            popularComboX();
            
        }

        //INSTANCIAMENTO DE CLASSES
        csGerente gerente = new csGerente();
        csFuncionario func = new csFuncionario();
        csDepartamento departamento = new csDepartamento();

        //CRIAÇÃO DE VARIAVEIS
        private string statusFunc;
        //private int numeroDepartamento;

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas() //atualiza os dados das tabelas
        {
            grdFuncionarios.DataSource = func.selectFuncionariosDepartamento(depto);
            checkarSelectFuncionario();
            formataGridFuncionarios();

        }
        private void formataGridFuncionarios() //formata as colunas da tabela Funcionario
        {
            grdFuncionarios.Columns[0].HeaderText = "ID"; //matricula
            grdFuncionarios.Columns[1].HeaderText = "Nome"; //nome
            grdFuncionarios.Columns[2].HeaderText = "Status"; //status
            grdFuncionarios.Columns[3].HeaderText = "Cargo"; //cargo
            grdFuncionarios.Columns[4].HeaderText = "Departamento"; //departamento

            grdFuncionarios.Columns[0].Width = 30; //matricula
            grdFuncionarios.Columns[1].Width = 150; //nome
            grdFuncionarios.Columns[2].Width = 70; //status
            grdFuncionarios.Columns[3].Width = 70; //cargo
            grdFuncionarios.Columns[4].Width = 150; //departamento

            grdFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        //POPULANDO COMBOBOX
        private void popularComboX()
        {

            //populando combobox do departamento
            departamento.setIdDepartamento(depto);
            departamento.selectDepartamento();
            cbxDepartamento.Text = departamento.getNomeDepartamento();
          

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
            if (func.getIdPessoa() != 0)
            {
                habilitaControles(true);
                gerenciaBotoesBarra(false);
                atualizarTabelas();
                txtMatricula.Enabled = false;
            }
            else
            {
                MessageBox.Show("Selecione o Funcionário para a alteração", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e) //Torna o funcionário inativo
        {
            if (func.getIdPessoa() != 0)
            {
                if (MessageBox.Show("Deseja tornar o Funcionário selecionado inativo?", "Alteração",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gerente.inativaFuncionario(func);
                    limparControles();
                    atualizarTabelas();
                }
            }
            else
            {
                MessageBox.Show("Selecione o Funcionário para a exclusão", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void preencheDadosControles() //Altera os txtBox e cbx ao selecionario um funcionario
        {
            func.selectFunc(2);

            txtNome.Text = func.getNomePessoa();
            txtMatricula.Text = func.getIdPessoa().ToString();
            txtCargo.Text = "Funcionário";
            cbxDepartamento.Text= func.getDepartamentoPessoa();
            cbxStatus.Text = func.getStatusPessoa();
        }
        private void limparControles() { //limpa os dados dos txtbox e cbx
            func.setIdPessoa(0);
            txtMatricula.Text = "";
            txtNome.Text = "";
            cbxStatus.SelectedIndex = -1;
        }

        private void habilitaControles(bool status) //habilita/desabilita txtbox e cbx
        {
            txtNome.Enabled = status;
            txtMatricula.Enabled = status;
            cbxStatus.Enabled = status;
        }

        private void gerenciaBotoesBarra(bool status) //habilita/desabilita botões do menustrip
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
                cbxStatus.Text = "ativo";
            }

            return true;
        }

        //SALVAR OS FUNCIONÁRIOS NO BD
        private void salvarFuncionario()
        {
            if (func.getIdPessoa() == 0)
            {
                //Novo Funcionário
                gerente.criaFuncionario(func, Convert.ToInt32(txtMatricula.Text), txtNome.Text, cbxStatus.Text, txtCargo.Text.ToLower(),
                    depto-1);
            }
            else
            {
                //Atualizar funcionario atual
                gerente.alteraFuncionario(func, txtNome.Text, cbxStatus.Text, depto-1);
            }

        }

        //PREENCHIMENTO DA TABELA FUNCIONARIO
        private void checkarSelectFuncionario()
        { //Checka qual filtro deve ser aplicado para mostrar os funcionários
            if (cbxStatus.Text == "Todos")
            { grdFuncionarios.DataSource = func.selectFuncionariosDepartamento(depto); }
            else if (cbxFiltroStatus.Text != "Todos")
            {
                statusFunc = cbxFiltroStatus.Text;
                grdFuncionarios.DataSource = func.selectFuncionariosStatusDepartamentos(statusFunc, depto);
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
            
            atualizarTabelas();
        }

        //AÇÃO AO CLICAR NAS CELULAS DA TABELA FUNCIONARIO
        private void grdFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            try
            {
                func.setIdPessoa(Convert.ToInt32(grdFuncionarios.Rows[grdFuncionarios.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }

            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            */
        }

        //AÇÃO AO FECHAR FORMULÁRIO
        private void frmCadastrarFuncionario_FormClosed(object sender, FormClosedEventArgs e) //abre a janela gerente quando a janela é fechada
        {
            csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto);
            abrirJanelas.abrirJanelaGerente();
        }

        private void grdFuncionarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                func.setIdPessoa(Convert.ToInt32(grdFuncionarios.Rows[grdFuncionarios.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }

            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }
    }
}

