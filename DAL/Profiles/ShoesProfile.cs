using AutoMapper;
using DTO;

namespace DAL.Profiles
{
    public class ShoesProfile:Profile
    {
        public ShoesProfile()
        {
            CreateMap<Shoess, ShoesDTO>().ReverseMap();
        }
    }
}
