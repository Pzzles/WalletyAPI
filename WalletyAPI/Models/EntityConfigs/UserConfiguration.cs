//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using WalletyAPI.Utils.Enums;

//namespace WalletyAPI.Models.Entities.EntityConfigs
//{
//    public class UserConfiguration : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> entity)
//        {
//            entity.HasKey(u => u.UserId);

//            entity.Property(u => u.FirstName).IsRequired();
//            entity.Property(u => u.LastName).IsRequired();
//            entity.Property(u => u.Email).IsRequired();
//            entity.Property(u => u.PhoneNumber).IsRequired();
//            entity.Property(u => u.PasswordHash).IsRequired();
//            entity.Property(u => u.PasswordSalt).IsRequired();

//            entity.Property(u => u.IsVerified)
//                  .HasDefaultValue(false)
//                  .ValueGeneratedOnAdd();

//            entity.Property(u => u.Tier)
//                  .HasDefaultValue(TierEnum.Primary)
//                  .ValueGeneratedOnAdd();

//            entity.Property(u => u.CreatedDate)
//                  .HasDefaultValueSql("GETUTCDATE()")
//                  .ValueGeneratedOnAdd();

//            entity.HasIndex(u => u.Email).IsUnique();
//            entity.HasIndex(u => u.PhoneNumber).IsUnique();
//            entity.HasIndex(u => u.MerchantId).IsUnique();

//            entity.HasOne(u => u.MerchantProfile)
//                  .WithOne()
//                  .HasForeignKey<MerchantProfile>(mp => mp.MerchantId)
//                  .OnDelete(DeleteBehavior.Cascade); throw new NotImplementedException();
//        }
//    }
//}
