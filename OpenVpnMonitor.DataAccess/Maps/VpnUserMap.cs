using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenVpnMonitor.Domain.Models;

namespace CoinKeeper.DataAccess.Database.Maps;

public class VpnUserMap : IEntityTypeConfiguration<VpnUser>
{
    public void Configure(EntityTypeBuilder<VpnUser> builder)
    {
    }
}