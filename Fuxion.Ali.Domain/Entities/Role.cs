using Fuxion.Ali.Domain.Entities.Base;

namespace Fuxion.Ali.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}
