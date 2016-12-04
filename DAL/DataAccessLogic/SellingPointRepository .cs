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
    public class SellingPointCategoryRepository : IRepository<DalSellingPointCategory>
    {

        private readonly DbContext Context;

        public SellingPointCategoryRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalSellingPointCategory> GetAll()
        {
            return Context.Set<SellingPointCategory>().Select(SellingPointCategory => new DalSellingPointCategory()
            {
                Id = SellingPointCategory.SellingPointCategoryID,
                SellingPointCategoryName = SellingPointCategory.SellingPointCategoryName
            });
        }

        public DalSellingPointCategory GetById(int key)
        {
            var ormEntity = Context.Set<SellingPointCategory>().FirstOrDefault(SellingPointCategory => SellingPointCategory.SellingPointCategoryID == key);
            return new DalSellingPointCategory()
            {
                Id = ormEntity.SellingPointCategoryID,
                SellingPointCategoryName = ormEntity.SellingPointCategoryName
            };
        }

        public DalSellingPointCategory GetByPredicate(Expression<Func<DalSellingPointCategory, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalSellingPointCategory e)
        {
            var SellingPointCategory = new SellingPointCategory()
            {
                SellingPointCategoryID = e.Id,
                SellingPointCategoryName = e.SellingPointCategoryName
            };
            Context.Set<SellingPointCategory>().Add(SellingPointCategory);
        }

        public void Delete(DalSellingPointCategory e)
        {
            var SellingPointCategory = Context.Set<SellingPointCategory>().Single(i => i.SellingPointCategoryID == e.Id);
            Context.Set<SellingPointCategory>().Remove(SellingPointCategory);
        }

        public void Update(DalSellingPointCategory e)
        {
            var SellingPointCategory = new SellingPointCategory()
            {
                SellingPointCategoryID = e.Id,
                SellingPointCategoryName = e.SellingPointCategoryName
            };

            SellingPointCategory = Context.Set<SellingPointCategory>().Single(i => i.SellingPointCategoryID == e.Id);

            SellingPointCategory.SellingPointCategoryName = e.SellingPointCategoryName;
        }
    }
}
