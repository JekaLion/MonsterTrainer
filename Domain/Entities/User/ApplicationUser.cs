using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public string UserNickname { get; set; }
        public long Money { get; set; }
        public IEnumerable<UserMonster> Monsters { get; set; }
    }
}
