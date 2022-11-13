using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Maui.Entity.Entity
{
    public class ProjectModel : EntityBase
    {
        private string _name = "";

        [NotNull]
        [Column("name")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        private string _description = "";

        [NotNull]
        [Column("description")]
        public string? Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged();
            }
        }

    }
}