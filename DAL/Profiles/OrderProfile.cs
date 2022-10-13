using AutoMapper;
using DTO;

namespace DAL.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
