using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Maui.App.Messenger;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Base;
using Maui.App.Views.Project;
using Maui.Applications.Interface;
using Maui.Entity.Entity;
using System.Collections.ObjectModel;

namespace Maui.App.ViewModels.Project
{
    public partial class ListProjectViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ProjectModel selectedItem;

        public ObservableCollection<ProjectModel> Projects { get; private set; }

        private readonly IProjectApplication _projectApplication;

        public ListProjectViewModel(IDialogService dialogService,
                                    INavigationService navigationService,
                                    ISettingsService settingsService,
                                    IProjectApplication projectApplication) : base(dialogService, navigationService, settingsService)
        {
            SelectedItem = new ProjectModel();

            Projects = new ObservableCollection<ProjectModel>();

            _projectApplication = projectApplication;
        }


        [RelayCommand]
        public async void Loaded(object obj)
        {
            Projects.Clear();

            foreach (ProjectModel project in await _projectApplication.List())
            {
                Projects.Add(project);
            }
        }

        [RelayCommand]
        public async void ItemSelected(object obj)
        {
            WeakReferenceMessenger.Default.Send(new SelectedProjectChangedMessage(SelectedItem));
            await NavigationService.NavigateToAsync(nameof(ProjectDetailsView));
        }
    }
}
