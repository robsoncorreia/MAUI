using CommunityToolkit.Mvvm.Input;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.Validations;
using Maui.App.ViewModels.Base;

namespace Maui.App.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        public ValidatableObject<string> Email { get; private set; }
        public IRelayCommand ValidateCommand { get; private set; }

        public LoginViewModel(IDialogService dialogService,
                              INavigationService navigationService,
                              ISettingsService settingsService) : base(dialogService, navigationService, settingsService)
        {
            Email = new ValidatableObject<string>();
            ValidateCommand = new RelayCommand(() => Validate());
            GoToProjectCommand = new AsyncRelayCommand<object>(GoToProject);
            _navigationService = navigationService;
            AddValidations();
        }

        private bool Validate()
        {
            return Email.Validate();
        }

        private void AddValidations()
        {
            Email.Validations.Add(new EmailRule<string> { ValidationMessage = "A email is required." });
        }

        private async Task GoToProject(object arg)
        {
            await _navigationService.NavigateToAsync("//Project");
        }

        public IAsyncRelayCommand<object> GoToProjectCommand { get; }

        private readonly INavigationService _navigationService;
    }
}