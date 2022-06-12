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
        public frmCadastrarOcorrencias()
        {
            InitializeComponent();
            atualizarTabelas();
            habilitaControles(false);
            gerenciaBotoesBarra(true);
            popularComboX();


        }

        //INSTANCIAMENTO DE CLASSES

        csOcorrencias ocorrencias = new csOcorrencias();
        csDepartamento departamento = new csDepartamento();
        csFuncionario func = new csFuncionario();

        //POPULAR COMBOBOX
        private void popularComboX()
        {

            //populando combobox do departamento
            cbxDepartamento.DataSource = departamento.selectTodosDepartamentos();
            cbxDepartamento.ValueMember = "codigo";
            cbxDepartamento.DisplayMember = "nome";

            cbxDepartamento.SelectedIndex = -1;

            //populando combobox do departamento
            cbxFuncionario.DataSource = func.selectTodosFuncionarios();
            cbxFuncionario.ValueMember = "matricula";
            cbxFuncionario.DisplayMember = "nome";

            cbxFuncionario.SelectedIndex = -1;


        }

        //FORMATAÇÃO DA TABELA
        private void atualizarTabelas()

        {
            grdOcorrencias.DataSource = ocorrencias.selectTodasOcorrencias();
            formataGridOcorrencias();

        }
        private void formataGridOcorrencias() //formata as colunas da tabela ocorrências
        {
            grdOcorrencias.Columns[0].HeaderText = "ID"; //id
            grdOcorrencias.Columns[1].HeaderText = "Data"; //data
            grdOcorrencias.Columns[2].HeaderText = "STemporário"; //status temporario
            grdOcorrencias.Columns[3].HeaderText = "SDefinitivo"; //status definitivo
            grdOcorrencias.Columns[4].HeaderText = "Descrição"; //descrição
            grdOcorrencias.Columns[5].HeaderText = "Funcionário"; //funcionario
            grdOcorrencias.Columns[6].HeaderText = "Departamento"; //departamento

            grdOcorrencias.Columns[0].Width = 30; //id
            grdOcorrencias.Columns[1].Width = 70; //data
            grdOcorrencias.Columns[2].Width = 70; //status temporario
            grdOcorrencias.Columns[3].Width = 70; //status definitivo
            grdOcorrencias.Columns[4].Width = 260; //descrição
            grdOcorrencias.Columns[5].Width = 150; //funcionario
            grdOcorrencias.Columns[6].Width = 150; //departamento

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

        /* private void btnExcluir_Click(object sender, EventArgs e) //Torna o departamento inativo
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
         }*/
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaDados() == true)
            {
                salvarOcorrencia();
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
        private void preencheDadosControles() //Altera os txtBox e cbx ao selecionario uma ocorrência
        {
            ocorrencias.selectOcorrenciaSingular();

            txtData.Text = ocorrencias.getData();
            txtDescricao.Text = ocorrencias.getDescricao();
            cbxDepartamento.SelectedIndex = ocorrencias.getDeptoCod() - 1;
            cbxFuncionario.SelectedIndex = ocorrencias.getMatriculaFuncionario() - 1;
        }
        private void limparControles()
        {
            ocorrencias.setONumero(0);
            txtData.Text = "";
            txtDescricao.Text = "";
            cbxDepartamento.SelectedIndex = -1;
            cbxFuncionario.SelectedIndex = -1;
            
        }

        private void habilitaControles(bool status)
        {
            txtData.Enabled = status;
            txtDescricao.Enabled = status;
            cbxDepartamento.Enabled = status;
            cbxFuncionario.Enabled = status;

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
            if (txtData.Text.Trim().Length <= 1)
            {
                MessageBox.Show("A data da Ocorrência é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtData.Focus();
                return false;
            }

            if (txtDescricao.Text.Trim().Length < 1)
            {
                MessageBox.Show("A descrição da Ocorrência é obrigatória.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return false;
            }
            if (cbxDepartamento.Text.Trim().Length < 1)
            {
                MessageBox.Show("O departamento da Ocorrência é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxDepartamento.Focus();
                return false;
            }
            if (cbxFuncionario.Text.Trim().Length < 1)
            {
                MessageBox.Show("O funcionário da Ocorrência é obrigatório.",
                    "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxFuncionario.Focus();
                return false;
            }

            return true;
        }

        //SALVAR OS OCORRÊNCIA NO BD
        private void salvarOcorrencia()
        {
            //Sets da ocorrência
            ocorrencias.setData(txtData.Text);
            ocorrencias.setDeptoCod(Convert.ToInt32(cbxDepartamento.SelectedIndex) + 1);
            ocorrencias.setMatriculaFuncionario(Convert.ToInt32(cbxFuncionario.SelectedIndex));
            ocorrencias.setDescricao(txtDescricao.Text);
            ocorrencias.setStatusDef("aberta");
            ocorrencias.setStatusTemp("aberta");

            if (ocorrencias.getONumero() == 0)
            {
                //Novo ocorrência

                ocorrencias.inserir();


            }
            else
            {
                //Atualizar ocorrência atual
                ocorrencias.update();
            }

        }


        //AÇÃO AO CLICAR NAS CELULAS DA TABELA OCORRÊNCIA


        private void grdOcorrencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
}