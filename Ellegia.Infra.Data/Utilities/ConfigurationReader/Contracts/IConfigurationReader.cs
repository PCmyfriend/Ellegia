using System.Collections.Generic;
using Ellegia.Infra.Data.Utilities.ConfigurationReader.Models;

namespace Ellegia.Infra.Data.Utilities.ConfigurationReader.Contracts
{
    public interface IConfigurationReader
    {
        IEnumerable<Users> Read();   
    }   
}   
    