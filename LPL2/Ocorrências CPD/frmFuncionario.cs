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
    public partial class frmFuncionario : Form
    {

        private Int32 id;
        //CONSTRUTORES
        public frmFuncionario(Int32 id)
        {
            this.id = id;
            InitializeComponent();
            atualizarTabelas();
            preencheDadosFuncionario();
            
        }

       
        //INSTANCIAMENTO DE CLASSES

        private conexaoPostgres conexao = new conexaoPostgres();
        private csFuncionario func = new csFuncionario();
        private csOcorrencias ocorr = new csOcorrencias();
        
        
        //DECLARAÇÃO DE VARIÁVEIS

        private Int64 numOcorrencia;
        private string situacaoOcorrencia;

        //PREENCHIMENTO DOS DADOS DO FUNCIONARIO
        private void preencheDadosFuncionario() {
            func.selectFunc();
            txtNome.Text = func.getNomeFuncionario();
            txtStatus.Text = func.getStatusFuncionario();
            txtMatricula.Text =  Convert.ToString(func.getIdFuncionario());
            txtCargo.Text = func.getCargoFuncionario();
            txtDepartamento.Text = func.getDepartamentoFuncionario();
        }
        //FORMATAÇÃO DAS TABELAS e POPULAR COMBOBOX

        
      
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
            func.setIdFuncionario(id);
            numOcorrencia = func.getIdFuncionario();

            checkarSelectOcorrencias();
        }

        private void atualizarTabelas()
        {
            
            grdOcorrencias.DataSource = ocorr.selectOcorrencias(-1);
            formataGridOcorrencias();
            preencheDadosControles();
            
        }
        private void checkarSelectOcorrencias()//Checka qual filtro deve ser aplicado para mostrar as ocorrências
        {
            if (cbxSituacao.Text == "Todas")
            {
                grdOcorrencias.DataSource = ocorr.selectOcorrencias(Convert.ToInt32(numOcorrencia));
            }
            else
            {
                situacaoOcorrencia = cbxSituacao.Text;
                grdOcorrencias.DataSource = ocorr.selectOcorrenciasSituacao(Convert.ToInt32(numOcorrencia), situacaoOcorrencia);

            }
        }
       
        //AÇÃO AO CLICAR NA CELULA DO GBD
       
        private void grdOcorrencias_CellClick(object sender, DataGridViewCellEventArgs e) //Quando clica em uma celula
        {
            try
            {
                ocorr.setIdOcorrencia(Convert.ToInt64(grdOcorrencias.Rows[grdOcorrencias.CurrentRow.Index].Cells[0].Value.ToString()));
                
            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }


        //AÇÃO AO CLICAR NOS BOTÕES
       

        private void btnFinalizar_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja finalizar a ocorrência?", "Finalizar ocorrência",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Exclamation);


            if (result == DialogResult.Yes)
            {
                ocorr.updateFinalizarStatusTemp();
                preencheDadosControles();

            }

        }
        

        //AÇÃO AO CLICAR NOS FILTROS DE COMBOBOX

        private void cbxSituacao_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            preencheDadosControles();
        }

        
    }
}
