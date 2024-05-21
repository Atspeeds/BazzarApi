using System;
using Bazzar.Core.Domain.Advertisements.ObjectValue;
using Framework.Domain.Events;
using Framework.Domain.Entitys;
using Bazzar.Core.Domain.Advertisements.Events;
using Framework.Tools.Enums;
using Framework.Domain.Exceptions;

namespace Bazzar.Core.Domain.Advertisements.Entitys
{
    public class Advertisment : BaseEntity<Guid>
    {

        #region Fields    
        public UserId OwnerId { get; protected set; }
        public UserId ApprovedBy { get; protected set; }
        public AdvertismentTitle Title { get; protected set; }
        public AdvertismentText Text { get; protected set; }
        public Price Price { get; protected set; }
        public AdvertismentState State { get; protected set; }
        #endregion

        private Advertisment()
        {

        }

        #region Event
        public Advertisment(Guid id, UserId ownerId) =>
            HandleEvent(new AdvertismentCreated
            {
                Id = id,
                OwnerId = ownerId.Value
            });


        public void SetTitle(AdvertismentTitle title) =>
            HandleEvent(new AdvertismentTitleChanged
            {
                Id = Id,
                Title = title.Value
            });
        public void UpdateText(AdvertismentText text) =>
            HandleEvent(new AdvertismentTextUpdated
            {
                Id = Id,
                AdvertismentText = text.Value
            });

        public void UpdatePrice(Price price) =>
            HandleEvent(new AdvertismentPriceUpdated
            {
                Id = Id,
                Price = price.Value.Value
            });

        public void RequestToPublish() =>
            HandleEvent(new AdvertismentSentForReview
            {
                Id = Id
            });

        #endregion

        protected override void ValidateInvariants()
        {
            var isValid =
                Id != null &&
                OwnerId != null &&
                (State switch
                {
                    AdvertismentState.ReviewPending =>
                        Title != null
                        && Text != null
                        && Price != null,
                    //&& !Pictures.Any(),
                    AdvertismentState.Active =>
                        Title != null
                        && Text != null
                        && Price != null
                        && ApprovedBy != null,
                    //&& !Pictures.Any(),
                    _ => true
                });
            if (!isValid)
            {
                throw new InvalidEntityStateException(this, $"مقدار تنظیم شده برای آگهی در وضیعت {State.GetDescription()} غیر قابل قبول است");
            }
        }

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case AdvertismentCreated e:
                    Id = e.Id;
                    OwnerId = new UserId(e.OwnerId);
                    State = AdvertismentState.Inactive;
                    break;
                case AdvertismentPriceUpdated e:
                    Price = new Price(Rial.FromLong(e.Price));
                    break;
                case AdvertismentSentForReview e:
                    State = AdvertismentState.ReviewPending;
                    break;
                case AdvertismentTextUpdated e:
                    Text = new AdvertismentText(e.AdvertismentText);
                    break;
                case AdvertismentTitleChanged e:
                    Title = new AdvertismentTitle(e.Title);
                    break;

                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }
    }
}