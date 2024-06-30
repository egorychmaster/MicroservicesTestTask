using Service2.Domain;
using AutoMapper;
using Service2.Application.Queries.Organizations.GetOrganizations;
using Service2.Application.Queries.Users.GetUsersFilter;

namespace Service2.Application.Mapping
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
