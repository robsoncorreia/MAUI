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
        public async void Update(object obj)
        {
            try
            {
                await _projectApplication.Update(Project);
            }
            catch (Exception ex)
            {
            }
        }
    }
}