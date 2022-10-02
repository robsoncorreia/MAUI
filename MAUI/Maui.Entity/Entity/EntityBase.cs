using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Maui.Entity.Entity
{
    public class EntityBase : INotifyPropertyChanged
    {
        public EntityBase()
        {
            Notificacoes = new List<EntityBase>();
        }

        [JsonIgnore]
        [NotMapped]
        public string NameProperty { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string Message { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<EntityBase> Notificacoes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool ValidateEmail(string email)
        {
            Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = regex.Match(email);

            if (!match.Success)
            {
                Notificacoes.Add(new EntityBase
                {
                    Message = $"{email} incorreto!",
                    NameProperty = nameof(email)
                });
                return false;
            }
            return true;
        }

        public bool ValidateDate(DateTime date)
        {
            return !(date > DateTime.Now);
        }

        public int Id { get; set; }
    }
}