using System.Threading.Tasks;
using Abp.Application.Services;
using MovieRating.Sessions.Dto;

namespace MovieRating.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
