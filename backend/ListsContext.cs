using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api;

public class ListsContext : DbContext
{
    public ListsContext(DbContextOptions<ListsContext> options) : base(options)
    {
    }

    public DbSet<ListRecord> Lists { get; set; }
    public DbSet<ListItemRecord> ListItems { get; set; }
    public DbSet<UserRecord> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ListRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany<ListItemRecord>(l => l.Items)
                    .WithOne()
                    .HasForeignKey(li => li.ListId);
            }
        );

        modelBuilder.Entity<UserRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany<ListRecord>(u => u.Lists)
                    .WithOne()
                    .HasForeignKey(l => l.OwnerId);
            }
        );
    }
}