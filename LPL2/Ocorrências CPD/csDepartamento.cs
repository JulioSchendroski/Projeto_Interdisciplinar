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
    internal class csDepartamento
    {
        private conexaoPostgres conexao = new conexaoPostgres();


        private Int32 d_codigo;
        private string d_nome;
        private string d_descricao;


        //GETS E SETS
        public void setIdDepartamento(Int32 id) { d_codigo = id; }
        public void setNomeDepartamento(string d_nome) { this.d_nome = d_nome; }
        public void setDescricaoDepartamento(string d_descricao) { this.d_descricao = d_descricao;}
     
        public Int32 getIdDepartamento() { return d_codigo; }
        public string getNomeDepartamento() { return d_nome; }
        public string getDescricaoDepartamento() { return d_descricao;}
    
        //INSERTS
        public void inserir()
        {

            try
            {
                string sql = "INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (" + d_codigo + ",'" + d_nome + "', '" + d_descricao + "');";

                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar o departamento.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //UPDATES
        public void update()
        {
            try
            {
                string sql = "UPDATE tb.departamento SET ";
                sql += "d_nome ='" + d_nome + "', ";
                sql += "d_descricao  ='" + d_descricao + "' ";
                sql += " WHERE d_codigo =" + d_codigo + ";";


                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o Departamento. Verifique o código", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //DROPS
        /*public void delete() //Nenhum gerente é excluido do banco quando se torna inativo
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET p_status = 'inativo' WHERE p_matricula = " + idGeren + ";";


                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o gerente. ", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
        */
        //SELECTS
        public DataTable selectTodosDepartamentos()
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select d_codigo as codigo, d_nome as nome, d_descricao as descrição from tb.departamento order by d_codigo ASC";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

 
        public void selectDepartamento()
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select d_codigo as codigo, d_nome as nome, d_descricao as descrição from tb.departamento where d_codigo = "+d_codigo+ ";";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            d_codigo = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
            d_nome = dataset.Tables[0].Rows[0][1].ToString();
            d_descricao = dataset.Tables[0].Rows[0][2].ToString();
            
        }
    }
}
