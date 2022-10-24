using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _01_AsyncAwait_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_BlockingCode_Click(object sender, RoutedEventArgs e)
        {
            tblock_Message.Text = "";

            Thread.Sleep(10000);
            tblock_Message.Text = "Blocking Code Done";
        }

        private async void btn_NonBlockingCode_Click(object sender, RoutedEventArgs e)
        {
            tblock_Message.Text = "";

            await Task.Delay(10000);
            tblock_Message.Text = "Non-Blocking Code Done";
        }
    }
}
