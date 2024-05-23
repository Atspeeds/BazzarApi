using Bazzar.Core.Domain.Advertisements.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bazzar.Core.Domain.Advertisements.ObjectValue;

namespace Bazzar.Infrastructures.Data.Sql.Advertisments
{
    public partial class AdvertismentConfig
    {
        public class PictureConfig : IEntityTypeConfiguration<Picture>
        {
            public void Configure(EntityTypeBuilder<Picture> builder)
            {
                builder.Property(c => c.Location).HasConversion(c => c.Url, d => PictureUrl.FromString(d));
                builder.OwnsOne(c => c.Size);
            }
        }
    }
 
}
