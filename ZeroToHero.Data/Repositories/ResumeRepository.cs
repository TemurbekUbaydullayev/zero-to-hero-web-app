using Microsoft.EntityFrameworkCore;
using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Repositories;
#pragma warning disable
public class ResumeRepository(AppDbContext dbContext) : GenericRepository<Resume>(dbContext), IResumeRepository
{
    public AppDbContext DbContext { get; } = dbContext;
    public async Task<Resume> GetByEmailAsync(string email)
    {
        var resume = await DbContext.Resumes.FirstOrDefaultAsync(r => r.Email == email);
        return resume;
    }
}
