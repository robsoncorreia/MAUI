using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Maui.Entity.Entity
{
    public class EntityBase
    {
        public EntityBase()
        {
            Notificacoes = new List<EntityBase>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }
        [NotMapped]
        public List<EntityBase> Notificacoes { get; set; }
        public bool ValidateEmail(string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = regex.Match(email);

            if (!match.Success)
            {
                Notificacoes.Add(new EntityBase
                {
                    Mensagem = $"{email} incorreto!",
                    NomePropriedade = nameof(email)
                });
                return false;
            }
            return true;
        }
        public bool ValidateDate(DateTime date)
        {
            return !(date > DateTime.Now);
        }

    }
}
