using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using AppVagasXamarin.Banco;
using System.IO;
using AppVagasXamarin.Droid.Banco;

[assembly:Dependency(typeof(Caminho))]//Retorna o caminho especifico de cada plataforma
namespace AppVagasXamarin.Droid.Banco
{
    public class Caminho : Icaminho
    {
        public string ObterCaminho(string nomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBanco = Path.Combine(caminhoDaPasta, nomeArquivoBanco);

            return caminhoBanco;
        }
    }
}