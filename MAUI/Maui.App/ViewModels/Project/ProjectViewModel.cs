using CommunityToolkit.Mvvm.Input;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Base;
using Maui.Entity.Entity;

namespace Maui.App.ViewModels.Project
{
    public class ProjectViewModel : ViewModelBase
    {

        private  ProjectModel _project;

        public ProjectModel Project
        {
            get => _project;
            set => SetProperty(ref _project, value );
        }

        public ProjectViewModel(IDialogService dialogService,
                                INavigationService navigationService,
                                ISettingsService settingsService) : base(dialogService, navigationService, settingsService)
        {
            _dialogService = dialogService;
            Project = new ProjectModel();
            CreateCommand = new AsyncRelayCommand<object>(Create);
        }

        private async Task Create(object obj)
        {
            await _dialogService.ShowAlertAsync("oi", "oi", "oi");
        }

        private readonly IDialogService _dialogService;

        public IAsyncRelayCommand<object> CreateCommand { get; }
    }
}
