using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Maui.App.Messenger;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Base;
using Maui.Applications.Interface;
using Maui.Entity.Entity;

namespace Maui.App.ViewModels.Project
{
    public partial class ProjectDetailsViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ProjectModel project;
        private readonly IProjectApplication _projectApplication;

        public ProjectDetailsViewModel(IDialogService dialogService,
                                       INavigationService navigationService,
                                       ISettingsService settingsService,
                                       IProjectApplication projectApplication) : base(dialogService, navigationService, settingsService)
        {
            _projectApplication = projectApplication;

            WeakReferenceMessenger.Default.Register<SelectedProjectChangedMessage>(this, (r, m) =>
            {
                Project = m.Value;
            });
        }

        [RelayCommand]
        private async void EntryReturn(object obj)
        {
            if (!await ValidadeProject(Project))
            {
                return;
            }

            await Update();

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
        public async Task Update(object obj  = null)
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

                await _projectApplication.Update(Project);

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