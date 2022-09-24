using CommunityToolkit.Maui;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Project;
using Maui.App.Views.Project;
using Maui.Domain.Interface.Project;
using Maui.Domain.Service;

namespace Maui.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
               .RegisterViewModels()
               .RegisterViews()
               .RegisterAppServices();

            return builder.Build();
        }
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IProjectService, ProjectService>();
            mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
            mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
            mauiAppBuilder.Services.AddSingleton<INavigationService, NavigateService>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<ProjectView>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ProjectViewModel>();

            return mauiAppBuilder;
        }
    }
}