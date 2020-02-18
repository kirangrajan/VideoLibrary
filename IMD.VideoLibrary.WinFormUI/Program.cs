using System;
using System.Windows.Forms;

using Microsoft.Practices.Unity;

namespace IMD.VideoLibrary.WinFormUI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var bootStrapper = new Bootstrapper();
            IUnityContainer container = bootStrapper.Run();

            Application.Run(container.Resolve<VideoLibraryDashboard>());
        }
    }
}
