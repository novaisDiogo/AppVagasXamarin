using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVagasXamarin.Banco;
using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using AppVagasXamarin.UWP.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace AppVagasXamarin.UWP.Banco
{
    public class Caminho : Icaminho
    {
        public string ObterCaminho(string nomeArquivoBanco)
        {
            string caminhoPasta = ApplicationData.Current.LocalFolder.Path;

            string caminhoBanco = Path.Combine(caminhoPasta, nomeArquivoBanco);

            return caminhoBanco;
        }
    }
}
