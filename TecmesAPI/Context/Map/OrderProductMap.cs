using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecmesAPI.Models;

namespace TecmesAPI.Context.Map
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Machine).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.QuantityDone);
            builder.Property(x => x.ProductId);

            builder.HasOne(x => x.Product);
        }
    }
}

