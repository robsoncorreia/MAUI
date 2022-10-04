using CommunityToolkit.Mvvm.Input;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Base;
using Maui.Applications.Interface;
using Maui.Entity.Entity;

namespace Maui.App.ViewModels.Project
{
    public class ProjectViewModel : ViewModelBase
    {
        private ProjectModel _project;
        private readonly IProjectApplication _projectApplication;

        public ProjectModel Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        public ProjectViewModel(IDialogService dialogService,
                                INavigationService navigationService,
                                ISettingsService settingsService,
                                IProjectApplication projectApplication) : base(dialogService, navigationService, settingsService)
        {
            _dialogService = dialogService;
            Project = new ProjectModel();
            CreateCommand = new AsyncRelayCommand<object>(Create);
            _projectApplication = projectApplication;
        }

        private async Task Create(object obj)
        {
            try
            {
                IsBusy = true;

                await _projectApplication.Add(Project);

                await _dialogService.ShowAlertAsync(Properties.Resources.Project_created_successfully, Properties.Resources.Success, Properties.Resources.Close);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowAlertAsync($"{ex.Message}", Properties.Resources.Error, Properties.Resources.Close);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private readonly IDialogService _dialogService;

        public IAsyncRelayCommand<object> CreateCommand { get; }
    }
}