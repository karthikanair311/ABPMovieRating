using Abp.Application.Services;
using MovieRating.MultiTenancy.Dto;

namespace MovieRating.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

