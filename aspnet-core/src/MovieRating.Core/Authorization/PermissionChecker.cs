using Abp.Authorization;
using MovieRating.Authorization.Roles;
using MovieRating.Authorization.Users;

namespace MovieRating.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
