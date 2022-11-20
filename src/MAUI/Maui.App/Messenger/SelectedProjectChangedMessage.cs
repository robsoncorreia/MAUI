using CommunityToolkit.Mvvm.Messaging.Messages;
using Maui.Entity.Entity;

namespace Maui.App.Messenger
{
    public class SelectedProjectChangedMessage : ValueChangedMessage<ProjectModel>
    {
        public SelectedProjectChangedMessage(ProjectModel project) : base(project)
        {
        }
    }
}