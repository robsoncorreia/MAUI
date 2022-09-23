using CommunityToolkit.Mvvm.Input;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Base;

namespace Maui.App.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        private int count;

        private string _counterText = Properties.Resources.Click_Me;

        public MainViewModel(IDialogService dialogService,
                             INavigationService navigationService,
                             ISettingsService settingsService) : base(dialogService, navigationService, settingsService)
        {
            OnCounterClickedCommand = new RelayCommand<object>(OnCounterClicked);
        }

        public string CounterText
        {
            get => _counterText;
            set => SetProperty(ref _counterText, value);
        }




        public IRelayCommand<string> OnCounterClickedCommand { get; }

        private void OnCounterClicked(object @object)
        {
            CounterText = $"Clicked {++count} time{(count == 1 ? "" : "s")}";
        }
    }
}
