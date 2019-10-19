using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server
{
    class Question
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public string[] incorrect_answers { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool IsGivenAnswerCorrect(string givenAnswer)
        {
            return correct_answer == givenAnswer;
        }
    }
 
}
