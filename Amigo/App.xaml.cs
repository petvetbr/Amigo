using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Amigo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Util.Repositorio.Dispose();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Util.Repositorio = new AmigoRepo.Repositorio(Constantes.NOME_REPOSITORIO);
        }
    }
}
