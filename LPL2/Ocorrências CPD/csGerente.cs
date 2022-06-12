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
    internal class csGerente
    {
        private conexaoPostgres conexao = new conexaoPostgres();


        private Int64 idGeren;
        private string nomeGeren;
        private string status;
        private string cargo;
        private string departamento;
        private string ordenarGeren;


        public void setIdGerente(Int64 id)
        {
            idGeren = id;
        }

        public Int64 getIdGerente() { return idGeren; }
        public string getNomeGerente() { return nomeGeren; }
        public string getStatusGerente() { return status; }
        public string getCargoGerente() { return cargo; }
        public string getDepartamentoGerente() { return departamento; }

        //INSERTS
        public void inserir()
        {
            //INSERT INTO clientes(nomeCliente, cpfCliente, cidadeCliente, estadoCliente) VALUES("'" + nomeCliente + "'," + cpfCliente + ",'" + "'" + cidadeCliente + "','" + estadoCliente)

            string sql = "INSERT INTO funcionarios(nomeFunc, cpfFunc, cidadeFunc, ')";

            conexao.executarSql(sql);
        }

        //UPDATES
        public void update()
        {
            string sql = "UPDATE funcionarios SET nomeFunc='" + nomeGeren + "',cpfFunc= ,cidadeFunc='";
            conexao.executarSql(sql);
        }

        //DROPS
        public void delete()
        {

            string sql = "DELETE FROM funcionarios WHERE funcionarios.idFunc =" + idGeren.ToString() + ";";
            conexao.executarSql(sql);
        }

        //SELECTS
        public DataTable selectTodosGerentes()
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa  inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'gerente' ORDER BY p_status DESC, d_nome ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesDepartamento(int dp)
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            dp += 1;
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa  inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'gerente' and d_codigo = " + dp + "ORDER BY p_status DESC, d_nome ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesStatusDepartamentos(string status, int departamento)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            departamento += 1;
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_status = '" + status + "' and d_codigo = '" + departamento + "' and p_cargo = 'gerente' ORDER BY p_cargo DESC, d_nome; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesStatus(string status)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_status = '" + status + "' and p_cargo = 'gerente' ORDER BY p_cargo DESC;";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectGeren()
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'funcionário' and p_matricula = " + idGeren + ";";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            idGeren = Convert.ToInt64(dataset.Tables[0].Rows[0][0]);
            nomeGeren = dataset.Tables[0].Rows[0][1].ToString();
            status = dataset.Tables[0].Rows[0][2].ToString();
            cargo = dataset.Tables[0].Rows[0][3].ToString();
            departamento = dataset.Tables[0].Rows[0][4].ToString();
        }
    }
}