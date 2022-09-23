using CommunityToolkit.Mvvm.Input;
using Maui.App.ViewModels.Base;

namespace Maui.App.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        private int count;

        private string _counterText = Properties.Resources.Click_Me;

        public string CounterText
        {
            get => _counterText;
            set => SetProperty(ref _counterText, value);
        }


        public MainViewModel()
        {
            OnCounterClickedCommand = new AsyncRelayCommand<string>(OnCounterClicked);
        }
        public IAsyncRelayCommand<string> OnCounterClickedCommand { get; }

        private async Task OnCounterClicked(string? test)
        {
            CounterText = $"Clicked {++count} time{(count == 1 ? "" : "s")}";
        }
    }
}
