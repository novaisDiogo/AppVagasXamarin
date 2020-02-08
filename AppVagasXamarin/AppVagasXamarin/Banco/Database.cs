using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppVagasXamarin.Modelos;
using Xamarin.Forms;
using System.Linq;

namespace AppVagasXamarin.Banco
{
    class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            //DependencyService faz a comunicação com base na plataforma que esteja em execução
            //Então pela interface ele pega a infromação de cada plataforma, pois cada plataforma é um caminho diferente
            var dep = DependencyService.Get<Icaminho>();//Dependency service que chama a interface
            //Manda o nome do arquivo pela dependencyService Via interface e recebe o retorno do caminho
            string caminho = dep.ObterCaminho("database.sqlite");//Caminho da conexão

            _conexao = new SQLiteConnection(caminho);//conexao do banco 
            _conexao.CreateTable<Vaga>();
        }

        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();
        }
        public List<Vaga> Pesquisa(string palavra)
        {
            return _conexao.Table<Vaga>().Where(a => a.NomeVaga.Contains(palavra)).ToList();
        }
        public Vaga ObterVagaId(int id)
        {
            return _conexao.Table<Vaga>().Where(a => a.Id == id).FirstOrDefault();
        }
        public void Cadastro(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }
        public void Atualizacao(Vaga vaga)
        {
            _conexao.Update(vaga);
        }
        public void Exclusao(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
