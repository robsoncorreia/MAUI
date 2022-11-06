using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.Validations;
using Maui.App.ViewModels.Base;

namespace Maui.App.ViewModels.Login
{
    public partial class LoginViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ValidatableObject<string> email;

        public LoginViewModel(IDialogService dialogService,
                              INavigationService navigationService,
                              ISettingsService settingsService) : base(dialogService, navigationService, settingsService)
        {
            Email = new ValidatableObject<string>();
            _navigationService = navigationService;
            AddValidations();
        }


        [RelayCommand]
        public void Validate()
        {
            _ = Email.Validate();
        }

        private void AddValidations()
        {
            Email.Validations.Add(new EmailRule<string> { ValidationMessage = "A email is required." });
        }

        [RelayCommand]
        private async Task GoToProject(object arg)
        {
            await _navigationService.NavigateToAsync("//Project");
        }


        private readonly INavigationService _navigationService;
    }
}