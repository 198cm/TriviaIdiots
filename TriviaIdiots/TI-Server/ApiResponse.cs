using System;
using System.Collections.Generic;
using System.Text;

namespace TI_Server
{
    class ApiResponse
    {
        public int response_code { get; set; }
        public Question[] results { get; set; }

        public QuestionPack GetQuestionPack()
        {
            return new QuestionPack(results);
        }
    }
}
