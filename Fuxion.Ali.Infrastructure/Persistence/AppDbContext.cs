using Fuxion.Ali.Domain.Entities;
using Fuxion.Ali.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fuxion.Ali.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure your entities here
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasOne(e => e.User)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Role)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(e => e.RoleId);
                entity.HasQueryFilter(e => !e.User.IsDeleted && !e.Role.IsDeleted);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.UpdatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);

            });

            ApplyGlobalFilters(modelBuilder);
        }

        private static void ApplyGlobalFilters(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                if (clrType == null || !typeof(BaseEntity).IsAssignableFrom(clrType))
                    continue;

                var parameter = Expression.Parameter(clrType, "e");
                var isDeletedProperty = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                var isNotDeleted = Expression.Equal(isDeletedProperty, Expression.Constant(false));
                var lambda = Expression.Lambda(isNotDeleted, parameter);

                modelBuilder.Entity(clrType).HasQueryFilter(lambda);
            }
        }
    }
}
