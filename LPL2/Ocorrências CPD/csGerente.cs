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
    internal class csGerente : csPessoa
    {
        //INSTANCIAMENTO DE CLASSES
        private iConexaoBD conexao = new conexaoPostgres();

        public void criaFuncionario(csFuncionario f, Int32 id, string nome, string status, string cargo, Int32 depto_cod)
        {
            f.setIdPessoa(id);
            f.setNomePessoa(nome);
            f.setStatusPessoa(status);
            f.setCargoPessoa(cargo);
            f.setDepartamentoPessoa(depto_cod);

            f.inserir();
        }

        public void alteraFuncionario(csFuncionario f, string nome, string status, Int32 depto_cod)
        {
            f.setNomePessoa(nome);
            f.setStatusPessoa(status);
            f.setDepartamentoPessoa(depto_cod);

            f.update();
        }

        public void inativaFuncionario(csFuncionario f)
        {
            f.delete();
        }

        public void criaOcorrencia(csOcorrencias o, string data, string dataLimite, string descricao, Int32 matriculaFuncionario, Int32 depto_cod)
        {
            o.setData(data);
            o.setDataLimite(dataLimite);
            o.setDescricao(descricao);
            o.setMatriculaFuncionario(matriculaFuncionario);
            o.setDeptoCod(depto_cod);

            o.inserir();
        }

        public void alteraOcorrenciaStatusDef(csOcorrencias o)
        {
            o.updateFinalizarStatusDef();
        }

        public void alteraOcorrencia(csOcorrencias o, string data, string dataLimite, string descricao, Int32 matriculaFuncionario, Int32 depto_cod)
        {
            o.setData(data);
            o.setDataLimite(dataLimite);
            o.setDescricao(descricao);
            o.setMatriculaFuncionario(matriculaFuncionario);
            o.setDeptoCod(depto_cod);

            o.update();
        }

        public void deletaOcorrencia(csOcorrencias o)
        {
            o.delete();
        }

        //INSERTS
        public override void inserir()
        {
            try
            {
                string sql = "INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) " +
                    "VALUES (" + id + ",'" + nome + "', '" + status + "'," + depto_cod + ",'" + cargo + "');";

                conexao.conectaDiretor();
                conexao.executarSql(sql);
                conexao.desconectaBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar o gerente.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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


                conexao.conectaDiretor();
                conexao.executarSql(sql);
                conexao.desconectaBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o gerente. Verifique a matrícula", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //DELETE (UPDATE)
        public override void delete() //Nenhum gerente é excluido do banco quando se torna inativo
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET p_status = 'inativo' WHERE p_matricula = " + id + ";";

                conexao.conectaDiretor();
                conexao.executarSql(sql);
                conexao.desconectaBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o gerente. ", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        //SELECTS
        public DataTable selectTodosGerentes() //Seleciona todos os gerentes
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_gerente;";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesDepartamento(int dp) //seleciona os gerentes por departamento
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            dp += 1;
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_gerente where codigo_depto = " + dp + ";";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesStatusDepartamentos(string status, int departamento) //seleciona os gerentes por status e departamento
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            departamento += 1;
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_gerente where status = '" + status +
                "' and codigo_depto = '" + departamento + "'; ";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesStatus(string status) //seleciona os gerentes por status
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_gerente where status = '" + status + "';";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public void selectGeren() //seleciona todos os dados de um único gerente
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select matricula, nome, status, cargo, departamento from vw.v_gerente where matricula = " + id + ";";

            conexao.conectaDiretor();
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