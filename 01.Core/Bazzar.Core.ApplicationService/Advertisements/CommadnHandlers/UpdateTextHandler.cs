using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.ObjectValue;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationService.Advertisements.CommadnHandlers
{
    public class UpdateTextHandler : ICommandHandler<UpdateText>
    {

        private readonly IUnitOfWork _unitOfWork;
        protected readonly IAdvertisementRepository _advertisementRepository;

        public UpdateTextHandler(IUnitOfWork unitOfWork,IAdvertisementRepository advertisementsRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementsRepository;
        }
        public void Handle(UpdateText command)
        {
            var advertisement = _advertisementRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.UpdateText(AdvertismentText.FromString(command.Text));
            _unitOfWork.Commit();
        }
    }
}
