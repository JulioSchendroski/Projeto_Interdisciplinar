using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using System.IO;


namespace Ocorrências_CPD
{
    public partial class ocorrenciasCPD : Form
    {
        //CONSTRUTORES
        public ocorrenciasCPD()
        {
            InitializeComponent();
        }

        //DECLARAÇÃO DE VARIÁVEIS
        private Int32 idPessoa;
        private string cargo;

        //INSTANCIAMENTO DE CLASSES
        private iConexaoBD conexao = new conexaoPostgres();

        //SELECT PARA CONFERIR SE OS DADOS DO LOGIN CONFEREM
        public Boolean selectEntrar(Int32 id, string cargo)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_cargo, p_status, p_depto_cod from tb.pessoa where p_matricula = " + id + ";";

            conexao.conectaAdm();
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();
            conexao.desconectaBD();

            if (cargo == dataset.Tables[0].Rows[0][0].ToString() && dataset.Tables[0].Rows[0][1].ToString() == "ativo")
            {
                if (cargo == "diretor")
                {
                    csAbrirJanelas abrirJanelas = new csAbrirJanelas();
                    abrirJanelas.abrirJanelaDiretor();
                }
                else if (cargo == "gerente")
                {
                    Int32 depto_cod = Convert.ToInt32(dataset.Tables[0].Rows[0][2].ToString());

                    csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto_cod);
                    abrirJanelas.abrirJanelaGerente();
                }
                else if (cargo == "funcionário")
                {
                    Int32 depto_cod = Convert.ToInt32(dataset.Tables[0].Rows[0][2].ToString());
                    if (depto_cod != 4)
                    {
                        MessageBox.Show("Dados incorretos! Tente novamente:", "Erro!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    csAbrirJanelas abrirJanelas = new csAbrirJanelas(id, depto_cod);
                    abrirJanelas.abrirJanelaFuncionario();
                }
                return true;
            }
            else
            {
                if (cargo == dataset.Tables[0].Rows[0][0].ToString() && dataset.Tables[0].Rows[0][1].ToString() != "ativo")
                {
                    MessageBox.Show("Não é possível acessar uma conta de usuário inativo", "Erro!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else if (cargo != dataset.Tables[0].Rows[0][0].ToString())
                {
                    MessageBox.Show("A matricula não confere com o cargo", "Erro!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                return false;
            }
        }

        //CONFERE OS DADOS DO LOGIN
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text == "diretor" || txtCargo.Text == "gerente" || txtCargo.Text == "funcionário")
            {

                try
                {
                    cargo = txtCargo.Text;
                    idPessoa = Convert.ToInt32(txtMatricula.Text);

                    if (selectEntrar(idPessoa, cargo)) { this.Close(); }//Verifica se a janela tem que ser fechada
                }
                catch (Exception)
                {
                    MessageBox.Show("Dados incorretos! Tente novamente:", "Erro!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Dados incorretos! Tente novamente:", "Erro!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
