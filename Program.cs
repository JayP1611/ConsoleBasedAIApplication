using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    private static readonly string API_URL = "https://api-inference.huggingface.co/models/facebook/blenderbot-400M-distill";

    private static readonly string API_KEY = Environment.GetEnvironmentVariable("HUGGING_FACE_API_KEY");


    static async Task Main()
    {
        Console.WriteLine("Chatbot Terminal (type 'exit' to quit)");

        while (true)
        {
            Console.Write("\nYou: ");
            string userInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("⚠️ Please enter a message.");
                continue;
            }

            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("👋 Goodbye!");
                break;
            }

            string response = await GetHuggingFaceResponse(userInput);
            Console.WriteLine("AI: " + response);
        }
    }

    static async Task<string> GetHuggingFaceResponse(string prompt)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {API_KEY}");

            var requestBody = new { inputs = prompt };
            string jsonBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(API_URL, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                // Try to deserialize response as JObject (for single object)
                try
                {
                    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(responseBody);

                    // Check for "generated_text" in response object
                    if (jsonResponse["generated_text"] != null)
                    {
                        return jsonResponse["generated_text"].ToString();
                    }
                    return "⚠️ No response from AI.";
                }
                catch
                {
                    // If deserialization fails as JObject, try as JArray (array)
                    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(responseBody);

                    // Check if array is not empty and has "generated_text"
                    if (jsonResponse.Count > 0 && jsonResponse[0]["generated_text"] != null)
                    {
                        return jsonResponse[0]["generated_text"].ToString();
                    }

                    return "⚠️ No response from AI.";
                }
            }
            catch (Exception ex)
            {
                return $"❌ Error: {ex.Message}";
            }
        }
    }
}


