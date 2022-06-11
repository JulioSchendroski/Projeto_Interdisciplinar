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

        public string ordenarFunc;

        public string getOrdenarFunc(){ return ordenarFunc; } //get
       
        //FORMATAR TABELAS
        private void formataGridFuncionarios()
        {
            grdFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
  
        }


        private void formataGridOcorrencias()
        {
            grdOcorrencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


           

        }

        private void atualizarTabelas()
        {
            ordenarFunc = cbxOrdenarFuncionarios.Text;
            if (ordenarFunc == "Ordenar") {ordenarFunc = "p_status"; }
            grdFuncionarios.DataSource = func.selectFuncionariosStatus("ativo");
            
            formataGridFuncionarios();
            formataGridOcorrencias();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
