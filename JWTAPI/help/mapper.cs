using AutoMapper;
using JWTAPI.Data;
using JWTAPI.Models;

namespace JWTAPI.help
{
    public class mapper : Profile
    {
        public mapper()
        {
            CreateMap<ModelArea, Area>().ReverseMap();
        }
    }
}
