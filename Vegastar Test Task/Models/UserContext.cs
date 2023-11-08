using Microsoft.EntityFrameworkCore;

namespace Vegastar_Test_Task.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserState> UserStates { get; set; } = null!;
        public DbSet<UserGroup> UserGroups { get; set; } = null!;

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserState>().HasData(
                new UserState { Id = 1, Code = StateOption.Active, Description = ""},
                new UserState { Id = 2, Code = StateOption.Blocked, Description = "" });

            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup { Id = 1, Code = GroupOption.Admin, Discription = "All permissions" },
                new UserGroup { Id = 2, Code = GroupOption.User, Discription = "Limited access" });

            modelBuilder.Entity<UserState>()
                        .Property(e => e.Code)
                        .HasConversion(v => v.ToString(), v => (StateOption)Enum.Parse(typeof(StateOption), v));

            modelBuilder.Entity<UserGroup>()
                        .Property(e => e.Code)
                        .HasConversion(v => v.ToString(), v => (GroupOption)Enum.Parse(typeof(GroupOption), v));
        }
    }
}
