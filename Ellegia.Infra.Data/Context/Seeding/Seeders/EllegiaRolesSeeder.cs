using System.Collections.Generic;
using Ellegia.Domain.Models;
using Ellegia.Infra.CrossCutting.Identity.Constants;

namespace Ellegia.Infra.Data.Context.Seeding.Seeders
{
    public class EllegiaRolesSeeder : BaseSeeder<EllegiaRole>
    {
        protected override IEnumerable<EllegiaRole> Seeds => new[]
        {
            new EllegiaRole {Name = Roles.Admin, NormalizedName = Roles.AdminNormalizedName},
            new EllegiaRole {Name = Roles.Secretary, NormalizedName = Roles.SecretaryNormalizedName},
            new EllegiaRole {Name = Roles.Technologist, NormalizedName = Roles.TechnologistNormalizedName},
            new EllegiaRole {Name = Roles.Stockkeeper, NormalizedName = Roles.StockkeeperNormalizedName}
        };
    }
}
