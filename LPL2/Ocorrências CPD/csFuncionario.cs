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
    internal class csFuncionario
    {
        private conexaoPostgres conexao = new conexaoPostgres();
        

        private Int64 idFunc;
        private string nomeFunc;
        private string status;
        private string cargo;
        private Int64 matricula;
        private string departamento;
        private string ordenarFunc;


        public void setIdFuncionario(Int64 id)
        {
            idFunc = id;
        }

        public Int64 getIdFuncionario() {return idFunc;}
        public void inserir()
        {
            //INSERT INTO clientes(nomeCliente, cpfCliente, cidadeCliente, estadoCliente) VALUES("'" + nomeCliente + "'," + cpfCliente + ",'" + "'" + cidadeCliente + "','" + estadoCliente)

            string sql = "INSERT INTO funcionarios(nomeFunc, cpfFunc, cidadeFunc, ')";

            conexao.executarSql(sql);
        }

        public void update()
        {
            string sql = "UPDATE funcionarios SET nomeFunc='" + nomeFunc + "',cpfFunc= ,cidadeFunc='";
            conexao.executarSql(sql);
        }

        public void delete()
        {

            string sql = "DELETE FROM funcionarios WHERE funcionarios.idFunc =" + idFunc.ToString() + ";";
            conexao.executarSql(sql);
        }

         public DataTable selectTodosFuncionarios()
        {
            
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa  inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'funcionário' ORDER BY p_status DESC, d_nome ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectFuncionariosDepartamento(int dp)
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            dp += 1;
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa  inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'funcionário' and d_codigo = " +dp+ "ORDER BY p_status DESC, d_nome ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        } 

        public DataTable selectFuncionariosStatusDepartamentos(string status,int departamento)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            departamento += 1;
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_status = '" + status +"' and d_codigo = '" + departamento + "' ORDER BY p_cargo DESC, d_nome; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectFuncionariosStatus(string status)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_status = '" + status + "' ORDER BY p_cargo DESC;";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectFunc()
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'funcionário' and p_matricula = " +idFunc+ " ORDER BY p_status DESC, d_nome ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            nomeFunc = dataset.Tables[0].Rows[0][0].ToString();
            status = dataset.Tables[0].Rows[0][1].ToString();
            cargo = dataset.Tables[0].Rows[0][2].ToString();
            departamento = dataset.Tables[0].Rows[0][3].ToString();
        }
    }
}

