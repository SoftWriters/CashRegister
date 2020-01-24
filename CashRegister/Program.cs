using System;
using System.Windows.Forms;
using CashRegister.BL;
using CashRegister.Interfaces;
using SimpleInjector;

namespace CashRegister
{
    internal static class Program
    {
        private static Container _container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(_container.GetInstance<CashRegisterForm>());
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            _container = new Container();

            // Register your types, for instance:
            _container.Register<IUtilities, Utilities>();
            _container.Register<IProcessChangeGenerator, ProcessChangeGenerator>();
            _container.Register<CashRegisterForm>();
        }
    }
}