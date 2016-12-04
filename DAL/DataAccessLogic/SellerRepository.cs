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
    public class SellerRepository : IRepository<DalSeller>
    {

        private readonly DbContext Context;

        public SellerRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalSeller> GetAll()
        {
            return Context.Set<Seller>().Select(seller => new DalSeller()
            {
                Id = seller.SellerID,
                SellerName = seller.SellerName,
                SellingPointID = seller.SellingPointID
            });
        }

        public DalSeller GetById(int key)
        {
            var ormEntity = Context.Set<Seller>().FirstOrDefault(Seller => Seller.SellerID == key);
            return new DalSeller()
            {
                Id = ormEntity.SellerID,
                SellerName = ormEntity.SellerName,
                SellingPointID = ormEntity.SellingPointID
            };
        }

        public DalSeller GetByPredicate(Expression<Func<DalSeller, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalSeller e)
        {
            var Seller = new Seller()
            {
                SellerID = e.Id,
                SellerName = e.SellerName,
                SellingPointID = e.SellingPointID
            };
            Context.Set<Seller>().Add(Seller);
        }

        public void Delete(DalSeller e)
        {
            var Seller = Context.Set<Seller>().Single(i => i.SellerID == e.Id);
            Context.Set<Seller>().Remove(Seller);
        }

        public void Update(DalSeller e)
        {
            var Seller = new Seller()
            {
                SellerID = e.Id,
                SellerName = e.SellerName,
                SellingPointID = e.SellingPointID
            };

            Seller = Context.Set<Seller>().Single(i => i.SellerID == e.Id);

            Seller.SellerName = e.SellerName;
            Seller.SellingPointID = e.SellingPointID;
        }
    }
}
