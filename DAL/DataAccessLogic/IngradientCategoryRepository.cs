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
    public class IngradientCategoryCategoryRepository : IRepository<DalIngradientCategory>
    {

        private readonly DbContext Context;

        public IngradientCategoryCategoryRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalIngradientCategory> GetAll()
        {
            return Context.Set<IngradientCategory>().Select(ingradientCategory => new DalIngradientCategory()
            {
                Id = ingradientCategory.CategoryID,
                CategoryName = ingradientCategory.CategoryName

            });
        }

        public DalIngradientCategory GetById(int key)
        {
            var ormEntity = Context.Set<IngradientCategory>().FirstOrDefault(ingradientCategory => ingradientCategory.CategoryID == key);
            return new DalIngradientCategory()
            {
                Id = ormEntity.CategoryID,
                CategoryName = ormEntity.CategoryName
            };
        }

        public DalIngradientCategory GetByPredicate(Expression<Func<DalIngradientCategory, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalIngradientCategory e)
        {
            var ingradientCategory = new IngradientCategory()
            {
                CategoryID = e.Id,
                CategoryName = e.CategoryName
            };
            Context.Set<IngradientCategory>().Add(ingradientCategory);
        }

        public void Delete(DalIngradientCategory e)
        {
            var ingradientCategory = Context.Set<IngradientCategory>().Single(i => i.CategoryID == e.Id);
            Context.Set<IngradientCategory>().Remove(ingradientCategory);
        }

        public void Update(DalIngradientCategory e)
        {
            var ingradientCategory = new IngradientCategory()
            {
                CategoryID = e.Id,
                CategoryName = e.CategoryName
            };

            ingradientCategory = Context.Set<IngradientCategory>().Single(i => i.CategoryID == e.Id);

            ingradientCategory.CategoryName = e.CategoryName;
        }
    }
}
