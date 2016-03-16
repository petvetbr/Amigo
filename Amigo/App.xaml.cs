using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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
            FazerCopiaTrabalho();
            Util.Repositorio = new AmigoRepo.Repositorio(Constantes.NOME_REPOSITORIO);
        }
        private void FazerCopiaTrabalho()
        {
            var dbFile = Constantes.NOME_REPOSITORIO + ".db";
            if (!File.Exists(dbFile)) return;
            if (Directory.Exists("Backup")) Directory.CreateDirectory("Backup");
            File.Copy(dbFile, string.Format("backup\\{0:yyyyMMddHHmmss}{1}", DateTime.Now, dbFile));
            var listaDb = Directory.EnumerateFiles("Backup", "*.db");
            listaDb.Skip(10).ToList().ForEach(p => File.Delete(p));
          
        }
    }
}
