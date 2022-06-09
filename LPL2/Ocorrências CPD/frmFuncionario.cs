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


            


            
        }


        private void formataGridOcorrencias()
        {
            grdOcorrencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


           

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
