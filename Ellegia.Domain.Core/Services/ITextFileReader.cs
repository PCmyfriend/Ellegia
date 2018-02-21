using System.Collections.Generic;

namespace Ellegia.Domain.Core.Services
{
    public interface ITextFileReader
    {
        IEnumerable<string> ReadFile();
    }
}