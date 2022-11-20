using Maui.App.ViewModels.Project;

namespace Maui.App.Views.Project;

public partial class ProjectDetailsView : ContentPage
{
    public ProjectDetailsView(ProjectDetailsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}