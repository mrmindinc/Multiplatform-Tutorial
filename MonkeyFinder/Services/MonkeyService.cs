using MindMap.Model;

using System.Net.Http.Json;

namespace MindMap.Services
{
    public class MonkeyService
    {
        public async Task<List<Monkey>> GetMonkeys()
        {
            if (monkeyList?.Count > 0)
                return monkeyList;

            var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");

            if (response.IsSuccessStatusCode)
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();

            return monkeyList;
        }
        public MonkeyService() => this.httpClient = new HttpClient();
        List<Monkey> monkeyList;
        readonly HttpClient httpClient;
    }
}