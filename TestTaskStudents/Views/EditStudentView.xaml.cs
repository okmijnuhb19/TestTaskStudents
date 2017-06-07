using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using TestTaskStudents.ViewModels;

namespace TestTaskStudents.Views
{
    /// <summary>
    ///     Логика взаимодействия для EditStudentView.xaml
    /// </summary>
    public partial class EditStudentView : Window
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        private const uint MF_BYCOMMAND = 0x00000000;
        private const uint MF_GRAYED = 0x00000001;
        private const uint MF_ENABLED = 0x00000000;

        private const uint SC_CLOSE = 0xF060;

        private const int WM_SHOWWINDOW = 0x00000018;
        private const int WM_CLOSE = 0x10;

        public EditStudentView(EditStudentViewModel viewmodel)
        {
            InitializeComponent();
            NumericUpDown.ValueChanged += viewmodel.ValueChanged;
            viewmodel.CurrentWindow = this;
            Loaded += viewmodel.ViewAppear;
            DataContext = viewmodel;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            var hwndSource = PresentationSource.FromVisual(this) as HwndSource;

            hwndSource?.AddHook(hwndSourceHook);
        }


        private IntPtr hwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SHOWWINDOW)
            {
                var hMenu = GetSystemMenu(hwnd, false);
                if (hMenu != IntPtr.Zero)
                    EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
            }
            else if (msg == WM_CLOSE)
            {
                handled = true;
            }
            return IntPtr.Zero;
        }
    }
}
