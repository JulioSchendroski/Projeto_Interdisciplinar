using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Ocorrências_CPD
{
    class csAbrirJanelas
    {
        Thread t_abrir_janelas; //Criação de uma thread para abrir janelas separadamente

        //DECLARAÇÃO DE VARIAVEIS
        private Int32 id;
        private Int32 depto_cod;

        //CONTRUTORES
        public csAbrirJanelas(){}
        public csAbrirJanelas(Int32 id, Int32 depto_cod) { this.id = id; this.depto_cod = depto_cod;}

        //ABRIR JANELA GERENTE
        public void abrirJanelaGerente() {
            
            t_abrir_janelas = new Thread(janelaGerente);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaGerente(object obj) {
            Application.Run(new frmGerente(id, depto_cod));
        }

        //ABRIR JANELA DIRETOR
        public void abrirJanelaDiretor()
        {

            t_abrir_janelas = new Thread(janelaDiretor);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaDiretor(object obj)
        {
            Application.Run(new frmDiretor());
        }

        //ABRIR JANELA FUNCIONÁRIO
        public void abrirJanelaFuncionario()
        {

            t_abrir_janelas = new Thread(janelaFuncionario);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaFuncionario(object obj)
        {
            Application.Run(new frmFuncionario(id, depto_cod));
        }

        //ABRIR JANELA CADASTRAR FUNCIONÁRIOS
        public void abrirJanelaCadastrarFuncionario()
        {

            t_abrir_janelas = new Thread(janelaCadastrarFuncionario);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaCadastrarFuncionario(object obj)
        {
            Application.Run(new frmCadastrarFuncionario(id, depto_cod));
        }

        //ABRIR JANELA CADASTRAR GERENTE
        public void abrirJanelaCadastrarGerente()
        {

            t_abrir_janelas = new Thread(janelaCadastrarGerente);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaCadastrarGerente(object obj)
        {
            Application.Run(new frmCadastrarGerente(id,depto_cod));
        }

        //ABRIR JANELA CADASTRAR DEPARTAMENTO
        public void abrirJanelaCadastrarDepartamento()
        {

            t_abrir_janelas = new Thread(janelaCadastrarDepartamento);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaCadastrarDepartamento(object obj)
        {
            Application.Run(new frmCadastrarDepartamento(id, depto_cod));
        }

        //ABRIR JANELA CADASTRAR OCORRENCIAS
        public void abrirJanelaCadastrarOcorrencias()
        {

            t_abrir_janelas = new Thread(janelaCadastrarOcorrencias);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaCadastrarOcorrencias(object obj)
        {
            Application.Run(new frmCadastrarOcorrencias(id, depto_cod));
        }

        //ABRIR JANELA LOGIN (Janela inicial)
        public void abrirJanelaLogin()
        {

            t_abrir_janelas = new Thread(janelaLogin);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaLogin(object obj)
        {
            Application.Run(new ocorrenciasCPD());
        }

        //ABRIR JANELA CADASTRAR DIRETOR
        public void abrirJanelaCadastrarDiretor()
        {

            t_abrir_janelas = new Thread(janelaCadastrarDiretor);
            t_abrir_janelas.SetApartmentState(ApartmentState.STA);
            t_abrir_janelas.Start();
        }
        private void janelaCadastrarDiretor(object obj)
        {
            Application.Run(new frmCadastrarDiretor(id, depto_cod));
        }

    }
}
