using Maui.App.Service.Settings;
using Maui.App.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.ViewModels.Base
{
    public interface IViewModelBase : IQueryAttributable
    {
        //public IDialogService DialogService { get; }
        public INavigationService NavigationService { get; }
        public ISettingsService SettingsService { get; }

        public bool IsBusy { get; }

        public bool IsInitialized { get; set; }

        Task InitializeAsync();
    }
}
