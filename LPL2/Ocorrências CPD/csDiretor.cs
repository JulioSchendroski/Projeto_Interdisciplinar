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
    internal class csDiretor : csPessoa
    {

        //INSTANCIAMENTO DE CLASSES
        private conexaoPostgres conexao = new conexaoPostgres();

  
        //INSERTS
        public void inserir()
        {

            try
            {
                string sql = "INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (" + id + ",'" + nome + "', '" + status + "','" + cargo + "');";

                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar o diretor.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //UPDATES
        public void update()
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET ";
                sql += "p_nome ='" + nome + "', ";
                sql += "p_status  ='" + status + "' ";
                sql += " WHERE p_matricula =" + id + ";";


                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o diretor. Verifique a matrícula", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //DROPS
        public void delete() //Nenhum diretor é excluido do banco quando se torna inativo
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET p_status = 'inativo' WHERE p_matricula = " + id + ";";


                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o diretor. ", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        //SELECTS
        public DataTable selectTodosDiretor() //Seleciona todos os diretor
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa  where p_cargo = 'diretor' ORDER BY p_status DESC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }


        public DataTable selectDiretorStatus(string status) //seleciona os diertor por status
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa  where  p_status = '" + status + "' and p_cargo = 'diretor' ORDER BY p_cargo DESC;";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectDiretor() //seleciona todos os dados de um único diretor
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa  where p_cargo = 'diretor' and p_matricula = " + id + ";";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            id = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
            nome = dataset.Tables[0].Rows[0][1].ToString();
            status = dataset.Tables[0].Rows[0][2].ToString();
            cargo = dataset.Tables[0].Rows[0][3].ToString();
          
        }
    }
}