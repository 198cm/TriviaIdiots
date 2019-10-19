using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TI_Server
{
    class ApiRequest
    {
        HttpClient client;

        public ApiRequest()
        {
            client = new HttpClient();
        }

        public async Task<QuestionPack> getQuestionsAsync(int amount)
        {
            var response = await client.GetStringAsync($"https://opentdb.com/api.php?amount={amount}&type=multiple");
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(WebUtility.HtmlDecode(response));
            return apiResponse.GetQuestionPack();
        }

        public async Task<Question> getQuestion()
        {
            var response = await client.GetStringAsync("https://opentdb.com/api.php?amount=1&type=multiple");
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(WebUtility.HtmlDecode(response));
            return apiResponse.GetQuestion();
        }

    }
}
