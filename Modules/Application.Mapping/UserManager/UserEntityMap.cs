
using Application.Entity.UserManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Mapping.UserManager
{
    /// <summary>
    /// UserEntityMap
    /// </summary>
    public class UserEntityMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}

