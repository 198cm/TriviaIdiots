﻿using System;
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
        public JoinWindow()
        {
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
            WaitRoom wr = new WaitRoom();
            wr.Show();
            this.Close();
        }
    }
}