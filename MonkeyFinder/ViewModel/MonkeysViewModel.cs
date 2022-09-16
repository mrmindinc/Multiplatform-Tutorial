using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MindMap.Model;
using MindMap.Services;
using MindMap.View;

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MindMap.ViewModel
{
    public partial class MonkeysViewModel : BaseViewModel
    {
        public ObservableCollection<Monkey> Monkeys
        {
            get;
        }
        public MonkeysViewModel(MonkeyService service, IConnectivity connectivity, IGeolocation geolocation)
        {
            Monkeys = new ObservableCollection<Monkey>();
            this.service = service;
            this.connectivity = connectivity;
            this.geolocation = geolocation;
            Title = "Monkey Finder";
        }
        [RelayCommand]
        async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!", $"Please check internet and try again.", "OK");

                    return;
                }
                IsBusy = true;
                var monkeys = await service.GetMonkeys();

                if (Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        [RelayCommand]
        async Task GoToDetails(Monkey monkey)
        {
            if (monkey == null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                { "Monkey", monkey }
            });
        }
        [RelayCommand]
        async Task GetClosestMonkey()
        {
            if (IsBusy || Monkeys.Count == 0)
                return;

            try
            {
                var location = await geolocation.GetLastKnownLocationAsync();

                location ??= await geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
                var first = Monkeys
                    .OrderBy(o => location.CalculateDistance(new Location(o.Latitude, o.Longitude), DistanceUnits.Miles))
                    .FirstOrDefault();

                await Shell.Current.DisplayAlert("", string.Concat(first.Name, ' ', first.Location), "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to query location: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
        [ObservableProperty]
        bool isRefreshing;

        readonly MonkeyService service;
        readonly IConnectivity connectivity;
        readonly IGeolocation geolocation;
    }
}