namespace Fuxion.Ali.Domain.Constants
{
    public static class Roles
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string User = "User";

        // Add more roles as needed
        public static readonly List<string> AllRoles =
        [
            Admin,
            User,
            SuperAdmin
        ];
    }
}
