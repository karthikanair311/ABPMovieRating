using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MovieRating.ActorInfo.Dto;
using AutoMapper;

namespace MovieRating.ActorInfo
{
    public class ActorAppService : MovieRatingAppServiceBase, IActorAppService
    {
        private readonly IRepository<ActorDetails> _actorRepository;
       

        public ActorAppService(IRepository<ActorDetails> actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<ListResultDto<ActorListDto>> GetAll(GetAllActorInput input)
        {
            var m = await _actorRepository.GetAll().WhereIf(!input.ActorGender.IsNullOrEmpty(), t => t.ActorGender == input.ActorGender).ToListAsync();

            var actordto = ObjectMapper.Map<List<ActorListDto>>(m);
            return new ListResultDto<ActorListDto>(actordto);
        }


        public void CreateActor(CreateActorInput input)
        { 
             var actor = ObjectMapper.Map<ActorDetails>(input);
           // var actor = new ActorDetails { ActorName = input.ActorName, ActorGender = input.ActorGender };
            _actorRepository.Insert(actor);
        }

        public void UpdateActor(UpdateActorInput input)
        {
            var actor = _actorRepository.Get(input.Id);
            ObjectMapper.Map(input, actor);

        }

        public async Task DeleteActor(ActorListDto input)
        {
            await _actorRepository.DeleteAsync(input.Id);
        }


    }
}
