using MindMap.ViewModel;

namespace MindMap.View
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(MonkeyDetailsViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
    }
}