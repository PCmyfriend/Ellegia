using System.Text.RegularExpressions;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class ContactType : Entity
    {
        public string Name { get; private set; }
        public string InputMask { get; private set; }

         protected ContactType()
        {
            // empty constructor for EF
        }

        public ContactType(int id, string name, string inputMask)
        {
            Id = id;
            Name = name;
            InputMask = inputMask;
        }

        public bool Validate(string str)
        {
            var match = Regex.Match(str, InputMask, RegexOptions.IgnoreCase);
            return match.Success;
        }
    }
}