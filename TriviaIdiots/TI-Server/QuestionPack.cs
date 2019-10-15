using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server
{
    class QuestionPack
    {
        List<Question> questions;

        public QuestionPack(int size)
        {
            questions = new List<Question>(size);
        }

        public QuestionPack(Question[] questions)
        {
            this.questions = new List<Question>(questions.Length);
            foreach(Question q in questions)
            {
                this.questions.Add(q);
            }
        }

        public void addQuestion(Question question)
        {
            this.questions.Add(question);
        }

        public string toString()
        {
            string total = "";
            foreach(Question q in questions)
            {
                total += q.ToString();
            }
            return total;
        }
    }
}
