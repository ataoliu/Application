using System;
using Application.Entity.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Mapping.DataManager
{
    public class CorsMap : IEntityTypeConfiguration<CorsEntity>
    {
        public void Configure(EntityTypeBuilder<CorsEntity> builder)
        {
            builder.HasAlternateKey(s => s.Id);
        }
    }
}

