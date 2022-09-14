using System.Net.Http.Json;

namespace ShareInvest.Services
{
    public class DashboardService
    {
        public DashboardService()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri(Config.APIUrl)
            };
            this.FirstLoad = true;
        }
        Task<T> TryGetAsync<T>(string path)
        {
            if (FirstLoad)
            {
                FirstLoad = false;

                return Task.Run(() => TryGetImplementationAsync<T>(path));
            }
            return TryGetImplementationAsync<T>(path);
        }
        async Task<T> TryGetImplementationAsync<T>(string path)
        {
            T responseData = default;

            try
            {
                var response = await httpClient.GetAsync(path);

                if (response.IsSuccessStatusCode)
                    responseData = await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return responseData;
        }
        bool FirstLoad
        {
            get; set;
        }
        readonly HttpClient httpClient;
    }
}