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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow iw = new InfoWindow();
            iw.Show();
            this.Close();
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e)
        {
            CreditWindow cw = new CreditWindow();
            cw.Show();
            this.Close();
        }
    }
}
