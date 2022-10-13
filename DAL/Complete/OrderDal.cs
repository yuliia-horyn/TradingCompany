using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Complete
{
    public class OrderDal : IOrderDal
    {
        private readonly IMapper _mapper;
        public OrderDal(IMapper mapper)
        {
            _mapper = mapper;
        }
        public OrderDTO CreateOrder(OrderDTO order)
        {
            using (var entites = new shoefactoryEntities())
            {
                var orderInDB = _mapper.Map<Order>(order);
                orderInDB.RowInsertTime = System.DateTime.Now;
                orderInDB.RowUpdateTime = System.DateTime.Now;
                entites.Orders.Add(orderInDB);
                entites.SaveChanges();
                return _mapper.Map<OrderDTO>(orderInDB);
            }
        }

        public List<OrderDTO> GetAllOrders()
        {
            using (var entities = new shoefactoryEntities())
            {
                var users = entities.Orders.ToList();
                return _mapper.Map<List<OrderDTO>>(users);
            }
        }
     
        public OrderDTO UpdateOrderByID(OrderDTO order, int id)
        {
            using (var entites = new shoefactoryEntities())
            {
                var orderInDB = _mapper.Map<Order>(order);
                orderInDB = entites.Orders.SingleOrDefault(x => x.OrderID == id);
                if (orderInDB != null)
                {
                    orderInDB.RowUpdateTime = DateTime.Now;
                    orderInDB.ShoeID = order.ShoeID;
                    orderInDB.UserID = order.UserID;
                    orderInDB.Quantity = order.Quantity;
                    orderInDB.Price = (decimal)order.Price;
                    entites.SaveChanges();
                }
                return _mapper.Map<OrderDTO>(orderInDB);
            }
        }

        public OrderDTO DeleteOrderByID(int id)
        {
            using (var entites = new shoefactoryEntities())
            {
                var orderInDB = entites.Orders.SingleOrDefault(x => x.OrderID == id);
                if (orderInDB != null)
                {
                    entites.Orders.Remove(orderInDB);
                    entites.SaveChanges();
                }
                return _mapper.Map<OrderDTO>(orderInDB);
            }
        }
    }
}
