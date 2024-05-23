using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entitys;
using System;
using System.Collections.Generic;

namespace Bazzar.Infrastructures.Data.Fake.Advertisments
{
    public class FakeAdvertisementsRepository : IAdvertisementRepository
    {
        private readonly Dictionary<Guid, Advertisment> db = new Dictionary<Guid, Advertisment>();
        public bool Exists(Guid id)
        {
            return db.ContainsKey(id);
        }

        public Advertisment Load(Guid id)
        {
            return db[id];
        }

        public void Add(Advertisment entity)
        {
            db[entity.Id] = entity;
        }

  
    }
}
