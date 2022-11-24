using DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IRegistered
    {
        List<OrderDTO> GetUserOrders(int currUserID);
        bool CreateOrder(OrderDTO order);
        List<ShoesDTO> GetShoes();
        bool Buy(int shoesid, int userid, int quantity, float price);

    }
}
