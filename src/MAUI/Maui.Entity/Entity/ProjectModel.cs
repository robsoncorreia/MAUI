using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Maui.Entity.Entity
{
    [Table("Project")]
    public class ProjectModel : EntityBase
    {
        #region field
        private string _name = "";
        private string _description = "";
        private DateTime _createAt;
        private DateTime _updatedAt;
        #endregion field

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


        [NotNull]
        [Column("description")]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                NotifyPropertyChanged();
            }
        }


        [NotNull]
        [Column("createAt")]
        public DateTime CreateAt
        {
            get => _createAt;
            set
            {
                _createAt = value;
                NotifyPropertyChanged();
            }
        }

        [NotNull]
        [Column("updatedAt")]
        public DateTime UpdatedAt
        {
            get => _updatedAt;
            set
            {
                _updatedAt = value;
                NotifyPropertyChanged();
            }
        }


    }
}