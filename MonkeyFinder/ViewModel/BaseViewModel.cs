using CommunityToolkit.Mvvm.ComponentModel;

namespace MindMap.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public bool IsNotBusy => IsBusy is false;
        [ObservableProperty, NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        [ObservableProperty]
        string title;
    }
}