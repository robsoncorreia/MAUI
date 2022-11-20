using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Base;
using Maui.Applications.Interface;
using Maui.Entity.Entity;

namespace Maui.App.ViewModels.Project
{
    public partial class CreateProjectViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ProjectModel project;

        private readonly IProjectApplication _projectApplication;

        public CreateProjectViewModel(IDialogService dialogService,
                                INavigationService navigationService,
                                ISettingsService settingsService,
                                IProjectApplication projectApplication) : base(dialogService, navigationService, settingsService)
        {
            Project = new ProjectModel();
            _projectApplication = projectApplication;
        }

        [RelayCommand]
        private async void EntryReturn(object obj)
        {
            if (!await ValidadeProject(Project))
            {
                return;
            }

            await Create();
        }

        private async Task<bool> ValidadeProject(ProjectModel project)
        {
            if (string.IsNullOrEmpty(project.Name))
            {
                await DialogService.ShowAlertAsync($"{Properties.Resources.Project_name_cannot_be_empty}", Properties.Resources.Error, Properties.Resources.Close);
                return false;
            }
            if (string.IsNullOrEmpty(project.Description))
            {
                await DialogService.ShowAlertAsync($"{Properties.Resources.Description_cannot_be_empty}", Properties.Resources.Error, Properties.Resources.Close);
                return false;
            }

            return true;
        }

        [RelayCommand]
        private async Task Create(object obj = null)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                if (!await ValidadeProject(Project))
                {
                    return;
                }

                IsBusy = true;

                await _projectApplication.Add(Project);

                Project = new ProjectModel();

                await DialogService.ShowAlertAsync(Properties.Resources.Project_created_successfully, Properties.Resources.Success, Properties.Resources.Close);

                await NavigationService.PopAsync();
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync($"{ex.Message}", Properties.Resources.Error, Properties.Resources.Close);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}