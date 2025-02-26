using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<MediaPost> MediaPosts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<MediaPost>().HasMany(mp => mp.Comments).WithOne(c => c.Post).OnDelete(DeleteBehavior.Cascade);
        // }
    }
}