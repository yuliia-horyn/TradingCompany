using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IOrderDal
    {
        List<OrderDTO> GetAllOrders();
        OrderDTO CreateOrder(OrderDTO order);
        OrderDTO UpdateOrderByID(OrderDTO order, int id);
        OrderDTO DeleteOrderByID(int id);
    }
}
