﻿using Maui.App.Service.Navigation;
using Maui.App.Views.Project;

namespace Maui.App
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;

        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;

            AppShell.InitializeRouting();

            InitializeComponent();
        }
        protected override async void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            if (Handler is not null)
            {
                await _navigationService.InitializeAsync();
            }
        }

        private static void InitializeRouting()
        {
            Routing.RegisterRoute("Project", typeof(ProjectView));
        }
    }
}