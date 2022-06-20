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
        private iConexaoBD conexao = new conexaoPostgres();

        public void criaGerente(csGerente g, Int32 id, string nome, string status, string cargo, Int32 depto_cod)
        {
            g.setIdPessoa(id);
            g.setNomePessoa(nome);
            g.setStatusPessoa(status);
            g.setCargoPessoa(cargo);
            g.setDepartamentoPessoa(depto_cod);

            g.inserir();
        }

        public void alteraGerente(csGerente g, string nome, string status, Int32 depto_cod)
        {
            g.setNomePessoa(nome);
            g.setStatusPessoa(status);
            g.setDepartamentoPessoa(depto_cod);

            g.update();
        }

        public void inativaGerente(csGerente g)
        {
            g.delete();
        }

        public void criaDepto(csDepartamento d, Int32 codigo, string nome, string descricao)
        {
            d.setIdDepartamento(codigo);
            d.setNomeDepartamento(nome);
            d.setDescricaoDepartamento(descricao);

            d.inserir();
        }

        public void alteraDepto(csDepartamento d, string nome, string descricao)
        {
            d.setNomeDepartamento(nome);
            d.setDescricaoDepartamento(descricao);

            d.update();
        }

        public void deletaDepto(csDepartamento d)
        {
            d.delete();
        }

        //INSERTS
        public override void inserir()
        {
            try
            {
                string sql = "INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) " +
                    "VALUES (" + id + ",'" + nome + "', '" + status + "','" + cargo + "');";

                conexao.conectaDiretor();
                conexao.executarSql(sql);
                conexao.desconectaBD();

            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar o diretor.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //UPDATES
        public override void update()
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET ";
                sql += "p_nome ='" + nome + "', ";
                sql += "p_status  ='" + status + "' ";
                sql += " WHERE p_matricula =" + id + ";";


                conexao.conectaDiretor();
                conexao.executarSql(sql);
                conexao.desconectaBD();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o diretor. Verifique a matrícula", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //DELETE (UPDATE)
        public override void delete() //Nenhum diretor é excluido do banco quando se torna inativo
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
                MessageBox.Show("Não foi possível alterar o diretor. ", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //SELECTS
        public DataTable selectTodosDiretor() //Seleciona todos os diretor
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa where " +
                "p_cargo = 'diretor' ORDER BY p_status DESC;";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }


        public DataTable selectDiretorStatus(string status) //seleciona os diertor por status
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa where " +
                "p_status = '" + status + "' and p_cargo = 'diretor' ORDER BY p_cargo DESC;";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public void selectDiretor() //seleciona todos os dados de um único diretor
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa where " +
                "p_cargo = 'diretor' and p_matricula = " + id + ";";

            conexao.conectaDiretor();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(dataset);
            Console.WriteLine();

            id = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
            nome = dataset.Tables[0].Rows[0][1].ToString();
            status = dataset.Tables[0].Rows[0][2].ToString();
            cargo = dataset.Tables[0].Rows[0][3].ToString();
        }
    }
}