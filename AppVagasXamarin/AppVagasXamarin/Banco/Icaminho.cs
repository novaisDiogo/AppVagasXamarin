using System;
using System.Collections.Generic;
using System.Text;

namespace AppVagasXamarin.Banco
{
    public interface Icaminho
    {
        //interface que atraves do dependencyService vai passar o nome do arquivo e retornar o caminho do banco
        string ObterCaminho(string nomeArquivoBanco);
    }
}
