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
    public partial class frmDiretor : Form
    {
        //CONSTRUTOS
        public frmDiretor()
        {
            InitializeComponent();
            atualizarTabelas();
            popularComboX();
        }

        //INSTANCIAMENTO DE CLASSES
        private csDepartamento departamento = new csDepartamento();
        private csGerente gerente = new csGerente();

        //DECLARAÇÃO DE VARIÁVEIS
        private string statusGeren;
        private int numeroDepartamento;

        //FORMATAÇÃO DAS TABELAS e POPULAR COMBOBOX
        private void popularComboX()
        {
            //populando combobox do departamento
            cbxDepartamento.DataSource = departamento.selectTodosDepartamentos();
            cbxDepartamento.ValueMember = "codigo";
            cbxDepartamento.DisplayMember = "nome";

            cbxDepartamento.SelectedIndex = -1;
        }

        private void formataGridGerentes() //formata as colunas da tabela Gerentes
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

        private void formataGridDepartamento() //formata as colunas da tabela Departamento
        {
            grdDepartamento.Columns[0].HeaderText = "ID"; //id
            grdDepartamento.Columns[1].HeaderText = "Nome"; //nome
            grdDepartamento.Columns[2].HeaderText = "Descrição"; //descrição

            grdDepartamento.Columns[0].Width = 30; //matricula
            grdDepartamento.Columns[1].Width = 150; //nome
            grdDepartamento.Columns[2].Width = 500; //descrição

            grdDepartamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //PREENCHIMENTO DAS TABELAS
        private void atualizarTabelas() //atualiza os dados das tabelas
        {
            grdDepartamento.DataSource = departamento.selectTodosDepartamentos();
            checkarSelectGerentes();
            formataGridGerentes();
            formataGridDepartamento();
        }

        private void checkarSelectGerentes()
        {
            //Checka qual filtro deve ser aplicado para mostrar os gerentes
            if (cbxStatus.Text == "Todos" && cbxDepartamento.Text == "")
            {
                grdGerentes.DataSource = gerente.selectTodosGerentes();
            }
            else if (cbxStatus.Text != "Todos" && cbxDepartamento.Text == "")
            {
                statusGeren = cbxStatus.Text;
                grdGerentes.DataSource = gerente.selectGerentesStatus(statusGeren);
            }
            else if (cbxStatus.Text == "Todos" && cbxDepartamento.Text != "")
            {
                numeroDepartamento = cbxDepartamento.SelectedIndex;
                grdGerentes.DataSource = gerente.selectGerentesDepartamento(numeroDepartamento);
            }
            else if (cbxStatus.Text != "Todos" && cbxDepartamento.Text != "")
            {
                statusGeren = cbxStatus.Text;
                numeroDepartamento = cbxDepartamento.SelectedIndex;
                grdGerentes.DataSource = gerente.selectGerentesStatusDepartamentos(statusGeren, numeroDepartamento);
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
            csAbrirJanelas abrirJanelas = new csAbrirJanelas();
            abrirJanelas.abrirJanelaCadastrarGerente();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            csAbrirJanelas abrirJanelas = new csAbrirJanelas();
            abrirJanelas.abrirJanelaCadastrarDepartamento();
        }

        private void diretorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            csAbrirJanelas abrirJanelas = new csAbrirJanelas();
            abrirJanelas.abrirJanelaCadastrarDiretor();
        }

        //AÇÃO AO CLICAR NOS FILTROS DE COMBOBOX
        private void cbxStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        private void cbxDepartamento_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            atualizarTabelas();
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            cbxDepartamento.SelectedIndex = -1;
            atualizarTabelas();
        }

        private void btnResetar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }
    }
}
