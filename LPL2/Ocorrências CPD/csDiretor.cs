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
    internal class csDiretor
    {

        //INSTANCIAMENTO DE CLASSES
        private conexaoPostgres conexao = new conexaoPostgres();

        //DECLARAÇÃO DE VARIÁVEIS
        private Int32 idDiretor;
        private string nomeDiretor;
        private string status;
        private string cargo;
      

        //SETS
        public void setIdDiretor(Int32 id) { idDiretor = id; }
        public void setNomeDiretor(string nomeFunc) { this.nomeDiretor = nomeFunc; }
        public void setStatusDiretor(string status) { this.status = status; }
        public void setCargoDiretor(string cargo) { this.cargo = cargo; }
        

        //GETS
        public Int32 getIdDiretor() { return idDiretor; }
        public string getNomeDiretor() { return nomeDiretor; }
        public string getStatusDiretor() { return status; }
        public string getCargoDiretor() { return cargo; }
       


        //INSERTS
        public void inserir()
        {

            try
            {
                string sql = "INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (" + idDiretor + ",'" + nomeDiretor + "', '" + status + "','" + cargo + "');";

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
                sql += "p_nome ='" + nomeDiretor + "', ";
                sql += "p_status  ='" + status + "' ";
                sql += " WHERE p_matricula =" + idDiretor + ";";


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
                string sql = "UPDATE tb.pessoa SET p_status = 'inativo' WHERE p_matricula = " + idDiretor + ";";


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
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa  where p_cargo = 'diretor' and p_matricula = " + idDiretor + ";";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            idDiretor = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
            nomeDiretor = dataset.Tables[0].Rows[0][1].ToString();
            status = dataset.Tables[0].Rows[0][2].ToString();
            cargo = dataset.Tables[0].Rows[0][3].ToString();
          
        }
    }
}