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
    /// Interaction logic for JoinWindow.xaml
    /// </summary>
    public partial class JoinWindow : Window
    {
        public Client client;
        public bool joined = false;
        internal static JoinWindow joinw;
        public JoinWindow(Client client)
        {
            this.client = client;
            joinw = this;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            client.SendRoomConnect(RoomCodeTextBox.Text);
            if (joined)
            {
                WaitRoom wr = new WaitRoom(client);
                wr.roomcode = RoomCodeTextBox.Text;
                wr.Show();
                this.Close();
            }
        }
    }
}
