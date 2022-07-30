using System;
using Application.Entity.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Mapping.DataManager
{
	public class MenuMap: IEntityTypeConfiguration<MenuEntity>
    {
        public void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            builder.HasAlternateKey(s => s.Id);
            
        }
    }

}

