using Ellegia.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Ellegia.Infra.CrossCutting.Identity.Models
{
    public class EllegiaUser : IdentityUser<int>, IUser
    {
        
    }
}