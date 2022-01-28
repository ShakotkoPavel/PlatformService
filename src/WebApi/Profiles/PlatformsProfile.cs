namespace ApiService.WepApi.Profiles
{
    using ApiService.Contracts.Commands;
    using ApiService.Contracts.Queries;
    using ApiService.Core.Models;
    using AutoMapper;

    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<PlatformModel, PlatformReadQuery>();
            CreateMap<PlatformCreateCommand, PlatformModel>();
        }
    }
}