using Crud.UI;
using System;
using System.Windows.Forms;
using Crud.Infra;
using LinqToDB.Data;

namespace Crud
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataConnection.DefaultSettings = new MySettings();
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NinjectRepos.ComponenteModulo(ModuloAplicacao.Create());
            Application.Run(NinjectRepos.Resolve<FomsListaCadastrados>());
                      
            
        }
    }
}
