using System.Threading.Tasks;
using Abp.Application.Services;
using MovieRating.Authorization.Accounts.Dto;

namespace MovieRating.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
