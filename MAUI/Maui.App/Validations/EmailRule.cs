using System.Text.RegularExpressions;

namespace Maui.App.Validations
{
    public class EmailRule<T> : IValidationRule<T>
    {
        private readonly Regex _regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value is not string str)
            {
                return false;
            }
            if (!_regex.IsMatch(str))
            {
                return false;
            }
            return true;
        }
    }
}

