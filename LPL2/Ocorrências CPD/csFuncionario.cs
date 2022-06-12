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
    public class csFuncionario
    {



        //INSTANCIAMENTO DE CLASSES

        private conexaoPostgres conexao = new conexaoPostgres();
        public csFuncionario()
        {
            
        }

        
       
        //DECLARAÇÃO DE VARIAVEIS
        private Int32 idFunc;
        private string nomeFunc;
        private string status;
        private string cargo; 
        private string departamento;
        private Int32 depto_cod;
        

        //GETS E SETS
        public void setIdFuncionario(Int32 id){idFunc = id;}
        public void setNomeFuncionario(string nomeFunc) { this.nomeFunc = nomeFunc;}
        public void setStatusFuncionario(string status) { this.status = status;}
        public void setCargoFuncionario(string cargo) { this.cargo = cargo;}
        public void setDepartamentoFuncionario(Int32 depto_cod) { this.depto_cod = depto_cod + 1; }
        
        public Int32 getIdFuncionario() {return idFunc;}
        public string getNomeFuncionario() { return nomeFunc;}
        public string getStatusFuncionario() { return status; }
        public string getCargoFuncionario() { return cargo; }
        public string getDepartamentoFuncionario() { return departamento; }

        //INSERTS
        public void inserir()
        {
            //INSERT INTO clientes(nomeCliente, cpfCliente, cidadeCliente, estadoCliente) VALUES("'" + nomeCliente + "'," + cpfCliente + ",'" + "'" + cidadeCliente + "','" + estadoCliente)
            try
            {
                string sql = "INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (" + idFunc + ",'" + nomeFunc + "', '" + status + "'," + depto_cod + ",'" + cargo + "');";

                conexao.executarSql(sql);
            }
            catch (Exception) {
                MessageBox.Show("Não foi possível adicionar o funcionário.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //UPDATES
        public void update()
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET ";
                sql += "p_nome ='" + nomeFunc + "', ";
                sql += "p_depto_cod = " + depto_cod + ",";
                sql += "p_status  ='" + status + "' ";
                sql += " WHERE p_matricula =" + idFunc + ";";
                

                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o funcionário. Verifique a matrícula" , "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //DROPS
        public void delete() //Nenhum funcionário é excluido do banco quando se torna inativo
        {
            try
            {
                string sql = "UPDATE tb.pessoa SET p_status = 'inativo' WHERE p_matricula = "+idFunc+";";


                conexao.executarSql(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível alterar o funcionário. ", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            
        }

        //SELECTS
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
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_status = '" + status +"' and d_codigo = '" + departamento + "' and p_cargo = 'funcionário' ORDER BY p_cargo DESC, d_nome; ";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public DataTable selectFuncionariosStatus(string status)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "select p_matricula as matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_status = '" + status + "' and p_cargo = 'funcionário' ORDER BY p_cargo DESC;";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectFunc()
        {
            
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "select p_matricula, p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'funcionário' and p_matricula = "+idFunc+";";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            idFunc = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
            nomeFunc = dataset.Tables[0].Rows[0][1].ToString();
            status = dataset.Tables[0].Rows[0][2].ToString();
            cargo = dataset.Tables[0].Rows[0][3].ToString();
            departamento = dataset.Tables[0].Rows[0][4].ToString();
        }

        
        //SELECT PARA CONFERIR SE OS DADOS DO LOGIN CONFEREM
        public Boolean selectEntrar(Int32 id, string cargo) {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet(); 
            string sql = "select p_cargo, p_matricula from tb.pessoa where p_matricula = '"+id+"';";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();
 
            this.cargo = dataset.Tables[0].Rows[0][0].ToString();
            idFunc = id;
            if (this.cargo == cargo)
            {

                if (this.cargo == "diretor")
                {
                    csAbrirJanelas abrirJanelas = new csAbrirJanelas();
                    abrirJanelas.abrirJanelaDiretor();
                }
                else if (this.cargo == "gerente")
                {
                    csAbrirJanelas abrirJanelas = new csAbrirJanelas();
                    abrirJanelas.abrirJanelaGerente();
                }
                else if (this.cargo == "funcionário")
                {
                    csAbrirJanelas abrirJanelas = new csAbrirJanelas(id);
                    abrirJanelas.abrirJanelaFuncionario();
                }
                return true;
            }
            else
            {
                MessageBox.Show("Dados incorretos! Tente novamente:", "Erro!",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                return false;
            }

            

            
        }
    }
}

