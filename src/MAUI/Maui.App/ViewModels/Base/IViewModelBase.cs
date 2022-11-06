using Maui.App.Service.Navigation;

/* Alteração não mesclada do projeto 'Maui.App (net6.0-ios)'
Antes:
using Maui.App.Service.Navigation;
Após:
using Maui.App.Service.Settings;
*/

/* Alteração não mesclada do projeto 'Maui.App (net6.0-maccatalyst)'
Antes:
using Maui.App.Service.Navigation;
Após:
using Maui.App.Service.Settings;
*/

/* Alteração não mesclada do projeto 'Maui.App (net6.0-windows10.0.19041.0)'
Antes:
using Maui.App.Service.Navigation;
Após:
using Maui.App.Service.Settings;
*/

using Maui.App.Service.Settings;

namespace Maui.App.ViewModels.Base
{
    public interface IViewModelBase : IQueryAttributable
    {
        //public IDialogService DialogService { get; }
        public INavigationService NavigationService { get; }

        public ISettingsService SettingsService { get; }

        public bool IsBusy { get; }

        public bool IsInitialized { get; set; }
    }
}