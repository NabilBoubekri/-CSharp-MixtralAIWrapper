using System.Text.Json.Nodes;
using System.Text;
using System.Net;
using System.Net.Http.Headers;
using System;
using APINvidiaIA;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
internal class Program
{
    public static List<MessagesData> messagesDatas = new List<MessagesData>();
    private static async Task Main(string[] args)
    {
        MessagesData inialisationPrompt = new MessagesData("La conversation sera en français", "system");
        messagesDatas.Add(inialisationPrompt);
        while (true)
        {
            Console.WriteLine("Question : ");
            string prompt = Console.ReadLine();
            string url = "https://api.nvcf.nvidia.com/v2/nvcf/pexec/functions/8f4118ba-60a8-4e6b-8574-e38a4067a4a3";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");
                MessagesData leMessageData = new MessagesData(prompt, "user");
                messagesDatas.Add(leMessageData);
                MessagesData[] unMsgData = [leMessageData];
                data jsonContentO = new data(messagesDatas.ToArray(), 0.2f, 0.7f, 1024, 42, true);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                string jsonPayload = System.Text.Json.JsonSerializer.Serialize(jsonContentO);
                request.Content = new StringContent(jsonPayload,
                                        Encoding.UTF8,
                                        "application/json");
                request.Content.Headers.ContentEncoding.Clear();
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsStreamAsync();
                byte[] buffer = new byte[1024];
                using (StreamReader streamReader = new StreamReader(result))
                {
                    string line;
                    string oldResult = "";
                    Console.WriteLine("\nReponse :\n");
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length > 20)
                        {
                            string splitLine = line.Substring(6, line.Length - 6);
                            var phrase = System.Text.Json.JsonSerializer.Deserialize<ContentResult>(splitLine);
                            if (phrase != null && phrase.choices[0].delta.content != null)
                            {
                                Console.Write(phrase.choices[0].delta.content);
                                oldResult += phrase.choices[0].delta.content;
                            }
                        }
                    }
                    Console.WriteLine("\n");
                    MessagesData oldMessageData = new MessagesData(prompt, "assistant");
                    messagesDatas.Add(oldMessageData);
                }
            }
        }
    }
}