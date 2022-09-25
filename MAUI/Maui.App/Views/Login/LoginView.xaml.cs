using Maui.App.ViewModels.Login;

namespace Maui.App.Views.Login;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;   
    }
}