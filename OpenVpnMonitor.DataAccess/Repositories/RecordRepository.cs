using Microsoft.EntityFrameworkCore;
using OpenVpnMonitor.Domain.Models;
using OpenVpnMonitor.Domain.Repositories;

namespace OpenVpnMonitor.DataAccess.Repositories;

public class RecordRepository : IRecordRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RecordRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Record> CreateRecordAsync(Record record)
    {
        _dbContext.Records.Add(record);
        await _dbContext.SaveChangesAsync();
        return record;
    }

    public async Task<Record> FindRecordByIdAsync(long id)
    {
        return (await _dbContext.Records!.FirstOrDefaultAsync(x => x.Id == id))!;
    }

    public IEnumerable<Record> FindRecords(Func<Record, bool> func)
    {
        return _dbContext.Records.Include(record => record.User).Where(func);
    }
}