using Bazzar.Core.Domain.Advertisements.Entitys;
using System;

namespace Bazzar.Core.Domain.Advertisements.Data
{
    public interface IAdvertisementRepository
    {
        bool Exists(Guid id);
        Advertisment Load(Guid id);
        void Add(Advertisment entity);

    }
}
