using Application.Abstractions.Database;
using Application.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public class OsuVtziContext : DbContext, IOsuVtziContext
{
    public DbSet<AdminEntity> Admin { get; set; }
    
    /// <summary>
    /// OsuVtziContext
    /// </summary>
    /// <param name="options"></param>
    public OsuVtziContext(DbContextOptions<OsuVtziContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}