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

    class conexaoPostgres
    {
        private NpgsqlConnection conn;

        private void conectaNpgsql()
        {
            try
            {
                string connString = "Server=localhost;Port=5432;Database=ocorrenciascpd;UserId=postgres;Password=ifsp;sslmode=Prefer;";
                conn = new NpgsqlConnection(connString);
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        public void desconectaMySql(NpgsqlConnection conn)
        {
            conn.Close();
        }

        public NpgsqlDataAdapter executaRetornaDados(string instrucaoSql)
        {
            conectaNpgsql();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(instrucaoSql, conn);
            return adapter;
        }

        public void executarSql(string instrucaoSQL)
        {
            conectaNpgsql();
            NpgsqlCommand command = new NpgsqlCommand(instrucaoSQL, conn);
            command.ExecuteNonQuery();
        }

    }
}