using System.Collections.Generic;
using Ellegia.Infra.Data.Utilities.ConfigurationReader.Contracts;
using Ellegia.Infra.Data.Utilities.ConfigurationReader.Models;
using Microsoft.Extensions.Configuration;

namespace Ellegia.Infra.Data.Utilities.ConfigurationReader
{
    public class EllegiaConfigurationReader : IConfigurationReader
    {   
        public IConfigurationRoot Configuration { get; set; }

        public EllegiaConfigurationReader(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public IEnumerable<Users> Read()
        {           
            var usersInfo = new List<Users>();
            Configuration.GetSection("Users").Bind(usersInfo);

            return usersInfo;
        }
    }   
}