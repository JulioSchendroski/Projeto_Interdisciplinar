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
        private conexaoPostgres conexao = new conexaoPostgres();

       
        //INSERTS
        public void inserir()
        {
           
            try
            {
                string sql = "INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (" + id + ",'" + nome + "', '" + status + "'," + depto_cod + ",'" + cargo + "');";

                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar o gerente.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //UPDATES
        public void update()
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET ";
                sql += "p_nome ='" + nome + "', ";
                sql += "p_depto_cod = " + depto_cod + ",";
                sql += "p_status  ='" + status + "' ";
                sql += " WHERE p_matricula =" + id + ";";


                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o gerente. Verifique a matrícula", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //DROPS
        public void delete() //Nenhum gerente é excluido do banco quando se torna inativo
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET p_status = 'inativo' WHERE p_matricula = " + id + ";";


                conexao.executarSql(sql);
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
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa  inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'gerente' ORDER BY p_status DESC, d_nome ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesDepartamento(int dp) //seleciona os gerentes por departamento
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            dp += 1;
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa  inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'gerente' and d_codigo = " + dp + "ORDER BY p_status DESC, d_nome ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesStatusDepartamentos(string status, int departamento) //seleciona os gerentes por status e departamento
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            departamento += 1;
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_status = '" + status + "' and d_codigo = '" + departamento + "' and p_cargo = 'gerente' ORDER BY p_cargo DESC, d_nome; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectGerentesStatus(string status) //seleciona os gerentes por status
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_status = '" + status + "' and p_cargo = 'gerente' ORDER BY p_cargo DESC;";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectGeren() //seleciona todos os dados de um único gerente
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'gerente' and p_matricula = " + id + ";";
            adapter = conexao.executaRetornaDados(sql);
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