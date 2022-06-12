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
        public frmCadastrarGerente()
        {
            InitializeComponent();
            atualizarTabelas();
            habilitaControles(false);
            gerenciaBotoesBarra(true);
            popularComboX();

        }

        //INSTANCIAMENTO DE CLASSES
        csGerente geren = new csGerente();
        csDepartamento departamento = new csDepartamento();

        //CRIAÇÃO DE VARIAVEIS
        private string statusGeren;
        private int numeroDepartamento;

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas()
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
            if (geren.getIdGerente() != 0)
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
            if (geren.getIdGerente() != 0)
            {
                if (MessageBox.Show("Deseja tornar o Gerente selecionado inativo?", "Alteração",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    geren.delete();
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

            txtNome.Text = geren.getNomeGerente();
            txtMatricula.Text = geren.getIdGerente().ToString();
            txtCargo.Text = "Gerente";
            cbxDepartamento.Text = geren.getDepartamentoGerente();
            cbxStatus.Text = geren.getStatusGerente();
        }
        private void limparControles()
        {
            geren.setIdGerente(0);
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
            //Sets do gerentes
            geren.setCargoGerente(txtCargo.Text.ToLower());
            geren.setDepartamentoGerente(cbxDepartamento.SelectedIndex);
            geren.setNomeGerente(txtNome.Text);
            geren.setStatusGerente(cbxStatus.Text);


            if (geren.getIdGerente() == 0)
            {
                //Novo gerentes
                geren.setIdGerente(Convert.ToInt32(txtMatricula.Text));
                geren.inserir();


            }
            else
            {
                //Atualizar gerentes atual
                geren.update();
            }

        }

        //PREENCHIMENTO DA TABELA GERENTE
        private void checkarSelectGerente()
        { //Checka qual filtro deve ser aplicado para mostrar os gerentes
            if (cbxStatus.Text == "Todos" && cbxDepartamento.Text == "")
            { grdGerentes.DataSource = geren.selectTodosGerentes(); }
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
                geren.setIdGerente(Convert.ToInt32(grdGerentes.Rows[grdGerentes.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }

            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }
    }
}