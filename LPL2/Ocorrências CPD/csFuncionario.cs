using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;
using System.IO;
using System.Data;


namespace Ocorrências_CPD
{
    internal class csFuncionario : csPessoa
    {
        //INSTANCIAMENTO DE CLASSES
        private iConexaoBD conexao = new conexaoPostgres();
        public csFuncionario()
        {

        }

        public void altereOcorrenciaStatusTemp(csOcorrencias o)
        {
            o.updateFinalizarStatusTemp();
        }

        //INSERTS
        public override void inserir()
        {
            try
            {
                string sql = "INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) " +
                    "VALUES (" + id + ",'" + nome + "', '" + status + "'," + depto_cod + ",'" + cargo + "');";

                conexao.conectaGerente();
                conexao.executarSql(sql);
                conexao.desconectaBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar o funcionário.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //UPDATES
        public override void update()
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET ";
                sql += "p_nome ='" + nome + "', ";
                sql += "p_depto_cod = " + depto_cod + ",";
                sql += "p_status  ='" + status + "' ";
                sql += " WHERE p_matricula =" + id + ";";


                conexao.conectaGerente();
                conexao.executarSql(sql);
                conexao.desconectaBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o funcionário. Verifique a matrícula", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //DELETE (UPDATE)
        public override void delete() //Nenhum funcionário é excluido do banco quando se torna inativo
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET p_status = 'inativo' WHERE p_matricula = " + id + ";";

                conexao.conectaGerente();
                conexao.executarSql(sql);
                conexao.desconectaBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o funcionário. ", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //SELECTS
        public DataTable selectTodosFuncionarios(Int32 depto) //seleciona todos os funcionários
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as Matrícula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento " +
                "from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo inner join tb.ocorrencia on o_matricula_func = " +
                "p_matricula where o_depto_cod = " + depto + " and p_cargo = 'funcionário' ORDER BY p_status DESC, d_nome ASC;";

            conexao.conectaGerente();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectFuncionariosDepartamento(int dp) //seleciona funcionarios por departamento
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_funcionario where codigo_depto = " + dp + "; ";

            conexao.conectaGerente();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectFuncionariosStatusDepartamentos(string status, int departamento) //seleciona funcionarios por departamento e status
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_funcionario where status = '" + status +
                "' and codigo_depto = '" + departamento + "'; ";

            conexao.conectaGerente();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectFuncionariosStatus(string status, Int32 depto) //seleciona funcionários por status
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_funcionario where codigo_depto = " + depto +
                " and status = '" + status + "';";

            conexao.conectaGerente();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public void selectFunc(int u) //seleciona todos os dados de um determinado funcionario
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_funcionario where matricula = " + id + ";";

            switch (u)
            {
                case 2: conexao.conectaGerente(); break;
                case 3: conexao.conectaFuncionario(); break;
            }
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(dataset);
            Console.WriteLine();

            id = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
            nome = dataset.Tables[0].Rows[0][1].ToString();
            status = dataset.Tables[0].Rows[0][2].ToString();
            cargo = dataset.Tables[0].Rows[0][3].ToString();
            departamento = dataset.Tables[0].Rows[0][4].ToString();
        }
    }
}

