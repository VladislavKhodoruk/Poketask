using CommunityToolkit.Mvvm.ComponentModel;

namespace Poketask.ViewModel
{
    public partial class BaseViewModel : ObservableObject 
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        public bool IsNotBusy => !IsBusy;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(WithData))]
        bool noData;
        public bool WithData => !NoData;
        
        [ObservableProperty]
        string title;
    }
}
