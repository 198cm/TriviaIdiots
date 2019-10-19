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
using System.Windows.Shapes;

namespace TriviaIdiots
{
    /// <summary>
    /// Interaction logic for WaitRoom.xaml
    /// </summary>
    public partial class WaitRoom : Window
    {
        public WaitRoom()
        {
            InitializeComponent();
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 qw = new Window1();
            qw.Show();
            this.Close();
        }
    }
}
