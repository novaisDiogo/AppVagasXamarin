using AppVagasXamarin.Banco;
using AppVagasXamarin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVagasXamarin.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarVaga : ContentPage
    {
        private Vaga vaga { get; set; }
        public EditarVaga(Vaga vaga)
        {
            InitializeComponent();
            
            this.vaga = vaga;

            NomeVaga.Text = vaga.NomeVaga;
            Empresa.Text = vaga.Empresa;
            Quantidade.Text = vaga.Quantidade.ToString();
            Cidade.Text = vaga.Cidade;
            Salario.Text = vaga.Salario.ToString();
            Descricao.Text = vaga.Descricao;
            TipoContratacao.IsToggled = (vaga.TipoContratacao == "CLT") ? false : true;
            Telefone.Text = vaga.Telefone;
            Email.Text = vaga.Email;
        }
        private void SalvarAction(object sender, EventArgs args)
        {
            //TODO - obter dados da tela
            vaga.NomeVaga = NomeVaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;
            //TODO - Atualizar banco de dados
            Database database = new Database();
            database.Atualizacao(vaga);
            //TODO - redirecionar para minhas vagas cadastradas
            App.Current.MainPage = new NavigationPage(new MinhasVagas());
        }
    }
}