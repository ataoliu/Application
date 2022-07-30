using System;
using Application.Entity.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Mapping.DataManager
{
    /// <summary>
    /// ClaimsIdentityEntity
    /// </summary>
    public class ClaimsIdentityMap : IEntityTypeConfiguration<ClaimsIdentityEntity>
	{
        public void Configure(EntityTypeBuilder<ClaimsIdentityEntity> builder)
        {
        builder.HasKey(s => s.Id);
        }
    }
}

