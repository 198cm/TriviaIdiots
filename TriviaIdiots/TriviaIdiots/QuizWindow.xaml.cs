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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        internal string VraagContent { get; set; } = "Nog vraag!";
        internal string AnswerLeftUp { get; set; } = "-";
        internal string AnswerLeftDown { get; set; } = "-";
        internal string AnswerRightUp { get; set; } = "-";
        internal string AnswerRightDown { get; set; } = "-";
        internal static Window1 quizw;


        public Window1()
        {
            InitializeComponent();
            quizw = this;
            QuestionContentUpdate();

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
            VraagLabel.Content = VraagContent;
            AnswerButtonLeftUp.Content = AnswerLeftUp;
            AnswerButtonLeftDown.Content = AnswerLeftDown;
            AnswerButtonRightUp.Content = AnswerRightUp;
            AnswerButtonRightDown.Content = AnswerRightDown;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public enum AnswerSpot
        {
            RIGHTUP, RIGHTDOWN, LEFTUP, LEFTDOWN
        }
    }
}
