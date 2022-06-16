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
        Int32 id;
        Int32 depto;
        //CONSTRUTOR
        public frmGerente(Int32 id, Int32 depto)
        {
            this.id = id;
            this.depto = depto;
            InitializeComponent();
            func.setIdPessoa(-1);
            atualizarTabelas();
        }

        //INSTANCIAMENTO DE CLASSES
        private conexaoPostgres conexao = new conexaoPostgres();
        private csFuncionario func = new csFuncionario();
        private csOcorrencias ocorr = new csOcorrencias();
        private csDepartamento departamento = new csDepartamento();
        private csGerente gerente = new csGerente();
       
        //DECLARAÇÃO DE VARIÁVEIS
        private string statusFunc;
        private int numeroDepartamento;
        private Int64 numOcorrencia;
        private string situacaoOcorrencia;


        //FORMATAÇÃO DAS TABELAS e POPULAR COMBOBOX
        
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

        private void formataGridOcorrencias() //formata as colunas da tabela Ocorrências
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

        //PREENCHIMENTO DAS TABELAS
        private void preencheDadosControles() //Preenche grid ocorrencias 
        {
            numOcorrencia = func.getIdPessoa();

            checkarSelectOcorrencias();
        }

        private void atualizarTabelas() //atualiza os dados das tabelas
        {
            grdOcorrencias.DataSource = ocorr.selectTodasOcorrenciasDepartamento(depto);
            checkarSelectFuncionario();
            formataGridFuncionarios();
            formataGridOcorrencias();
        }
        private void checkarSelectOcorrencias() //Checka qual filtro deve ser aplicado para mostrar as ocorrências
        {
            if (cbxSituacao.Text == "Todas")
            {
                grdOcorrencias.DataSource = ocorr.selectOcorrencias(Convert.ToInt32(numOcorrencia), depto);
            }
            else 
            {
                situacaoOcorrencia = cbxSituacao.Text;
                grdOcorrencias.DataSource = ocorr.selectOcorrenciasSituacao(Convert.ToInt32(numOcorrencia), situacaoOcorrencia, depto);

            }
        }
        private void checkarSelectFuncionario() { //Checka qual filtro deve ser aplicado para mostrar os funcionários
            if (cbxStatus.Text == "Todos")
            { grdFuncionarios.DataSource = func.selectTodosFuncionarios(depto); }
            else if (cbxStatus.Text != "Todos")
            {
                statusFunc = cbxStatus.Text;
                grdFuncionarios.DataSource = func.selectFuncionariosStatus(statusFunc, depto);
            }
            
            
        }

        //AÇÃO AO CLICAR NA CELULA DO GBD
        private void grdFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
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
        private void grdOcorrencias_CellClick(object sender, DataGridViewCellEventArgs e) //Quando clica em uma celula
        {
            try
            {
                ocorr.setONumero(Convert.ToInt32(grdOcorrencias.Rows[grdOcorrencias.CurrentRow.Index].Cells[0].Value.ToString()));
                ocorr.selectOcorrenciaSingular();
                if (ocorr.getStatusDef() == "aberta") {btnFinalizar.Enabled = true;}
                else { btnFinalizar.Enabled = false;}
                
            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }

        //AÇÃO AO CLICAR NO MENUSTRIP
        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            csAbrirJanelas abrirJanelas = new csAbrirJanelas();
            abrirJanelas.abrirJanelaLogin();
        }
        private void gerenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto);
            abrirJanelas.abrirJanelaCadastrarFuncionario();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto);
            abrirJanelas.abrirJanelaCadastrarOcorrencias();
        }

        //AÇÃO AO CLICAR NOS BOTÕES
        private void btnResetar_Click_1(object sender, EventArgs e) //Reseta o combobox do departamento
        {
            func.setIdPessoa(-1);
            atualizarTabelas();
            
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja finalizar a ocorrência?", "Finalizar ocorrência",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Exclamation);

            
            if (result == DialogResult.Yes)
            {
                ocorr.updateFinalizarStatusDef();
                atualizarTabelas();
                btnFinalizar.Enabled = false;

            }
            
        }

        //AÇÃO AO CLICAR NOS FILTROS DE COMBOBOX
        private void cbxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (func.getIdPessoa() == -1) {
                if (cbxSituacao.Text == "Todas")
                {
                    grdOcorrencias.DataSource = ocorr.selectTodasOcorrenciasDepartamento(depto);
                }
                else
                {
                    situacaoOcorrencia = cbxSituacao.Text;
                    grdOcorrencias.DataSource = ocorr.selectTodasOcorrenciasStatusDepartamentos(situacaoOcorrencia, depto);

                }
            }
            else
            {
                preencheDadosControles();
            }
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        private void cbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void grdOcorrencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
