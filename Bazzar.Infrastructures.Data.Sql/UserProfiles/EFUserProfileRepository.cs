﻿using Bazzar.Core.Domain.UserProfiles.Data;
using Bazzar.Core.Domain.UserProfiles.Entities;
using Bazzar.Infrastructures.Data.Sql;
using System;
using System.Linq;

namespace Bazzar.Infrastructures.Data.SqlServer.UserProfiles
{
    public class EFUserProfileRepository : IUserProfileRepository, IDisposable
    {
        private readonly AdvertisementsDbContext advertismentDbContext;

        public EFUserProfileRepository(AdvertisementsDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }
        public void Add(UserProfile entity)
        {
            advertismentDbContext.UserProfiles.Add(entity);
        }

        public void Dispose()
        {
            advertismentDbContext.Dispose();
        }

        public bool Exists(Guid id)
        {
            return advertismentDbContext.UserProfiles.Any(c => c.Id == id);
        }

        public UserProfile Load(Guid id)
        {
            return advertismentDbContext.UserProfiles.Find(id);
        }
    }
}
