using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.ObjectValue;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationService.Advertisements.CommadnHandlers
{
    public class SetTitleHandler : ICommandHandler<SetTitle>
    {
        private readonly IUnitOfWork _unitOfWork;

        protected readonly IAdvertisementRepository _advertisementRepository;

        public SetTitleHandler(IUnitOfWork unitOfWork,IAdvertisementRepository advertisementsRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementsRepository;
        }
        public void Handle(SetTitle command)
        {
            var advertisement = _advertisementRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.SetTitle(AdvertismentTitle.FromString(command.Title));
            _unitOfWork.Commit();
        }
    }
}
