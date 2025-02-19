using System.Runtime.InteropServices;
using System.Text;

namespace DEncrypt
{
    internal static class Program
    {
        private static string MutexName = "DEncrypt_SingleInstance_Mutex";
        private static Mutex mutex = new Mutex(true, MutexName);

        [STAThread]
        static void Main(string[] args)
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                    ApplicationConfiguration.Initialize();
                    Application.Run(new DEncryptor(args));
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                
                // Try to find our window
                IntPtr handle = FindWindow(null, "DEncryptor");
                if (handle != IntPtr.Zero)
                {
                    
                    ShowWindow(handle, SW_RESTORE);
                    SetForegroundWindow(handle);

                    if (args.Length > 0)
                    {
                        byte[] bytes = System.Text.Encoding.Unicode.GetBytes(args[0]);
                        IntPtr copyDataStruct = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(COPYDATASTRUCT)));
                        try
                        {
                            COPYDATASTRUCT cds;
                            cds.dwData = (IntPtr)1;
                            cds.cbData = bytes.Length + 1;
                            cds.lpData = Marshal.AllocHGlobal(bytes.Length + 1);
                            Marshal.Copy(bytes, 0, cds.lpData, bytes.Length);
                            Marshal.StructureToPtr(cds, copyDataStruct, false);
                            SendMessage(handle, WM_COPYDATA, IntPtr.Zero, copyDataStruct);
                        }
                        finally
                        {
                            Marshal.FreeHGlobal(copyDataStruct);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Could not find existing window");
                }
            }
        }

        // Existing imports...
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        // New imports for window enumeration
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private const int SW_RESTORE = 9;
        private const int WM_COPYDATA = 0x004A;

        [StructLayout(LayoutKind.Sequential)]
        private struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
    }
}