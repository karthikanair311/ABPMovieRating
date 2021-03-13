using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MovieRating.ActorInfo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.ActorInfo
{
    public interface IActorAppService : IApplicationService
    {
        Task<ListResultDto<ActorListDto>> GetAll(GetAllActorInput input);

        void CreateActor(CreateActorInput input);

        void UpdateActor(UpdateActorInput input);

        Task DeleteActor(ActorListDto input);


    }
}
