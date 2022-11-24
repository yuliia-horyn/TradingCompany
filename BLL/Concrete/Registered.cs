using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class Registered: IRegistered
    {
        private readonly IOrderDal _orderDAL;
        private readonly IShoesDal _shoesDAL;
        public Registered(IOrderDal orderDAL, IShoesDal shoesDAL)
        {
            _orderDAL = orderDAL;
            _shoesDAL = shoesDAL;
        }

        public bool Buy(int shoesid, int userid, int quantity, float price)
        {
            var orderDto = new OrderDTO
            {
                ShoeID = shoesid, 
                UserID =  userid,
                Quantity = quantity,
                OrderDate = DateTime.Today,
                Price = price*quantity,
            };
            try
            {
                _orderDAL.CreateOrder(orderDto);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool CreateOrder(OrderDTO orderDTO)
        {
            var res = _orderDAL.CreateOrder(orderDTO);
            return res.OrderID != 0;
        }

        public List<OrderDTO> GetUserOrders(int currUserID)
        {
            return _orderDAL.GetUserOrders(currUserID);
        }
        public List<ShoesDTO> GetShoes()
        {
            return _shoesDAL.GetAllShoes();
        }
    }
}
