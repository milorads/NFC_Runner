using NfcEditor.Controller;
using System.Windows;

namespace NfcEditor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tray t = new Tray();
            t.InitApplication();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

    }
}
