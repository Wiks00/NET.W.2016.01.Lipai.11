using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interface;
using ORM;

namespace DAL.DataAccessLogic
{
    public class OrderDetailsRepository : IRepository<DalOrderDetails>
    {

        private readonly DbContext Context;

        public OrderDetailsRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalOrderDetails> GetAll()
        {
            return Context.Set<OrderDetails>().Select(orderDetails => new DalOrderDetails()
            {
                OrderHeaderID = orderDetails.OrderHeaderID,
                Quantity = orderDetails.Quantity,
                ShawarmaID = orderDetails.ShawarmaID,

            });
        }

        public DalOrderDetails GetById(int key)
        {
            var ormEntity = Context.Set<OrderDetails>().FirstOrDefault(orderDetails => orderDetails.OrderHeaderID == key);
            return new DalOrderDetails()
            {
                OrderHeaderID = ormEntity.OrderHeaderID,
                Quantity = ormEntity.Quantity,
                ShawarmaID = ormEntity.ShawarmaID

            };
        }

        public DalOrderDetails GetByPredicate(Expression<Func<DalOrderDetails, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalOrderDetails e)
        {
            var OrderDetails = new OrderDetails()
            {
                OrderHeaderID = e.OrderHeaderID,
                Quantity = e.Quantity,
                ShawarmaID = e.ShawarmaID
            };
            Context.Set<OrderDetails>().Add(OrderDetails);
        }

        public void Delete(DalOrderDetails e)
        {
            var OrderDetails = Context.Set<OrderDetails>().Single(i => i.OrderHeaderID == e.OrderHeaderID);
            Context.Set<OrderDetails>().Remove(OrderDetails);
        }

        public void Update(DalOrderDetails e)
        {
            var OrderDetails = new OrderDetails()
            {
                OrderHeaderID = e.OrderHeaderID,
                Quantity = e.Quantity,
                ShawarmaID = e.ShawarmaID
            };

            OrderDetails = Context.Set<OrderDetails>().Single(i => i.OrderHeaderID == e.OrderHeaderID);

            if (!ReferenceEquals(OrderDetails, null))
            {
                OrderDetails.OrderHeaderID = e.OrderHeaderID;
                OrderDetails.Quantity = e.Quantity;
                OrderDetails.ShawarmaID = e.ShawarmaID;

            }
            else
            {
                OrderDetails = Context.Set<OrderDetails>().Single(i => i.ShawarmaID == e.ShawarmaID);
                OrderDetails.OrderHeaderID = e.OrderHeaderID;
                OrderDetails.Quantity = e.Quantity;
                OrderDetails.ShawarmaID = e.ShawarmaID;
            }


            
        }
    }
}
