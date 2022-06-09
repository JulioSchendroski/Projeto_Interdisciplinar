using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;

namespace Ocorrências_CPD
{
    public class conexaoMySQL
    {
        private MySqlConnection conn;
        private string servidor = "", database = "", usuario = "", senha = "";

        private void dadosConexao()
        {
            //Editar de acordo com o local do acesso.txt
            string caminho = @"C:\Users\mateu\OneDrive\Área de Trabalho\SistemaDeMercado-MySQL-main\acesso.txt", linha = "";

            //Verificando se o arquivo existe
            if (System.IO.File.Exists(caminho))
            {
                StreamReader arquivo = new StreamReader(caminho);
                while (arquivo.EndOfStream == false)
                {
                    linha = arquivo.ReadLine().ToString();
                    if (linha.Contains("servidor="))
                    {
                        servidor = linha.Substring(9, linha.Length - 9);
                    }
                    else if (linha.Contains("database="))
                    {
                        database = linha.Substring(9, linha.Length - 9);
                    }
                    else if (linha.Contains("usuario="))
                    {
                        usuario = linha.Substring(8, linha.Length - 8);
                    }
                    else if (linha.Contains("senha="))
                    {
                        senha = linha.Substring(6, linha.Length - 6);
                    }

                }
            }
        }
        private void conectaMySql()
        {
            try
            {
                dadosConexao();
                conn = new MySqlConnection("server=" + servidor + ";uid=" + usuario + ";database=" + database + ";pwd=" + senha + ";SSL Mode=None");
                conn.Open();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message.ToString());
            }
        }

        public void desconectaMySql(MySqlConnection conn)
        {
            conn.Close();
        }

        public MySqlDataAdapter executaRetornaDados(string instrucaoSql)
        {
            conectaMySql();
            MySqlDataAdapter adapter = new MySqlDataAdapter(instrucaoSql, conn);
            return adapter;
        }

        public void executarSql(string instrucaoSQL)
        {
            conectaMySql();
            MySqlCommand command = new MySqlCommand(instrucaoSQL, conn);
            command.ExecuteNonQuery();
        }
    }
}
