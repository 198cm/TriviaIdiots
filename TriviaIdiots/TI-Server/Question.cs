using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server
{
    class Question
    {
        private string category { get; set; }
        private string type { get; set; }
        private Difficulty difficulty { get; set; }
        private string question { get; set; }
        private string correctAnswer { get; set; }
        private string[] incorrectAnswers { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }




    public enum Difficulty
    {
        Easy, Medium, Hard
    }
}
