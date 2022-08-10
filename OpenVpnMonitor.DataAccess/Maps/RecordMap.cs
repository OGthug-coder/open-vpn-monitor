using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.DataAccess.Maps;

public class RecordMap : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
        builder.HasOne(x => x.User);
    }
}