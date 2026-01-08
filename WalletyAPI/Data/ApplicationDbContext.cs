using Microsoft.EntityFrameworkCore;
using WalletyAPI.Models.Entities;
using WalletyAPI.Utils.Enums;

namespace WalletyAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserGuardian> UserGuardians { get; set; } = null!;
    public DbSet<Business> Businesses { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // -------------------- User --------------------
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.FirstName).IsRequired();
            entity.Property(u => u.LastName).IsRequired();
            entity.Property(u => u.Email).IsRequired();
            entity.Property(u => u.PhoneNumber).IsRequired();
            entity.Property(u => u.PasswordHash).IsRequired();
            entity.Property(u => u.PasswordSalt).IsRequired();

            entity.Property(u => u.IsVerified)
                  .HasDefaultValue(false);

            entity.Property(u => u.Tier)
                  .HasDefaultValue(TierEnum.Assisted);

            entity.Property(u => u.CreatedDate)
                  .HasDefaultValueSql("GETUTCDATE()");

            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.PhoneNumber).IsUnique();
            entity.HasIndex(u => u.MerchantId).IsUnique();

            entity.HasOne(u => u.MerchantProfile)
                  .WithOne()
                  .HasForeignKey<MerchantProfile>(mp => mp.MerchantId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // -------------------- MerchantProfile --------------------
        modelBuilder.Entity<MerchantProfile>(entity =>
        {
            entity.HasKey(mp => mp.MerchantId);

            entity.HasOne(mp => mp.Business)
                  .WithOne()
                  .HasForeignKey<MerchantProfile>(mp => mp.BusinessId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // -------------------- UserGuardian --------------------
        modelBuilder.Entity<UserGuardian>(entity =>
        {
            entity.HasKey(ug => new { ug.DependentId, ug.GuardianId });

            entity.Property(ug => ug.AssignedDate)
                  .HasDefaultValueSql("GETUTCDATE()");

            entity.HasOne(ug => ug.Dependent)
                  .WithMany(u => u.Guardians)
                  .HasForeignKey(ug => ug.DependentId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ug => ug.Guardian)
                  .WithMany(u => u.Dependents)
                  .HasForeignKey(ug => ug.GuardianId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // -------------------- Business --------------------
        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(b => b.BusinessId);
            entity.OwnsOne(b => b.RegisteredAddress);
        });

        // -------------------- Transaction --------------------
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(t => t.TransactionId);

            entity.Property(t => t.TransactionDate)
                  .HasDefaultValueSql("GETUTCDATE()");

            entity.Property(t => t.TransactionStatus)
                  .HasDefaultValue(TransactionStatusEnum.Pending);

            entity.HasOne(t => t.Sender)
                  .WithMany()
                  .HasForeignKey(t => t.SenderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.Recipient)
                  .WithMany()
                  .HasForeignKey(t => t.RecipientId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}

//entity.Property(u => u.IsMerchant)
//.HasComputedColumnSql(@"CASE WHEN [IsVerified] = CAST(1 AS BIT) AND [Tier] = 1 AND [Role] = 1 AND [KycStatus] = 1 AND [MerchantId] IS NOT NULL THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", stored: true);

//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    base.OnModelCreating(modelBuilder);

//    modelBuilder.ApplyConfigurationsFromAssembly(
//        typeof(ApplicationDbContext).Assembly);
//}