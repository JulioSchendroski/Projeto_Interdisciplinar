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
    public abstract class csPessoa
    {
        protected Int32 id;
        protected string nome;
        protected string status;
        protected string cargo;
        protected string departamento;
        protected Int32 depto_cod;


        //SETS
        public void setIdPessoa(Int32 id) { this.id = id; }
        public void setNomePessoa(string nome) { this.nome = nome;}
        public void setStatusPessoa(string status) { this.status = status; }
        public void setCargoPessoa(string cargo) { this.cargo = cargo; }
        public void setDepartamentoPessoa(Int32 depto_cod) { this.depto_cod = depto_cod + 1; }

        //GETS
        public Int32 getIdPessoa() { return id; }
        public string getNomePessoa() { return nome; }
        public string getStatusPessoa() { return status; }
        public string getCargoPessoa() { return cargo; }
        public string getDepartamentoPessoa() { return departamento; }

        public abstract void inserir();
        public abstract void update();
        public abstract void delete();
    }
}
