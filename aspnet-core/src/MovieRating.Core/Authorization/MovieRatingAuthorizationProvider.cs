using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MovieRating.Authorization
{
    public class MovieRatingAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Reviewer, L("Reviewer"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission("Administration.UserManagement.CreateUser", L("CreateUsers"));      
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MovieRatingConsts.LocalizationSourceName);
        }
    }
}
