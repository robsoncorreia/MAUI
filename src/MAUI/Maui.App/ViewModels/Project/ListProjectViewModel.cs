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
using Maui.Infrastructure.Query;
using System.Collections.ObjectModel;

namespace Maui.App.ViewModels.Project
{
    public partial class ListProjectViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ProjectModel selectedItem;

        [ObservableProperty]
        private decimal count;

        [ObservableProperty]
        private decimal page = 1;

        [ObservableProperty]
        private decimal size = 5;

        [ObservableProperty]
        private decimal pageCount = 0;

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
        public void NavigatedFrom(object obj)
        {
            ClearProjects();
        }

        private void ClearProjects()
        {
            Projects.Clear();
        }

        [RelayCommand]
        public async void NavigatedTo(object obj)
        {
            await GetProjects();
        }

        [RelayCommand]
        private async Task Delete(object obj)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                if (obj is not ProjectModel project)
                {
                    return;
                }

                await _projectApplication.Delete(project);


                IsBusy = false;

                await GetProjects();
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

        [RelayCommand]
        private async Task PageUp(object obj)
        {
            if (Page >= PageCount)
            {
                return;
            }
            Page++;
            await GetProjects();
        }

        [RelayCommand]
        private async Task PageDown(object obj)
        {
            if (Page == 1)
            {
                return;
            }
            Page--;
            await GetProjects();
        }

        [RelayCommand]
        private async Task GetProjects()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                Projects.Clear();

                Count = await _projectApplication.Count();

                if (Count == 0)
                {
                    await NavigationService.NavigateToAsync(nameof(CreateProjectView));
                    return;
                }

                Size = Size > Count ? Count : Size;

                PageCount = (int)Math.Round((decimal)(Count / Size), MidpointRounding.ToPositiveInfinity);

                Page = Page > PageCount ? PageCount : Page;

                foreach (ProjectModel project in await _projectApplication.List(new QueryParameters { Page = Page, Size = Size }))
                {
                    Projects.Add(project);
                }
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

        [RelayCommand]
        public async void Edit(object obj)
        {
            await NavigationService.NavigateToAsync(nameof(ProjectDetailsView));
            _ = WeakReferenceMessenger.Default.Send(new SelectedProjectChangedMessage(SelectedItem));
        }

        [RelayCommand]
        public async void GoCreateProject(object obj)
        {
            await NavigationService.NavigateToAsync(nameof(CreateProjectView));
        }
    }
}
