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
        
        private Int32 id; //declaração da variavel id
        private Int32 depto;
        
        //CONSTRUTORES
        public frmFuncionario(Int32 id, int depto)

        {
            this.depto = depto;
            this.id = id;
            InitializeComponent();
            atualizarTabelas();
            preencheDadosFuncionario();

        }

       
        //INSTANCIAMENTO DE CLASSES

        private csFuncionario func = new csFuncionario();
        private csOcorrencias ocorr = new csOcorrencias();
        
        
        //DECLARAÇÃO DE VARIÁVEIS

        //private Int64 numOcorrencia;
        //private string situacaoOcorrencia;

        //PREENCHIMENTO DOS DADOS DO FUNCIONARIO
        private void preencheDadosFuncionario() {
            func.selectFunc(3);
            txtNome.Text = func.getNomePessoa();
            txtStatus.Text = func.getStatusPessoa();
            txtMatricula.Text =  Convert.ToString(func.getIdPessoa());
            txtCargo.Text = func.getCargoPessoa();
            txtDepartamento.Text = func.getDepartamentoPessoa();
        }

        //FORMATAÇÃO DAS TABELAS e POPULAR COMBOBOX
        private void formataGridOcorrencias() //formata as colunas da tabela Ocorrências
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

        //PREENCHIMENTO DAS TABELAS
        private void preencheDadosControles() //Preenche grid ocorrencias 
        {
            func.setIdPessoa(id);
            //numOcorrencia = func.getIdPessoa();

            checkarSelectOcorrencias();
        }

        private void atualizarTabelas() //atualiza os dados das tabelas
        {
            grdOcorrencias.DataSource = ocorr.selectOcorrencias(id);
            preencheDadosControles();
            formataGridOcorrencias();
            
        }
        private void checkarSelectOcorrencias()//Checka qual filtro deve ser aplicado para mostrar as ocorrências
        {
            if (cbxSituacao.Text == "Todas")
            {
                grdOcorrencias.DataSource = ocorr.selectOcorrencias(id);
            }
            else
            {
                //situacaoOcorrencia = cbxSituacao.Text;
                grdOcorrencias.DataSource = ocorr.selectOcorrenciasSituacao(id, cbxSituacao.SelectedIndex);

            }
        }
       
        //AÇÃO AO CLICAR NA CELULA DO GBD
        private void grdOcorrencias_CellClick(object sender, DataGridViewCellEventArgs e) //Quando clica em uma celula
        {
            /*
            try
            {
                ocorr.setONumero(Convert.ToInt32(grdOcorrencias.Rows[grdOcorrencias.CurrentRow.Index].Cells[0].Value.ToString()));
                ocorr.selectOcorrenciaSingular();
                if (ocorr.getStatusTemp() == "aberta") { btnFinalizar.Enabled = true; }
                else { btnFinalizar.Enabled = false; }

            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            */
        }

        //AÇÃO AO CLICAR NOS BOTÕES
        private void btnFinalizar_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja finalizar a ocorrência?", "Finalizar ocorrência",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Exclamation);


            if (result == DialogResult.Yes)
            {
                func.altereOcorrenciaStatusTemp(ocorr);
                preencheDadosControles();

            }

        }
        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            csAbrirJanelas abrirJanelas = new csAbrirJanelas();
            abrirJanelas.abrirJanelaLogin();
        }


        //AÇÃO AO CLICAR NOS FILTROS DE COMBOBOX
        private void cbxSituacao_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            preencheDadosControles();
        }

        private void grdOcorrencias_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ocorr.setONumero(Convert.ToInt32(grdOcorrencias.Rows[grdOcorrencias.CurrentRow.Index].Cells[0].Value.ToString()));
                ocorr.selectOcorrenciaSingular(3);
                if (ocorr.getStatusTemp() == "aberta") { btnFinalizar.Enabled = true; }
                else { btnFinalizar.Enabled = false; }

            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado é inválido", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }
    }
}
