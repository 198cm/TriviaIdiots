﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;

namespace TriviaIdiots
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Client client;
        public bool nameSet = false;

        public MainWindow()
        {
            InitializeComponent();
                client = new Client();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow iw = new InfoWindow();
            iw.Show();
            this.Close();
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameSet == true)
            {
                JoinWindow jw = new JoinWindow(client);
                jw.Show();
                this.Close();
            }
            else
            {
                UsernameTextBox.Text = "Set Name First";
            }
            
        }

        private void LogoLabel_Loaded(object sender, RoutedEventArgs e)
        {
                
           
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            LogoLabel.Foreground = PickBrush();
            CommandManager.InvalidateRequerySuggested();
        }

        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 sw = new Window2();
            sw.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameSet == true)
            {
                WaitRoom wr = new WaitRoom(client);
                wr.Show();
                client.SendRoomCreate(UsernameTextBox.Text);
                this.Close();
            } else
            {
                UsernameTextBox.Text = "Set Name First";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.nameSet = true;
            client.SendConnect(UsernameTextBox.Text);
        }
    }
}
