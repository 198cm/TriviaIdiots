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

namespace TriviaIdiots
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        internal string VraagContent { get; set; } = "Nog vraag!";
        internal string AnswerLeftUp { get; set; } = "-";
        internal string AnswerLeftDown { get; set; } = "-";
        internal string AnswerRightUp { get; set; } = "-";
        internal string AnswerRightDown { get; set; } = "-";

        public int score = 0;

        public string roomcode = "";

        internal static Window1 quizw;
        public Client client;


        public Window1(Client client)
        {
            this.client = client;
            InitializeComponent();
            quizw = this;
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0,0,1);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            QuestionContentUpdate();
            CommandManager.InvalidateRequerySuggested();
        }

        public void ChangeQuestionContent(string question)
        {
            VraagContent = question;
        }


        public void ChangeAnswerContent(AnswerSpot spot, string text)
        {
            switch (spot)
            {
                case AnswerSpot.LEFTDOWN:
                    AnswerLeftDown = text;
                    break;
                case AnswerSpot.LEFTUP:
                    AnswerLeftUp = text;
                    break;
                case AnswerSpot.RIGHTDOWN:
                    AnswerRightDown = text;
                    break;
                case AnswerSpot.RIGHTUP:
                    AnswerRightUp = text;
                    break;
            }

        }

        public void ChangeAnswerContent(string LeftDown, string LeftUp, string RightDown, string RightUp)
        {
            AnswerLeftDown = LeftDown;
            AnswerLeftUp = LeftUp;
            AnswerRightUp = RightUp;
            AnswerRightDown = RightDown;
        }



        private void QuestionContentUpdate()
        {
            VraagLabel.Text = VraagContent;
            AnswerButtonLeftUp.Content = AnswerLeftUp;
            AnswerButtonLeftDown.Content = AnswerLeftDown;
            AnswerButtonRightUp.Content = AnswerRightUp;
            AnswerButtonRightDown.Content = AnswerRightDown;
            ScoreLabel.Content = $"Score: {score}";
            RoomCodeLabel.Content = $"Roomcode:\n{roomcode}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            checkAnswer(AnswerLeftDown, VraagContent);
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        public enum AnswerSpot
        {
            RIGHTUP, RIGHTDOWN, LEFTUP, LEFTDOWN
        }

        private void LeftTopButton_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer(AnswerLeftUp, VraagContent);
        }

        private void checkAnswer(string answer, string question)
        {
            client.SendAnswer(question, answer);
        }

        private void AnswerButtonRightUp_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer(AnswerRightUp, VraagContent);
        }

        private void AnswerButtonRightDown_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer(AnswerRightDown, VraagContent);
        }
    }
}
