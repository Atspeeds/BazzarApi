using Framework.Domain.Data;

namespace Bazzar.Infrastructures.Data.Sql
{
    public class AdvertisementsUnitOfWork : IUnitOfWork
    {
        private readonly AdvertisementsDbContext _dbContext;

        public AdvertisementsUnitOfWork(AdvertisementsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }

}
