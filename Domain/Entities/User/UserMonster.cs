using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.User
{
    public class UserMonster : BaseEntity
    {
        public long UserId { get; set; }
        public ApplicationUser User { get; set; }
        public long MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int MonsterLevel { get; set; }
    }
}
