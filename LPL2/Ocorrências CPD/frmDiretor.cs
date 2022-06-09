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
        public frmDiretor()
        {
            InitializeComponent();
            atualizarTabelas();
        }

        csFuncionario func = new csFuncionario();
        csOcorrencias ocorr = new csOcorrencias();


        //FORMATAR TABELAS
        private void formataGridFuncionarios()
        {
            grdGerentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            grdGerentes.Columns[0].HeaderText = "Produto";
            grdGerentes.Columns[1].HeaderText = "Quantidade";
            grdGerentes.Columns[2].HeaderText = "Produto";
            grdGerentes.Columns[3].HeaderText = "Quantidade";


            grdGerentes.Columns[0].Width = 250;
            grdGerentes.Columns[1].Width = 80;

        }


        private void formataGridOcorrencias()
        {
            grdDepartamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            grdDepartamentos.Columns[0].HeaderText = "Produto";
            grdDepartamentos.Columns[1].HeaderText = "Quantidade";
            grdDepartamentos.Columns[2].HeaderText = "Produto";
            grdDepartamentos.Columns[3].HeaderText = "Quantidade";


            grdDepartamentos.Columns[0].Width = 250;
            grdDepartamentos.Columns[1].Width = 80;

        }

        private void atualizarTabelas()
        {
            grdDepartamentos.DataSource = func.select();
            grdGerentes.DataSource = ocorr.select();
            formataGridFuncionarios();
            formataGridOcorrencias();
        }

        private void gerenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarGerente fCadastrarGerente = new frmCadastrarGerente();
            fCadastrarGerente.ShowDialog();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarDepartamento fCadastrarDepartamento = new frmCadastrarDepartamento();
            fCadastrarDepartamento.ShowDialog();
        }
    }
}
