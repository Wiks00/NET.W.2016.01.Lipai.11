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
    public class SellingPointRepository : IRepository<DalSellingPoint>
    {

        private readonly DbContext Context;

        public SellingPointRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalSellingPoint> GetAll()
        {
            return Context.Set<SellingPoint>().Select(sellingPoint => new DalSellingPoint()
            {
                Id = sellingPoint.SellingPointID,
                Address = sellingPoint.Address,
                ShawarmaTitile = sellingPoint.ShawarmaTitile,
                SellingPointCategoryID = sellingPoint.SellingPointCategoryID
            });
        }

        public DalSellingPoint GetById(int key)
        {
            var ormEntity = Context.Set<SellingPoint>().FirstOrDefault(SellingPoint => SellingPoint.SellingPointID == key);
            return new DalSellingPoint()
            {
                Id = ormEntity.SellingPointID,
                Address = ormEntity.Address,
                ShawarmaTitile = ormEntity.ShawarmaTitile,
                SellingPointCategoryID = ormEntity.SellingPointCategoryID
            };
        }

        public DalSellingPoint GetByPredicate(Expression<Func<DalSellingPoint, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalSellingPoint e)
        {
            var SellingPoint = new SellingPoint()
            {
                SellingPointID = e.Id,
                Address = e.Address,
                ShawarmaTitile = e.ShawarmaTitile,
                SellingPointCategoryID = e.SellingPointCategoryID
            };
            Context.Set<SellingPoint>().Add(SellingPoint);
        }

        public void Delete(DalSellingPoint e)
        {
            var SellingPoint = Context.Set<SellingPoint>().Single(i => i.SellingPointID == e.Id);
            Context.Set<SellingPoint>().Remove(SellingPoint);
        }

        public void Update(DalSellingPoint e)
        {
            var SellingPoint = new SellingPoint()
            {
                SellingPointID = e.Id,
                Address = e.Address,
                ShawarmaTitile = e.ShawarmaTitile,
                SellingPointCategoryID = e.SellingPointCategoryID
            };

            SellingPoint = Context.Set<SellingPoint>().Single(i => i.SellingPointID == e.Id);

            SellingPoint.Address = e.Address;
            SellingPoint.ShawarmaTitile = e.ShawarmaTitile;
            SellingPoint.SellingPointCategoryID = e.SellingPointCategoryID;
        }
    }
}
