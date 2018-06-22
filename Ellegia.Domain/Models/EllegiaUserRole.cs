using Microsoft.AspNetCore.Identity;

namespace Ellegia.Domain.Models
{
    public class EllegiaUserRole : IdentityUserRole<int>
    {
        public EllegiaUser User { get; protected set; }
        public EllegiaRole Role { get; protected set; }
    }
}