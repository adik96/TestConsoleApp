using Newtonsoft.Json;

namespace CancellationTokenTesterSp;

public static class CancellationTokenTester
{
    public static async Task TestCancellationToken(CancellationTokenSource tokenSrc)
    {
        var client = new HttpClient();

        for (int i = 0; i < 100; i++)
        {
            try
            {
                using (var response = await client.GetAsync("http://asdfast.beobit.net/api/",
                HttpCompletionOption.ResponseHeadersRead, tokenSrc.Token))
                {
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Lorem data = JsonConvert.DeserializeObject<Lorem>(jsonString);
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Operation was cancelled.");
            }

            if (tokenSrc.IsCancellationRequested)
                break;
        }
    }

    public static async Task CancelTestTaskByEnter()
    {
        var cts = new CancellationTokenSource();

        TestCancellationToken(cts);
        while(Console.ReadKey().Key != ConsoleKey.Spacebar)
        {
            Console.WriteLine("Press the Esc key to cancel...");
        }
        cts.Cancel();
    }

    public class Lorem
    {
        public string version { get; set; }
        public string text { get; set; }
    }
}