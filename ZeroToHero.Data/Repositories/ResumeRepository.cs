using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Repositories;

public class ResumeRepository(AppDbContext dbContext) : GenericRepository<Resume>(dbContext), IResumeRepository
{

}
