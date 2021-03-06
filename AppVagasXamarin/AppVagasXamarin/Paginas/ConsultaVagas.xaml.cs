﻿using AppVagasXamarin.Banco;
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
    public partial class ConsultaVagas : ContentPage
    {
        List<Vaga> Lista { get; set; }
        public ConsultaVagas()
        {
            InitializeComponent();

            Database database = new Database();
            Lista = database.Consultar();

            listaVagas.ItemsSource = Lista;
            lblCount.Text = Lista.Count().ToString() + " Vagas encontradas";
        }

        private void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }
        private void GoMinhasVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasVagas());
        }
        private void MaisDetalheAction(object sender, EventArgs args)
        {
            Label lblDetalhe = (Label)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)lblDetalhe.GestureRecognizers[0];
            Vaga vaga = tapGesture.CommandParameter as Vaga;

            Navigation.PushAsync(new DetalheVaga(vaga));
        }
        private void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            listaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(args.NewTextValue)).ToList();
        }
    }
}