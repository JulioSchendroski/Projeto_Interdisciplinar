using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;
using System.IO;

namespace Ocorrências_CPD
{

    class conexaoPostgres : iConexaoBD
    {
        private NpgsqlConnection conn;

        private void conectaBD(string connString)
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        public void conectaAdm()
        {
            conectaBD("Server=localhost;Port=5432;Database=ocorrenciascpd;UserId=adm;Password=ifspadm;sslmode=Prefer;");
        }

        public void conectaDiretor()
        {
            conectaBD("Server=localhost;Port=5432;Database=ocorrenciascpd;UserId=diretor;Password=ifspdiretor;sslmode=Prefer;");
        }

        public void conectaGerente()
        {
            conectaBD("Server=localhost;Port=5432;Database=ocorrenciascpd;UserId=gerente;Password=ifspgerente;sslmode=Prefer;");
        }

        public void conectaFuncionario()
        {
            conectaBD("Server=localhost;Port=5432;Database=ocorrenciascpd;UserId=funcionario;Password=ifspfuncionario;sslmode=Prefer;");
        }

        public void desconectaBD()
        {
            conn.Close();
        }

        public NpgsqlDataAdapter executaRetornaDados(string instrucaoSql)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(instrucaoSql, conn);
            return adapter;
        }

        public void executarSql(string instrucaoSQL)
        {
            NpgsqlCommand command = new NpgsqlCommand(instrucaoSQL, conn);
            _ = command.ExecuteNonQuery();
        }
    }
}