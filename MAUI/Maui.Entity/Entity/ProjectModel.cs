namespace Maui.Entity.Entity
{
    public class ProjectModel : EntityBase
    {
        private string _name = "";

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
    }
}
