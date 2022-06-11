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
    internal class csOcorrencias
    {
        private conexaoPostgres conexao = new conexaoPostgres();


        private Int64 idOcorrencia;
        private string nomeFunc;
        private string cidadeFunc;
        private string estadoFunc;
        private Int64 cpfFunc;


        public void setIdOcorrencia(Int64 idOcorrencia) {
            this.idOcorrencia = idOcorrencia;
        }
        public void inserir()
        {
            //INSERT INTO clientes(nomeCliente, cpfCliente, cidadeCliente, estadoCliente) VALUES("'" + nomeCliente + "'," + cpfCliente + ",'" + "'" + cidadeCliente + "','" + estadoCliente)

            string sql = "INSERT INTO funcionarios(nomeFunc, cpfFunc, cidadeFunc, estadoFunc) VALUES('" + nomeFunc + "'," + cpfFunc + ",'" + cidadeFunc + "','" + estadoFunc + "')";

            conexao.executarSql(sql);
        }

        public void updateFinalizarStatusDef() //Usuário altera o status temporário da ocorrência
        {
            string sql = "UPDATE tb.ocorrencia SET o_status_def = 'encerrada' WHERE o_numero="+idOcorrencia+";";
            conexao.executarSql(sql);
        }

        public void delete()
        {

            string sql = "DELETE FROM funcionarios WHERE funcionarios.idFunc =;";
            conexao.executarSql(sql);
        }

        public DataTable selectOcorrencias(int funcionario)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select o_numero as ID, o_data as data, o_status_temp as status_temporário, o_status_def as status_definitivo, o_descricao as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func where p_matricula = "+funcionario+" order by o_status_def DESC, o_status_temp DESC, o_data ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }
        public DataTable selectOcorrenciasSituacao(int funcionario, string situacao)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select o_numero as ID, o_data as data, o_status_temp as status_temporário, o_status_def as status_definitivo, o_descricao as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func where p_matricula = " + funcionario + " and o_status_def = '" + situacao+"' order by o_status_def DESC, o_status_temp DESC, o_data ASC; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectFunc()
        {

            // MySqlDataAdapter adapter = new MySqlDataAdapter();
            // DataSet dataset = new DataSet();
            //string sql = "SELECT nomeFunc, cpfFunc, cidadeFunc, estadoFunc FROM funcionarios WHERE idFunc = " + idFunc.ToString() + ";";
            // adapter = conexao.executaRetornaDados(sql);
            // adapter.Fill(dataset);
            //Console.WriteLine();

            // nomeFunc = dataset.Tables[0].Rows[0][0].ToString();
            // cpfFunc = Convert.ToInt64((dataset.Tables[0].Rows[0][1]).ToString());
            // cidadeFunc = dataset.Tables[0].Rows[0][2].ToString();
            // estadoFunc = dataset.Tables[0].Rows[0][3].ToString();
        }
    } }
