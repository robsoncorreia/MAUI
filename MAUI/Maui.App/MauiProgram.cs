using CommunityToolkit.Maui;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Login;
using Maui.App.ViewModels.Project;
using Maui.App.Views.Login;
using Maui.App.Views.Project;
using Maui.Applications.Applications;
using Maui.Applications.Interface;
using Maui.Domain.Interface.Project;
using Maui.Domain.Service;
using Maui.Infrastructure.Repository;
using Maui.Infrastructure.Repository.Interface;

namespace Maui.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            _ = builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    _ = fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    _ = fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
               .RegisterViewModels()
               .RegisterViews()
               .RegisterAppServices();

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
            _ = mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
            _ = mauiAppBuilder.Services.AddSingleton<INavigationService, NavigateService>();

            #region Project

            _ = mauiAppBuilder.Services.AddSingleton<IProjectApplication, ProjectApplication>();
            _ = mauiAppBuilder.Services.AddSingleton<IProjectService, ProjectService>();
            _ = mauiAppBuilder.Services.AddSingleton<IProjectRepository, ProjectRepository>();

            #endregion Project

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddTransient<ProjectView>();
            _ = mauiAppBuilder.Services.AddTransient<LoginView>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddSingleton<ProjectViewModel>();
            _ = mauiAppBuilder.Services.AddSingleton<LoginViewModel>();

            return mauiAppBuilder;
        }
    }
}