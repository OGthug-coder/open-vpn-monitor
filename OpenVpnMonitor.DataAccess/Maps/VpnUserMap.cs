using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.DataAccess.Maps;

public class VpnUserMap : IEntityTypeConfiguration<VpnUser>
{
    public void Configure(EntityTypeBuilder<VpnUser> builder)
    {
    }
}