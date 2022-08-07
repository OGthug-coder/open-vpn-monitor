using CoinKeeper.DataAccess.Database.Maps;
using Microsoft.EntityFrameworkCore;
using OpenVpnMonitor.Domain.Models;

namespace CoinKeeper.DataAccess.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<VpnUser> VpnUsers { get; set; } = null!;
    public virtual DbSet<Record> Records { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VpnUserMap());
        modelBuilder.ApplyConfiguration(new RecordMap());
        
        base.OnModelCreating(modelBuilder);
    }
}