﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            Project = new ProjectModel();
            _projectApplication = projectApplication;
        }

        [RelayCommand]
        private async Task Create(object obj)
        {
            try
            {
                IsBusy = true;

                await _projectApplication.Add(Project);

                await DialogService.ShowAlertAsync(Properties.Resources.Project_created_successfully, Properties.Resources.Success, Properties.Resources.Close);
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