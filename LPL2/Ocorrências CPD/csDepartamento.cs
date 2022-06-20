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
        //INSTANCIAMENTO DE CLASSES
        private iConexaoBD conexao = new conexaoPostgres();

       //DECLARAÇÃO DE VARIÁVEIS
        private Int32 d_codigo;
        private string d_nome;
        private string d_descricao;


        //SETS
        public void setIdDepartamento(Int32 id) { d_codigo = id; }
        public void setNomeDepartamento(string d_nome) { this.d_nome = d_nome; }
        public void setDescricaoDepartamento(string d_descricao) { this.d_descricao = d_descricao;}
     
        //GETS
        public Int32 getIdDepartamento() { return d_codigo; }
        public string getNomeDepartamento() { return d_nome; }
        public string getDescricaoDepartamento() { return d_descricao;}
    
        //INSERTS
        public void inserir()
        {

            try
            {
                string sql = "INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) " +
                    "VALUES (" + d_codigo + ",'" + d_nome + "', '" + d_descricao + "');";

                conexao.conectaDiretor();
                conexao.executarSql(sql);
                conexao.desconectaBD();
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


                conexao.conectaDiretor();
                conexao.executarSql(sql);
                conexao.desconectaBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o Departamento. Verifique o código", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //DROPS
        public void delete() //Nenhum gerente é excluido do banco quando se torna inativo
        {
            string sql = "DELETE FROM tb.departamento WHERE d_codigo =" + d_codigo + ";";
            conexao.conectaDiretor();
            conexao.executarSql(sql);
            conexao.desconectaBD();

        }
        
        //SELECTS
        public DataTable selectTodosDepartamentos() //seleciona todos os departamentos
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select codigo, nome, descricao from vw.mv_departamento_qtd_pessoas;";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public void selectDepartamento() //seleciona os dados de um único departamento
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select codigo, nome, descricao from vw.mv_departamento_qtd_pessoas where codigo = " + 
                d_codigo + ";";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(dataset);
            Console.WriteLine();

            d_codigo = Convert.ToInt32(dataset.Tables[0].Rows[0][0].ToString());
            d_nome = dataset.Tables[0].Rows[0][1].ToString();
            d_descricao = dataset.Tables[0].Rows[0][2].ToString();
            
        }
    }
}
