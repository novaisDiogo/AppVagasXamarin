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
    public partial class MinhasVagas : ContentPage
    {
        List<Vaga> Lista { get; set; }
        public MinhasVagas()
        {
            InitializeComponent();
            ConsultarVagas();
        }
        private void ConsultarVagas()
        {

            Database database = new Database();
            Lista = database.Consultar();

            listaVagas.ItemsSource = Lista;
            lblCount.Text = Lista.Count().ToString() + " Vagas encontradas";
        }
        private void EditarAction(object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            Vaga vaga = tapGesture.CommandParameter as Vaga;

            Navigation.PushAsync(new EditarVaga(vaga));
        }
        private void ExcluirAction(object sender, EventArgs args)
        {
            Label lblExcluir = (Label)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];
            Vaga vaga = tapGesture.CommandParameter as Vaga;

            Database database = new Database();

            database.Exclusao(vaga);
            ConsultarVagas();
        }
        private void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            listaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(args.NewTextValue)).ToList();
        }
    }
}