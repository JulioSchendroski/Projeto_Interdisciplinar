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
    interface iConexaoBD
    {
        void conectaAdm();
        void conectaDiretor();
        void conectaGerente();
        void conectaFuncionario();

        void desconectaBD();

        NpgsqlDataAdapter executaRetornaDados(string instrucaoSql);

        void executarSql(string instrucaoSQL);
    }
}
