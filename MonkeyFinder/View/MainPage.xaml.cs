using MindMap.ViewModel;

namespace MindMap.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MonkeysViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}