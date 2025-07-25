namespace Fuxion.Ali.Domain.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public User Users { get; set; } = null!;
        public Role Roles { get; set; } = null!;
    }
}
