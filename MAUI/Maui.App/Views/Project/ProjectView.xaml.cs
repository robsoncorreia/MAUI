using Maui.App.ViewModels.Project;

namespace Maui.App.Views.Project;

public partial class ProjectView : ContentPage
{
    public ProjectView(ProjectViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}