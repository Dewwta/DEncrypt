using System.Runtime.InteropServices;
using Microsoft.VisualBasic.ApplicationServices;

namespace DEncrypt
{
    // Create a custom application class that inherits from WindowsFormsApplicationBase
    public class SingleInstanceApplication : WindowsFormsApplicationBase
    {
        private string[] _args;

        public SingleInstanceApplication(string[] args)
        {
            _args = args;
            IsSingleInstance = true;
        }

        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            // This runs when the first instance starts
            DEncryptor mainForm = new DEncryptor(_args);
            mainForm.Show();
            return false;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            // This runs when subsequent instances are started
            base.OnStartupNextInstance(eventArgs);

            // Get the file path from the new instance's command line args
            if (eventArgs.CommandLine.Count > 0)
            {
                // Find our main form instance
                var mainForm = OpenForms.OfType<DEncryptor>().FirstOrDefault();
                if (mainForm != null)
                {
                    // Activate the window and bring it to front
                    mainForm.Invoke(new Action(() => {
                        mainForm.WindowState = FormWindowState.Normal;
                        mainForm.Activate();
                        mainForm.LoadFile(eventArgs.CommandLine[0]);
                    }));
                }
            }
        }
    }
}