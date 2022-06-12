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
            habilitaControles(false);
            gerenciaBotoesBarra(true);
            popularComboX();
            
        }

        //INSTANCIAMENTO DE CLASSES
        csFuncionario func = new csFuncionario();
        csDepartamento departamento = new csDepartamento();

        //CRIAÇÃO DE VARIAVEIS
        private string statusFunc;
        private int numeroDepartamento;

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas()
        {
            grdFuncionarios.DataSource = func.selectTodosFuncionarios();
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
            if (func.getIdFuncionario() != 0)
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
            if (func.getIdFuncionario() != 0)
            {
                if (MessageBox.Show("Deseja tornar o Funcionário selecionado inativo?", "Alteração",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    func.delete();
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
            func.selectFunc();

            txtNome.Text = func.getNomeFuncionario();
            txtMatricula.Text = func.getIdFuncionario().ToString();
            txtCargo.Text = "Funcionário";
            cbxDepartamento.Text= func.getDepartamentoFuncionario();
            cbxStatus.Text = func.getStatusFuncionario();
        }
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
                cbxStatus.Text = "ativo";
            }

            return true;
        }

        //SALVAR OS FUNCIONÁRIOS NO BD
        private void salvarFuncionario()
        {
            //Sets do funcionários
            func.setCargoFuncionario(txtCargo.Text.ToLower());
            func.setDepartamentoFuncionario(cbxDepartamento.SelectedIndex);
            func.setNomeFuncionario(txtNome.Text);
            func.setStatusFuncionario(cbxStatus.Text);
            

            if (func.getIdFuncionario() == 0)
            {
                //Novo Funcionário
                func.setIdFuncionario(Convert.ToInt32(txtMatricula.Text));
                func.inserir();


            }
            else
            {
                //Atualizar funcionario atual
                func.update();
            }
            
        }

        //PREENCHIMENTO DA TABELA FUNCIONARIO
        private void checkarSelectFuncionario()
        { //Checka qual filtro deve ser aplicado para mostrar os funcionários
            if (cbxStatus.Text == "Todos" && cbxDepartamento.Text == "")
            { grdFuncionarios.DataSource = func.selectTodosFuncionarios(); }
            else if (cbxFiltroStatus.Text != "Todos" && cbxFiltroDepartamento.Text == "")
            {
                statusFunc = cbxFiltroStatus.Text;
                grdFuncionarios.DataSource = func.selectFuncionariosStatus(statusFunc);
            }
            else if (cbxFiltroStatus.Text == "Todos" && cbxFiltroDepartamento.Text != "")
            {
                numeroDepartamento = cbxFiltroDepartamento.SelectedIndex;
                grdFuncionarios.DataSource = func.selectFuncionariosDepartamento(numeroDepartamento);
            }
            else if (cbxFiltroStatus.Text != "Todos" && cbxFiltroDepartamento.Text != "")
            {
                statusFunc = cbxFiltroStatus.Text;
                numeroDepartamento = cbxFiltroDepartamento.SelectedIndex;
                grdFuncionarios.DataSource = func.selectFuncionariosStatusDepartamentos(statusFunc, numeroDepartamento);
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

        //AÇÃO AO CLICAR NAS CELULAS DA TABELA FUNCIONARIO
        private void grdFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                func.setIdFuncionario(Convert.ToInt32(grdFuncionarios.Rows[grdFuncionarios.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }

            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }
    }
}

