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
    public partial class frmCadastrarOcorrencias : Form
    {
        //CONTRUTOR
        Int32 id;
        Int32 depto;
        public frmCadastrarOcorrencias(Int32 id, Int32 depto)
        {
            this.id = id;
            this.depto = depto;
            InitializeComponent();
            atualizarTabelas();
            habilitaControles(false);
            gerenciaBotoesBarra(true);
            //popularComboX();
            preenxeTxtDepto();
        }

        //DECLARAÇÃO DE VARIÁVEIS
        //private Int64 numOcorrencia;
        //private string situacaoOcorrencia;
        //private Int32 numeroDepartamento;

        //INSTANCIAMENTO DE CLASSES
        csGerente gerente = new csGerente();
        csOcorrencias ocorrencias = new csOcorrencias();
        csDepartamento departamento = new csDepartamento();
        //csFuncionario func = new csFuncionario();

        //POPULAR COMBOBOX
        /*
        private void popularComboX()
        {

            //populando combobox do departamento
            cbxDepartamento.DataSource = departamento.selectTodosDepartamentos();
            cbxDepartamento.ValueMember = "codigo";
            cbxDepartamento.DisplayMember = "nome";

            cbxDepartamento.SelectedIndex = -1;

            //populando combobox do departamento
            cbxFiltroDepartamento.DataSource = departamento.selectTodosDepartamentos();
            cbxFiltroDepartamento.ValueMember = "codigo";
            cbxFiltroDepartamento.DisplayMember = "nome";

            cbxFiltroDepartamento.SelectedIndex = -1;

        }
        */

        private void preenxeTxtDepto()
        {
            txtDepto.Enabled = false;
            departamento.setIdDepartamento(depto);
            departamento.selectDepartamento();
            txtDepto.Text = departamento.getNomeDepartamento();
        }

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas() //atualiza os dados das tabelas

        {
            checkarSelectOcorrencias();
            formataGridOcorrencias();

        }
        private void formataGridOcorrencias() //formata as colunas da tabela ocorrências
        {
            grdOcorrencias.Columns[0].HeaderText = "ID"; //id
            grdOcorrencias.Columns[1].HeaderText = "Data"; //data
            grdOcorrencias.Columns[2].HeaderText = "DataLimite"; //data imite
            grdOcorrencias.Columns[3].HeaderText = "STemporário"; //status temporario
            grdOcorrencias.Columns[4].HeaderText = "SDefinitivo"; //status definitivo
            grdOcorrencias.Columns[5].HeaderText = "Descrição"; //descrição
            grdOcorrencias.Columns[6].HeaderText = "Funcionário"; //funcionario
            grdOcorrencias.Columns[7].HeaderText = "Departamento"; //departamento

            grdOcorrencias.Columns[0].Width = 30; //id
            grdOcorrencias.Columns[1].Width = 70; //data
            grdOcorrencias.Columns[2].Width = 70; //data limite
            grdOcorrencias.Columns[3].Width = 70; //status temporario
            grdOcorrencias.Columns[4].Width = 70; //status definitivo
            grdOcorrencias.Columns[5].Width = 260; //descrição
            grdOcorrencias.Columns[6].Width = 150; //funcionario
            grdOcorrencias.Columns[7].Width = 150; //departamento

            grdOcorrencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        //EVENTOS DOS BOTÕES
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar a manutenção das ocorrências?", "Aviso!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (ocorrencias.getONumero() != 0)
            {
                habilitaControles(true);
                gerenciaBotoesBarra(false);
                atualizarTabelas();
                
            }
            else
            {
                MessageBox.Show("Selecione a ocorrência para a alteração", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtNome.Text == "") {
                    MessageBox.Show("Funcionário não pertence ao departamento de informática", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    salvarOcorrencia();
                    habilitaControles(false);
                    limparControles();
                    gerenciaBotoesBarra(true);
                    atualizarTabelas();
                }
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitaControles(true);
            limparControles();
            gerenciaBotoesBarra(false);
        }

        //AÇÃO AO CLICAR NO FILTRO DAS OCORRÊNCIAS
        private void cbxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        /*
        private void cbxFiltroDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarTabelas();
        }
        */

        private void btnResetar_Click(object sender, EventArgs e)
        {
            //cbxFiltroDepartamento.SelectedIndex = -1;
            cbxSituacao.Text = "Todas";
            atualizarTabelas();
        }

        //CONTROLE DA GRID
        private void preencheDadosControles() //Altera os txtBox e cbx ao selecionario uma ocorrência
        {
            ocorrencias.selectOcorrenciaSingular(2);
            
            txtData.Text = ocorrencias.getData();
            txtDataLimite.Text = ocorrencias.getDataLimite();
            txtDescricao.Text = ocorrencias.getDescricao();
            //cbxDepartamento.SelectedIndex = ocorrencias.getDeptoCod() - 1;
            txtID.Text = ocorrencias.getMatriculaFuncionario().ToString();

            ocorrencias.selectNomeFuncionario();
            txtNome.Text = ocorrencias.getNomeFuncionario();


        }
        private void limparControles() //limpa os campos dos txtbox e cbx
        {
            ocorrencias.setONumero(0);
            txtData.Text = "";
            txtDataLimite.Text = "";
            txtDescricao.Text = "";
            //cbxDepartamento.SelectedIndex = -1;
            txtID.Text = "";
            txtNome.Text = "";
            
        }

        private void habilitaControles(bool status) //habilita/desabilita os txtbox e cbx
        {
            txtData.Enabled = status;
            txtDataLimite.Enabled = status;
            txtDescricao.Enabled = status;
            //cbxDepartamento.Enabled = status;
            txtID.Enabled = status;

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
        private void checkarSelectOcorrencias()
        { //Checka qual filtro deve ser aplicado para mostrar as ocorrencias
            if (cbxSituacao.Text == "Todas")
            { grdOcorrencias.DataSource = ocorrencias.selectTodasOcorrenciasDepartamento(depto); }
            else if (cbxSituacao.Text != "Todas")
            {
                //situacaoOcorrencia = cbxSituacao.Text;
                grdOcorrencias.DataSource = ocorrencias.selectTodasOcorrenciasStatusDepartamentos(cbxSituacao.SelectedIndex, depto);
            }
        }
       
        private bool validaDados() //Verifica se todos os campos foram preenchidos
        {
            if (txtData.Text.Trim().Length <= 1)
            {
                MessageBox.Show("A data da Ocorrência é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtData.Focus();
                return false;
            }

            if (txtDataLimite.Text.Trim().Length <= 1)
            {
                MessageBox.Show("A data limite da Ocorrência é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataLimite.Focus();
                return false;
            }

            if (txtDescricao.Text.Trim().Length < 1)
            {
                MessageBox.Show("A descrição da Ocorrência é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return false;
            }
            /*
            if (cbxDepartamento.Text.Trim().Length < 1)
            {
                MessageBox.Show("O departamento da Ocorrência é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxDepartamento.Focus();
                return false;
            }
            */
            if (txtID.Text.Trim().Length < 1)
            {
                MessageBox.Show("O funcionário da Ocorrência é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return false;
            }

            return true;
        }

        //SALVAR OS OCORRÊNCIA NO BD
        private void salvarOcorrencia()
        {
            if (ocorrencias.getONumero() == 0)
            {
                //Novo ocorrência
                gerente.criaOcorrencia(ocorrencias, txtData.Text, txtDataLimite.Text, txtDescricao.Text, Convert.ToInt32(txtID.Text), depto);
            }
            else
            {
                //Atualizar ocorrência atual
                
                gerente.alteraOcorrencia(ocorrencias, txtData.Text, txtDataLimite.Text, txtDescricao.Text, Convert.ToInt32(txtID.Text), depto);
            }

        }


        //AÇÃO AO CLICAR NAS CELULAS DA TABELA OCORRÊNCIA
        private void grdOcorrencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            {

                try
                {
                    ocorrencias.setONumero(Convert.ToInt32(grdOcorrencias.Rows[grdOcorrencias.CurrentRow.Index].Cells[0].Value.ToString()));

                    preencheDadosControles();
                }

                catch (Exception)
                {
                    MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }

            }
            */
        }

       //ACÃO AO ALTERAR O TEXTO 
        private void txtID_TextChanged(object sender, EventArgs e) //procura pelo funcionário responsável pelo id colocado
        {
            try
            {
                ocorrencias.setMatriculaFuncionario(Convert.ToInt32(txtID.Text));
                ocorrencias.selectNomeFuncionario();
                txtNome.Text = ocorrencias.getNomeFuncionario();
            }
            catch {
                txtNome.Text = "";
            }
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e) //abre o formulário para pesquisar por funcionário
        {
            frmPesquisarFuncionario pesquisar = new frmPesquisarFuncionario();
            pesquisar.Show();
            
        }

        //AÇÃO AO FECHAR FORMULÁRIO
        private void frmCadastrarOcorrencias_FormClosed(object sender, FormClosedEventArgs e) //abre a janela gerente quando a janela é fechada
        {
            csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto);
            abrirJanelas.abrirJanelaGerente();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (ocorrencias.getONumero() != 0)
            {
                if (MessageBox.Show("Deseja Excluir a ocorrência?", "Alteração",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gerente.deletaOcorrencia(ocorrencias);
                    limparControles();
                    atualizarTabelas();
                }
            }
            else
            {
                MessageBox.Show("Selecione a ocorrência para a exclusão", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void grdOcorrencias_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ocorrencias.setONumero(Convert.ToInt32(grdOcorrencias.Rows[grdOcorrencias.CurrentRow.Index].Cells[0].Value.ToString()));

                preencheDadosControles();
            }

            catch (Exception)
            {
               MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }
    }
}