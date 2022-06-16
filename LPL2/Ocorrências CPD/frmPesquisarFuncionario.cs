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
        //CONSTRUTORES
        public frmPesquisarFuncionario()
        {
            InitializeComponent();
            preecherGrid();
        }

        //INSTANCIAMENTO DE CLASSES
        csFuncionario func = new csFuncionario();

        //PREENCHIMENTO DAS GRIDS
        private void preecherGrid() {
            
            grdOcorrencias.DataSource = func.selectFuncionariosDepartamento(3);
        }
    }
}
