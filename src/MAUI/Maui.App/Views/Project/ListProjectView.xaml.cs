using Maui.App.ViewModels.Project;

namespace Maui.App.Views.Project;

public partial class ListProjectView : ContentPage
{
    public ListProjectView(ListProjectViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}