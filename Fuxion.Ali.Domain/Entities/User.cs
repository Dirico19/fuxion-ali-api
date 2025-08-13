using Fuxion.Ali.Domain.Entities.Base;

namespace Fuxion.Ali.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public ICollection<UserRole> UserRoles { get; set; } = [];
        public ICollection<Contact> Contacts { get; set; } = [];
    }
}
