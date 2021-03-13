using System.Threading.Tasks;
using MovieRating.Configuration.Dto;

namespace MovieRating.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
