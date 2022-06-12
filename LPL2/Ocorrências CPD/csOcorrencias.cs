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


        private Int32 o_numero;
        private string status_temp;
        private string status_def;
        private string data;
        private string descricao;
        private Int32 matriculaFuncionario;
        private Int32 depto_cod;
        private string nomeFuncionario;


        //GETS E SETS
        public void setONumero(Int32 o_numero) { this.o_numero = o_numero;}
        public void setStatusTemp(string status_temp) { this.status_temp = status_temp; }
        public void setStatusDef(string status_def) { this.status_def = status_def; }
        public void setData(string data) { this.data = data; }
        public void setDescricao(string descricao) { this.descricao = descricao; }
        public void setMatriculaFuncionario(Int32 matriculaFuncionario) { this.matriculaFuncionario = matriculaFuncionario; }
        public void setDeptoCod(Int32 depto_cod) { this.depto_cod = depto_cod; }

        public Int32 getONumero() { return o_numero; }
        public string getNomeFuncionario(){return nomeFuncionario;}
        public string getStatusTemp() { return status_temp; }
        public string getStatusDef() { return status_def; }
        public string getData() { return data; }
        public string getDescricao() { return descricao; }
        public Int32 getMatriculaFuncionario() { return matriculaFuncionario; }
        public Int32 getDeptoCod() { return depto_cod; }
        


        //INSERTS
        public void inserir()
        {

            try
            {
                string sql = "INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('aberta','" + status_temp + "',to_date('" + data + "','DD/MM/YYYY'), '" + descricao + "'," + matriculaFuncionario + "," + depto_cod + ");";

                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar a ocorrência.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //UPDATES

        public void updateFinalizarStatusTemp() //Funcionário altera o status temporário da ocorrência
        {
            string sql = "UPDATE tb.ocorrencia SET o_status_temp = 'encerrada' WHERE o_numero=" + o_numero + ";";
            conexao.executarSql(sql);
        }
        public void updateFinalizarStatusDef() //Gerente altera o status definitivo da ocorrência
        {
            string sql = "UPDATE tb.ocorrencia SET o_status_def = 'encerrada' WHERE o_numero="+ o_numero + ";";
            conexao.executarSql(sql);
        }

        public void update() 
        {
            string sql = "UPDATE tb.ocorrencia SET o_data = to_date('" + data + "','DD/MM/YYYY'), o_matricula_func = "+matriculaFuncionario+", o_depto_cod = "+depto_cod+", o_descricao = '"+descricao+"' WHERE o_numero=" + o_numero + ";";
            conexao.executarSql(sql);
        }


        //DROPS
        public void delete()
        {

            string sql = "DELETE FROM funcionarios WHERE funcionarios.idFunc =;";
            conexao.executarSql(sql);
        }
        //SELECTS 
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
        public DataTable selectTodasOcorrencias()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select o_numero as ID, o_data as data, o_status_temp as status_temporário, o_status_def as status_definitivo, o_descricao as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func order by o_numero;";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }
            public void selectOcorrenciaSingular()
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select o_numero as ID, o_data as data, o_status_temp as status_temporário, o_status_def as status_definitivo, o_descricao as descrição,o_matricula_func as funcionário,o_depto_cod as departamento from tb.ocorrencia where o_numero = "+o_numero+"; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            o_numero = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
            status_temp = dataset.Tables[0].Rows[0][2].ToString();
            status_def = dataset.Tables[0].Rows[0][3].ToString();
            data = dataset.Tables[0].Rows[0][1].ToString();
            descricao = dataset.Tables[0].Rows[0][4].ToString();
            matriculaFuncionario = Convert.ToInt32(dataset.Tables[0].Rows[0][5]);
            depto_cod = Convert.ToInt32(dataset.Tables[0].Rows[0][6]);
        }
        public void selectNomeFuncionario() {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_nome from tb.pessoa  where p_matricula = "+matriculaFuncionario+";";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            
            nomeFuncionario = dataset.Tables[0].Rows[0][0].ToString();
            
        }

    } }
