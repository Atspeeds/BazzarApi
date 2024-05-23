using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entitys;
using Bazzar.Core.Domain.Advertisements.ObjectValue;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationService.Advertisements.CommadnHandlers
{
    public class CreateHandler : ICommandHandler<Create>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdvertisementRepository _advertisementRepository;

        public CreateHandler(IUnitOfWork unitOfWork,IAdvertisementRepository advertisementRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementRepository;
        }

        //نیاز به repository 
        public void Handle(Create command)
        {
            if (_advertisementRepository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا آگهی با شناسه {command.Id} ثبت شده است.");

            var advertisement = new Advertisment(command.Id,
                new UserId(command.OwnerId)
            );
            _advertisementRepository.Add(advertisement);
            _unitOfWork.Commit();
        }
    }
}
