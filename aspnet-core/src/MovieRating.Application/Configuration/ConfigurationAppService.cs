using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MovieRating.Configuration.Dto;

namespace MovieRating.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MovieRatingAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
