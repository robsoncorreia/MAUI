using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Base;
using Maui.Applications.Interface;
using Maui.Entity.Entity;
using System.Collections.ObjectModel;

namespace Maui.App.ViewModels.Project
{
    public partial class ListProjectViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ProjectModel project;

        public ObservableCollection<ProjectModel> Projects { get; private set; }

        private readonly IProjectApplication _projectApplication;

        public ListProjectViewModel(IDialogService dialogService,
                                    INavigationService navigationService,
                                    ISettingsService settingsService,
                                    IProjectApplication projectApplication) : base(dialogService, navigationService, settingsService)
        {
            Project = new ProjectModel();

            Projects = new ObservableCollection<ProjectModel>();

            _projectApplication = projectApplication;
        }


        [RelayCommand]
        public async void Loaded(object obj)
        {
            Projects.Clear();

            foreach (var project in await _projectApplication.List())
            {
                Projects.Add(project);
            }
        }
    }
}
