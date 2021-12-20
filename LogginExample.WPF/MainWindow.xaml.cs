using LoggingExample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogginExample.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILoggerEngine _loggerEngine;

        public MainWindow(ILoggerEngine loggerEngine)
        {
            InitializeComponent();
            this._loggerEngine = loggerEngine;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _loggerEngine.Write("button clicked", LogField.UI);
        }
    }
}
