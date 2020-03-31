using API.Domain.Entities;
using Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext (DbContextOptions<MyContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder ModelBuilder) {
            base.OnModelCreating (ModelBuilder);
            ModelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
