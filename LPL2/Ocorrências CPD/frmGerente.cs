using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Ocorrências_CPD
{
    public partial class frmGerente : Form
    {
        public frmGerente()
        {
            InitializeComponent();
            atualizarTabelas();
            popularComboX();
        }

        private conexaoPostgres conexao = new conexaoPostgres();
        private csFuncionario func = new csFuncionario();
        private csOcorrencias ocorr = new csOcorrencias();
        private csDepartamento departamento = new csDepartamento();
        private csGerente gerente = new csGerente();
       

        private string statusFunc;
        private int numeroDepartamento;
        private Int64 numOcorrencia;


        //FORMATAR TABELAS e POPULAR COMBOBOX

        private void popularComboX() {

            //populando combobox do departamento
            cbxDepartamento.DataSource = departamento.selectDepartamento();
            cbxDepartamento.ValueMember = "codigo";
            cbxDepartamento.DisplayMember = "nome";
            
            cbxDepartamento.SelectedIndex = -1;

        }
        private void formataGridFuncionarios()
        {
            grdFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void formataGridOcorrencias()
        {
            grdOcorrencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void preencheDadosControles() //Preenche ocorrencias ao clicar na célula do grd
        {
            numOcorrencia = func.getIdFuncionario();
            grdOcorrencias.DataSource = ocorr.selectOcorrencias(Convert.ToInt32(numOcorrencia));
        }

        private void atualizarTabelas()
        {
            grdOcorrencias.DataSource = ocorr.selectOcorrencias(-1);
            checkarSelectFuncionario();
            formataGridFuncionarios();
            formataGridOcorrencias();
        }

        private void checkarSelectFuncionario() {
            if (cbxStatus.Text == "Status" && cbxDepartamento.Text == "")
            { grdFuncionarios.DataSource = func.selectTodosFuncionarios(); }
            else if (cbxStatus.Text != "Status" && cbxDepartamento.Text == "")
            {
                statusFunc = cbxStatus.Text;
                grdFuncionarios.DataSource = func.selectFuncionariosStatus(statusFunc);
            }
            else if (cbxStatus.Text == "Status" && cbxDepartamento.Text != "")
            {
                numeroDepartamento = cbxDepartamento.SelectedIndex;
                grdFuncionarios.DataSource = func.selectFuncionariosDepartamento(numeroDepartamento);
            }
            else if (cbxStatus.Text != "Status" && cbxDepartamento.Text != "")
            {
                statusFunc = cbxStatus.Text;
                numeroDepartamento = cbxDepartamento.SelectedIndex;
                grdFuncionarios.DataSource = func.selectFuncionariosStatusDepartamentos(statusFunc, numeroDepartamento);
            }
        }
        //AÇÃO AO CLICAR NA CELULA DO GBD
        private void grdFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                func.setIdFuncionario(Convert.ToInt64(grdFuncionarios.Rows[grdFuncionarios.CurrentRow.Index].Cells[0].Value.ToString()));
                preencheDadosControles();
            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }
        private void grdOcorrencias_CellClick(object sender, DataGridViewCellEventArgs e) //Quando clica em uma celula
        {
            

        }
        private void gerenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarFuncionario fCadastrarFuncionario = new frmCadastrarFuncionario();
            fCadastrarFuncionario.ShowDialog();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarOcorrencias fCadastrarOcorrencias = new frmCadastrarOcorrencias();
            fCadastrarOcorrencias.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            cbxStatus.Text = "Status";
            atualizarTabelas();
            cbxDepartamento.SelectedIndex = -1;
        }

       
    }
}
