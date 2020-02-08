using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using AppVagasXamarin.Banco;
using Xamarin.Forms;
using System.IO;
using AppVagasXamarin.iOS.Banco;

[assembly: Dependency(typeof(Caminho))]
namespace AppVagasXamarin.iOS.Banco
{
    public class Caminho : Icaminho
    {
        public string ObterCaminho(string nomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoDaBiblioteca = Path.Combine(caminhoDaPasta, "..", "Libray");

            string caminhoBanco = Path.Combine(caminhoDaBiblioteca, nomeArquivoBanco);

            return caminhoBanco;
        }
    }
}