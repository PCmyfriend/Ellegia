using System.Text.RegularExpressions;
using Ellegia.Domain.Core.Models;
using Ellegia.Domain.Enums;

namespace Ellegia.Domain.Models
{
    public class ContactType : Entity
    {
        public string Name { get; private set; }
        public string InputMask { get; private set; }

        public ContactTypeEnum ContactTypeEnum { get; private set; }

        protected ContactType()
        {
            // required by EF
        }

        public ContactType(int id, string name, string inputMask, ContactTypeEnum contactTypeEnum)
        {
            Id = id;
            Name = name;
            InputMask = inputMask;
            ContactTypeEnum = contactTypeEnum;
        }

        public bool Validate(string str)
        {
            var match = Regex.Match(str, InputMask, RegexOptions.IgnoreCase);
            return match.Success;
        }
    }
}