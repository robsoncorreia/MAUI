using Maui.App.ViewModels.Project;

namespace Maui.App.Views.Project;

public partial class ProjectDetailsView : ContentView
{
    public ProjectDetailsView(ProjectDetailsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}