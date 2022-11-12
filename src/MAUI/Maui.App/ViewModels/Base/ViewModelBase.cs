using CommunityToolkit.Mvvm.ComponentModel;
using Maui.App.Service.Dialog;
using Maui.App.Service.Navigation;
using Maui.App.Service.Settings;

namespace Maui.App.ViewModels.Base
{
    public partial class ViewModelBase : ObservableObject, IViewModelBase, IDisposable
    {
        private readonly SemaphoreSlim _isBusyLock = new(1, 1);

        [ObservableProperty]
        private double progress;

        [ObservableProperty]
        private bool isInitialized;

        [ObservableProperty]
        private bool isBusy;

        private bool _disposedValue;

        public IDialogService DialogService { get; private set; }

        public INavigationService NavigationService { get; private set; }

        public ISettingsService SettingsService { get; private set; }


        public ViewModelBase(IDialogService dialogService,
                             INavigationService navigationService,
                             ISettingsService settingsService)
        {
            DialogService = dialogService;
            NavigationService = navigationService;
            SettingsService = settingsService;
        }


        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task IsBusyFor(Func<Task> unitOfWork)
        {
            await _isBusyLock.WaitAsync();

            try
            {
                IsBusy = true;

                await unitOfWork();
            }
            finally
            {
                IsBusy = false;
                _ = _isBusyLock.Release();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _isBusyLock?.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
        }
    }
}