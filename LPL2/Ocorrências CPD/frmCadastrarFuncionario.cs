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
    public partial class frmCadastrarFuncionario : Form
    {
        public frmCadastrarFuncionario()
        {
            InitializeComponent();
            atualizarTabelas();
        }

        csFuncionario func = new csFuncionario();

        private void atualizarTabelas()
        {
            grdFuncionarios.DataSource = func.selectFuncionariosStatus("ativo");
            formataGridFuncionarios();

        }
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
    }
}

