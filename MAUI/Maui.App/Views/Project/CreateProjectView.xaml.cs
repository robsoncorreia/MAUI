using Maui.App.ViewModels.Project;

namespace Maui.App.Views.Project;

public partial class CreateProjectView : ContentPage
{
    public CreateProjectView(CreateProjectViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}