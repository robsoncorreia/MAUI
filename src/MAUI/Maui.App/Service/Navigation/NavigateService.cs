using Maui.App.Service.Settings;

namespace Maui.App.Service.Navigation
{
    public class NavigateService : INavigationService
    {
        private readonly ISettingsService _settingsService;

        public NavigateService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Task InitializeAsync()
        {
            return NavigateToAsync("..");
        }

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            try
            {
                ShellNavigationState shellNavigation = new(route);

                return routeParameters != null
                    ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                    : Shell.Current.GoToAsync(shellNavigation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Shell.Current.GoToAsync("..");
            }
        }

        public Task PopAsync()
        {
            return Shell.Current.GoToAsync("..");
        }
    }
}