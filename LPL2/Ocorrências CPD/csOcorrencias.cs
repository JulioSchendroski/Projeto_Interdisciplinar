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
        //INSTANCIOAMENTO DE CLASSES
        private iConexaoBD conexao = new conexaoPostgres();

        //DECLARAÇÃO DE VARIÁVEIS
        private Int32 o_numero;
        private string status_temp;
        private string status_def;
        private string data;
        private string data_limite;
        private string descricao;
        private Int32 matriculaFuncionario;
        private Int32 depto_cod;
        private string nomeFuncionario;

        //SETS
        public void setONumero(Int32 o_numero) { this.o_numero = o_numero; }
        public void setStatusTemp(string status_temp) { this.status_temp = status_temp; }
        public void setStatusDef(string status_def) { this.status_def = status_def; }
        public void setData(string data) { this.data = data; }
        public void setDataLimite(string data_limite) { this.data_limite = data_limite; }
        public void setDescricao(string descricao) { this.descricao = descricao; }
        public void setMatriculaFuncionario(Int32 matriculaFuncionario) { this.matriculaFuncionario = matriculaFuncionario; }
        public void setDeptoCod(Int32 depto_cod) { this.depto_cod = depto_cod; }

        //GETS
        public Int32 getONumero() { return o_numero; }
        public string getNomeFuncionario() { return nomeFuncionario; }
        public string getStatusTemp() { return status_temp; }
        public string getStatusDef() { return status_def; }
        public string getData() { return data; }
        public string getDataLimite() { return data_limite; }
        public string getDescricao() { return descricao; }
        public Int32 getMatriculaFuncionario() { return matriculaFuncionario; }
        public Int32 getDeptoCod() { return depto_cod; }


        //INSERTS
        public void inserir()
        {
            try
            {
                string sql = "CALL p_insercao_ocorrencia(to_date('" + data + "','DD/MM/YYYY'), to_date('" + data_limite + "','DD/MM/YYYY'), " +
                    "'" + descricao + "', " + matriculaFuncionario + ", " + depto_cod + ");";

                conexao.conectaGerente();
                conexao.executarSql(sql);
                conexao.desconectaBD();
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

            conexao.conectaFuncionario();
            conexao.executarSql(sql);
            conexao.desconectaBD();
        }

        public void updateFinalizarStatusDef() //Gerente altera o status definitivo da ocorrência
        {
            string sql = "UPDATE tb.ocorrencia SET o_status_def = 'encerrada', o_status_temp = 'encerrada' WHERE o_numero=" +
                o_numero + ";";

            conexao.conectaGerente();
            conexao.executarSql(sql);
            conexao.desconectaBD();
        }

        public void update() //Atualiza todos os dados da ocorrência
        {
            string sql = "UPDATE tb.ocorrencia SET o_data = to_date('" + data + "','DD/MM/YYYY'), o_data_limite = to_date('" + data_limite + "','DD/MM/YYYY'), o_matricula_func = " + 
                matriculaFuncionario + ", o_depto_cod = " + depto_cod + ", o_descricao = '" + descricao + "' WHERE o_numero=" + 
                o_numero + ";";

            conexao.conectaGerente();
            conexao.executarSql(sql);
            conexao.desconectaBD();
        }

        //DELETE
        public void delete()
        {
            string sql = "DELETE FROM tb.ocorrencia WHERE o_numero=" + o_numero + ";";

            conexao.conectaGerente();
            conexao.executarSql(sql);
            conexao.desconectaBD();
        }

        //SELECTS 
        public DataTable selectOcorrencias(int funcionario) //seleciona todas as ocorrências de um único funcionário
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                "depto_cod from vw.v_ocorrencia where matricula_func = " + funcionario + ";";

            conexao.conectaFuncionario();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }
        public DataTable selectOcorrenciasSituacao(int funcionario, int situacao) //seleciona as ocorrências de um único funcionário por situação
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();

            switch(situacao)
            {
                case 1:
                    conexao.conectaFuncionario();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                        "depto_cod from vw.v_ocorrencia where matricula_func = " + funcionario + " and status_temporario = " +
                        "'aberta' and status_definitivo = 'aberta';");
                    conexao.desconectaBD();
                    break;
                case 2:
                    conexao.conectaFuncionario();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                        "depto_cod from vw.v_ocorrencia where matricula_func = " + funcionario + " and status_temporario = " +
                        "'encerrada' and status_definitivo = 'aberta';");
                    conexao.desconectaBD();
                    break;
                case 3:
                    conexao.conectaFuncionario();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                        "depto_cod from vw.v_ocorrencia where matricula_func = " + funcionario + " and status_temporario = " +
                        "'encerrada' and status_definitivo = 'encerrada';");
                    conexao.desconectaBD();
                    break;
            }

            adapter.Fill(tabela);
            return tabela;
        }
        public DataTable selectTodasOcorrenciasSituacao(int situacao) //seleciona todas as ocorrências po situação
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();

            switch (situacao)
            {
                case 1:
                    conexao.conectaGerente();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                    "depto_cod from vw.v_ocorrencia where status_temporario = 'aberta' and status_definitivo = 'aberta';");
                    conexao.desconectaBD();
                    break;
                case 2:
                    conexao.conectaGerente();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                    "depto_cod from vw.v_ocorrencia where status_temporario = 'encerrada' and status_definitivo = 'aberta';");
                    conexao.desconectaBD();
                    break;
                case 3:
                    conexao.conectaGerente();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                        "depto_cod from vw.v_ocorrencia where status_temporario = 'encerrada' and status_definitivo = 'encerrada';");
                    conexao.desconectaBD();
                    break;
            }

            adapter.Fill(tabela);
            return tabela;
        }
        public DataTable selectTodasOcorrenciasStatusDepartamentos(int situacao, Int32 dep) //seleciona todas as ocorrências de um departamento por situação
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();

            switch(situacao)
            {
                case 1:
                    conexao.conectaGerente();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                        "depto_cod from vw.v_ocorrencia where depto_cod = " + dep + " and status_temporario = " +
                        "'aberta' and status_definitivo = 'aberta';");
                    conexao.desconectaBD();
                    break;
                case 2:
                    conexao.conectaGerente();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                        "depto_cod from vw.v_ocorrencia where depto_cod = " + dep + " and status_temporario = " +
                        "'encerrada' and status_definitivo = 'aberta';");
                    conexao.desconectaBD();
                    break;
                case 3:
                    conexao.conectaGerente();
                    adapter = conexao.executaRetornaDados("select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                        "depto_cod from vw.v_ocorrencia where depto_cod = " + dep + " and status_temporario = " +
                        "'encerrada' and status_definitivo = 'encerrada';");
                    conexao.desconectaBD();
                    break;
            }

            adapter.Fill(tabela);
            return tabela;
        }
        public DataTable selectTodasOcorrenciasDepartamento(Int32 departamento) //seleciona todas as ocorrências por departamento
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                "depto_cod from vw.v_ocorrencia where depto_cod = " + departamento + ";";

            conexao.conectaGerente();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectTodasOcorrencias() //seleciona todas as ocorrências
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporário, o_status_def as " +
                "status_definitivo, o_descricao as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia inner " +
                "join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func order by o_numero;";

            conexao.conectaGerente();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(tabela);
            return tabela;
        }
            public void selectOcorrenciaSingular(int u) //seleciona todos os dados de uma única ocorrência
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select ID, data_ocorrencia, data_limite, status_temporario, status_definitivo, descricao, matricula_func, " +
                "depto_cod from vw.v_ocorrencia where ID = " + o_numero + "; ";

            switch (u)
            {
                case 2: conexao.conectaGerente(); break;
                case 3: conexao.conectaFuncionario(); break;
            }
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(dataset);
            Console.WriteLine();

            o_numero = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
            data = dataset.Tables[0].Rows[0][1].ToString();
            data_limite = dataset.Tables[0].Rows[0][2].ToString();
            status_temp = dataset.Tables[0].Rows[0][3].ToString();
            status_def = dataset.Tables[0].Rows[0][4].ToString();
            descricao = dataset.Tables[0].Rows[0][5].ToString();
            matriculaFuncionario = Convert.ToInt32(dataset.Tables[0].Rows[0][6]);
            depto_cod = Convert.ToInt32(dataset.Tables[0].Rows[0][7]);
        }
        public void selectNomeFuncionario() { //seleciona o nome do funcionário de uma determinada matricula 
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_nome from tb.pessoa  where p_matricula = "+matriculaFuncionario+" and p_cargo = 'funcionário' and p_depto_cod = 4;";

            conexao.conectaGerente();
            adapter = conexao.executaRetornaDados(sql);
            conexao.desconectaBD();

            adapter.Fill(dataset);
            Console.WriteLine();

            
            nomeFuncionario = dataset.Tables[0].Rows[0][0].ToString();
            
        }

    } }
