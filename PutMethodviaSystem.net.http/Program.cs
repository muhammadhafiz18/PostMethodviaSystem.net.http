using System;
using System.Net.Http;
using System.Text.Json;


public class PutMethod
{
    static async Task Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            var post = new { title = "About me", body = "Muhammad Khodjaev", userId = 1 };
            string json = JsonSerializer.Serialize(post);

            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }

            else
            {
                Console.WriteLine($"Error has occured: {response.StatusCode}");
            }
        }
    }
}
