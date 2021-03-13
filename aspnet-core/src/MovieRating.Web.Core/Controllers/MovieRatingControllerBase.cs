using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MovieRating.Controllers
{
    public abstract class MovieRatingControllerBase: AbpController
    {
        protected MovieRatingControllerBase()
        {
            LocalizationSourceName = MovieRatingConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
