using Microsoft.EntityFrameworkCore;
using RazorCrudApp.Models;

namespace RazorCrudApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}