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
    public partial class frmPesquisarFuncionario : Form
    {
        public frmPesquisarFuncionario()
        {
            InitializeComponent();
            preecherGrid();
        }
        csFuncionario func = new csFuncionario();
        private void preecherGrid() {
            grdOcorrencias.DataSource = func.selectTodosFuncionarios();
        }
    }
}
