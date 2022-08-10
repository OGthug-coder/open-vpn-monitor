using Microsoft.EntityFrameworkCore;
using OpenVpnMonitor.DataAccess.Maps;
using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.DataAccess;

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