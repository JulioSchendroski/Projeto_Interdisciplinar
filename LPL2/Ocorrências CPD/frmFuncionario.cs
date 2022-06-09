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
        public frmFuncionario()
        {
            InitializeComponent();
            atualizarTabelas();
        }

        csFuncionario func = new csFuncionario();
        csOcorrencias ocorr = new csOcorrencias();
        
       
        //FORMATAR TABELAS
        private void formataGridFuncionarios()
        {
            grdFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            grdFuncionarios.Columns[0].HeaderText = "Produto";
            grdFuncionarios.Columns[1].HeaderText = "Quantidade";
            grdFuncionarios.Columns[2].HeaderText = "Produto";
            grdFuncionarios.Columns[3].HeaderText = "Quantidade";


            grdFuncionarios.Columns[0].Width = 250;
            grdFuncionarios.Columns[1].Width = 80;
            
        }


        private void formataGridOcorrencias()
        {
            grdOcorrencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            grdOcorrencias.Columns[0].HeaderText = "Produto";
            grdOcorrencias.Columns[1].HeaderText = "Quantidade";
            grdOcorrencias.Columns[2].HeaderText = "Produto";
            grdOcorrencias.Columns[3].HeaderText = "Quantidade";


            grdOcorrencias.Columns[0].Width = 250;
            grdOcorrencias.Columns[1].Width = 80;

        }

        private void atualizarTabelas()
        {
            grdFuncionarios.DataSource = func.select();
            grdOcorrencias.DataSource = ocorr.select();
            formataGridFuncionarios();
            formataGridOcorrencias();
        }
    }
}
