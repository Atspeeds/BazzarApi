using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationService.Advertisements.CommadnHandlers
{
    public class RequestToPublishHandler : ICommandHandler<RequestToPublish>
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IAdvertisementRepository _advertisementRepository;

        public RequestToPublishHandler(IUnitOfWork unitOfWork,IAdvertisementRepository advertisementsRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementsRepository;
        }
        public void Handle(RequestToPublish command)
        {
            var advertisement = _advertisementRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.RequestToPublish();
            _advertisementRepository.Add(advertisement);
            _unitOfWork.Commit();
        }
    }
}
