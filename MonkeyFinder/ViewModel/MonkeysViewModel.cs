using CommunityToolkit.Mvvm.Input;

using MindMap.Model;
using MindMap.Services;

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
        public MonkeysViewModel(MonkeyService service)
        {
            Monkeys = new ObservableCollection<Monkey>();
            this.service = service;
            Title = "Monkey Finder";
        }
        [RelayCommand]
        async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            try
            {
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
        readonly MonkeyService service;
    }
}