using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Login_PharmaSI
{
    internal static class Program
    {
        // --- DPI awareness (utile surtout < .NET 4.7 ; inoffensif sinon) ---
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private static Mutex _single;

        [STAThread]
        static void Main()
        {
            // Instance unique
            bool createdNew;
            _single = new Mutex(initiallyOwned: true, name: "Login_PharmaSI_SingleInstance", createdNew: out createdNew);
            if (!createdNew)
            {
                MessageBox.Show("L'application est déjà ouverte.", "Login PharmaSI",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // DPI awareness – évite le flou/décalages en haute résolution
                try { SetProcessDPIAware(); } catch { /* no-op si non supporté */ }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Gestion centralisée des exceptions UI et non-UI
                Application.ThreadException += (s, e) => ShowFatal(e.Exception);
                AppDomain.CurrentDomain.UnhandledException += (s, e) => ShowFatal(e.ExceptionObject as Exception);

                Application.Run(new Form1());
            }
            finally
            {
                try { _single?.ReleaseMutex(); } catch { }
                _single = null;
            }
        }

        private static void ShowFatal(Exception ex)
        {
            if (ex == null) return;
            MessageBox.Show(ex.Message, "Erreur critique",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
