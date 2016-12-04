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
    public class OrderHeaderRepository : IRepository<DalOrderHeader>
    {

        private readonly DbContext Context;

        public OrderHeaderRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalOrderHeader> GetAll()
        {
            return Context.Set<OrderHeader>().Select(orderHeader => new DalOrderHeader()
            {
                Id = orderHeader.OrderHeaderID,
                OrderDate = orderHeader.OrderDate,
                SellerID = orderHeader.SellerID

            });
        }

        public DalOrderHeader GetById(int key)
        {
            var ormEntity = Context.Set<OrderHeader>().FirstOrDefault(orderHeader => orderHeader.OrderHeaderID == key);
            return new DalOrderHeader()
            {
                Id = ormEntity.OrderHeaderID,
                OrderDate = ormEntity.OrderDate,
                SellerID = ormEntity.SellerID
            };
        }

        public DalOrderHeader GetByPredicate(Expression<Func<DalOrderHeader, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalOrderHeader e)
        {
            var OrderHeader = new OrderHeader()
            {
                OrderHeaderID = e.Id,
                OrderDate = e.OrderDate,
                SellerID = e.SellerID
            };
            Context.Set<OrderHeader>().Add(OrderHeader);
        }

        public void Delete(DalOrderHeader e)
        {
            var OrderHeader = Context.Set<OrderHeader>().Single(i => i.OrderHeaderID == e.Id);
            Context.Set<OrderHeader>().Remove(OrderHeader);
        }

        public void Update(DalOrderHeader e)
        {
            var OrderHeader = new OrderHeader()
            {
                OrderHeaderID = e.Id,
                OrderDate = e.OrderDate,
                SellerID = e.SellerID
            };

            OrderHeader = Context.Set<OrderHeader>().Single(i => i.OrderHeaderID == e.Id);

            OrderHeader.OrderDate = e.OrderDate;
            OrderHeader.SellerID = e.SellerID;
        }
    }
}
