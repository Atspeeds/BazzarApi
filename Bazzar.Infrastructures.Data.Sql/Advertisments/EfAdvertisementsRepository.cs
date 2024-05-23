using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bazzar.Infrastructures.Data.Sql.Advertisments
{
    public class EfAdvertisementsRepository : IAdvertisementRepository,IDisposable
    {
        private readonly AdvertisementsDbContext _dbContext;

        public EfAdvertisementsRepository(AdvertisementsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Advertisment entity)
        {
            _dbContext.Advertisments.Add(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public bool Exists(Guid id)
        {
            return _dbContext.Advertisments.Any(x => x.Id == id);
        }

        public Advertisment Load(Guid id)
        {
            return _dbContext.Advertisments.Find(id);
        }
    }

}
