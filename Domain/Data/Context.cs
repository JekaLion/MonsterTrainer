using Domain.entities;
using Domain.Entities;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<UserMonster> UserMonsters { get; set; }
    }
}
