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
using System.Windows.Threading;
using TI_Server;

namespace TriviaIdiots
{
    /// <summary>
    /// Interaction logic for WaitRoom.xaml
    /// </summary>
    public partial class WaitRoom : Window
    {
        internal static WaitRoom waitr;
        internal string roomcode;
        public Client client;
        bool started = false;
        public WaitRoom(Client client)
        {
            this.client = client;
            ClientRoom cr = new ClientRoom();
            InitializeComponent();
            waitr = this;

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            RoomCodeLabel.Content = roomcode;
            CommandManager.InvalidateRequerySuggested();
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            started = true;
            Application.Current.Dispatcher.Invoke((Action)delegate {
                Window1 qw = new Window1(client);
                qw.Show();
                client.SendRoomStart(roomcode);
                this.Close();
            });
        }

        public void readyGame()
        {
            if (!started)
            {
                started = true;
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    Window1 qw = new Window1(client);
                    qw.Show();
                    client.SendRoomStart(roomcode);
                    this.Close();
                });
            }
        }

    }
}
