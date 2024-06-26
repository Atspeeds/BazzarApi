﻿using Bazzar.Core.Domain.Advertisements.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bazzar.Core.Domain.Advertisements.ObjectValue;

namespace Bazzar.Infrastructures.Data.Sql.Advertisments
{
    public partial class AdvertismentConfig : IEntityTypeConfiguration<Advertisment>
    {
        public void Configure(EntityTypeBuilder<Advertisment> builder)
        {
            builder.Property(c => c.Price).HasConversion(c => c.Value.Value, d => Price.FromLong(d));
            builder.Property(c => c.OwnerId).HasConversion(c => c.Value.ToString(), d => UserId.FromString(d));
            builder.Property(c => c.ApprovedBy).HasConversion(c => c.Value.ToString(), d => UserId.FromString(d));
            builder.Property(c => c.Text).HasConversion(c => c.Value, d => AdvertismentText.FromString(d));
            builder.Property(c => c.Title).HasConversion(c => c.Value, d => AdvertismentTitle.FromString(d));
        }
    }
 
}
