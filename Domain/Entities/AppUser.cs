using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<Product> Products { get; set; }
    }
}
