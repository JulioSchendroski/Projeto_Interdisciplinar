﻿using System;
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
    internal class csFuncionario
    {
        private conexaoPostgres conexao = new conexaoPostgres();


        private Int32 idFunc;
        private string nomeFunc;
        private string cidadeFunc;
        private string estadoFunc;
        private Int64 cpfFunc;

      

        public void inserir()
        {
            //INSERT INTO clientes(nomeCliente, cpfCliente, cidadeCliente, estadoCliente) VALUES("'" + nomeCliente + "'," + cpfCliente + ",'" + "'" + cidadeCliente + "','" + estadoCliente)

            string sql = "INSERT INTO funcionarios(nomeFunc, cpfFunc, cidadeFunc, estadoFunc) VALUES('" + nomeFunc + "'," + cpfFunc + ",'" + cidadeFunc + "','" + estadoFunc + "')";

            conexao.executarSql(sql);
        }

        public void update()
        {
            string sql = "UPDATE funcionarios SET nomeFunc='" + nomeFunc + "',cpfFunc= " + cpfFunc + ",cidadeFunc='" + cidadeFunc + "',estadoFunc='" + estadoFunc + "' WHERE idFunc=" + idFunc + ";";
            conexao.executarSql(sql);
        }

        public void delete()
        {

            string sql = "DELETE FROM funcionarios WHERE funcionarios.idFunc =" + idFunc.ToString() + ";";
            conexao.executarSql(sql);
        }

         public DataTable select()
        {
        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
          DataTable tabela = new DataTable();
             string sql = "select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa  inner join tb.departamento on(p_depto_cod = d_codigo) where p_cargo = 'funcionário' ORDER BY p_status DESC, d_nome ASC; ";
         adapter = conexao.executaRetornaDados(sql);
        adapter.Fill(tabela);
           return tabela;
        }

        public void selectFunc()
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "SELECT nomeFunc, cpfFunc, cidadeFunc, estadoFunc FROM funcionarios WHERE idFunc = " + idFunc.ToString() + ";";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            Console.WriteLine();

            // nomeFunc = dataset.Tables[0].Rows[0][0].ToString();
            // cpfFunc = Convert.ToInt64((dataset.Tables[0].Rows[0][1]).ToString());
            // cidadeFunc = dataset.Tables[0].Rows[0][2].ToString();
            // estadoFunc = dataset.Tables[0].Rows[0][3].ToString();
        }
    }
}

