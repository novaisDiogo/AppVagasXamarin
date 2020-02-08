using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVagasXamarin.Banco;
using AppVagasXamarin.Modelos;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVagasXamarin.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarVaga : ContentPage
    {
        public CadastrarVaga()
        {
            InitializeComponent();
        }

        private void SalvarAction(object sender, EventArgs args)
        {
            //TODO - validar Dados Cadastro
            Vaga vaga = new Vaga();
            vaga.NomeVaga = NomeVaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;
            
            Database database = new Database();
            database.Cadastro(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultaVagas());
        }
    }
}