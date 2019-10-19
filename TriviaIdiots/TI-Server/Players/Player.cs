using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server.Players
{
    class Player
    {
        public string name { get; set; }
        public ServerClient client { get; set; }

        public Player(ServerClient client, string name)
        {
            this.name = name;
            this.client = client;
        }

        public void sendQuestion(Question question)
        {
            string message = $"Question``{question.category}``{question.question}``";

            int random = new Random().Next(4);
            switch (random)
            {
                case 0:
                    message += $"{question.correct_answer}``";
                    foreach (string answer in question.incorrect_answers)
                    {
                        message += $"{answer}``";
                    }
                    break;
                case 1:
                    message += $"{question.incorrect_answers[0]}``{question.correct_answer}``{question.incorrect_answers[1]}``{question.incorrect_answers[2]}";
                    break;
                case 2:
                    message += $"{question.incorrect_answers[0]}``{question.incorrect_answers[1]}``{question.correct_answer}``{question.incorrect_answers[2]}";
                    break;
                case 3:
                    foreach (string answer in question.incorrect_answers)
                    {
                        message += $"{answer}``";
                    }
                    message += $"{question.correct_answer}``";
                    break;
            }
            message += "~_~";
            this.client.Write(message);
        }
    }
}
