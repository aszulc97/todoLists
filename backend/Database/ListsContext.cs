using Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class ListsContext : DbContext
{
    public ListsContext(DbContextOptions<ListsContext> options) : base(options)
    {
    }

    public DbSet<ListRecord> Lists { get; set; }
    public DbSet<ListItemRecord> ListItems { get; set; }
    public DbSet<UserRecord> Users { get; set; }
}