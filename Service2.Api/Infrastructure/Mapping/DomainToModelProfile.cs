using AutoMapper;
using Service2.Api.Application.Models;
using Service2.Domain;

namespace Service2.Api.Infrastructure.Mapping
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<Organization, OrganizationModel>();
        }
    }
}
