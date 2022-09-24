using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;
using Maui.App.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(IDialogService dialogService,
                              INavigationService navigationService,
                              ISettingsService settingsService) : base(dialogService, navigationService, settingsService)
        {
        }
    }
}
