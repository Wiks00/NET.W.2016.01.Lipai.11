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
    public class IngradientRepository : IRepository<DalIngradient>
    {

        private readonly DbContext Context;

        public IngradientRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalIngradient> GetAll()
        {
            return Context.Set<Ingradient>().Select(ingradient => new DalIngradient()
            {
                Id = ingradient.IngradientID,
                IngradientName = ingradient.IngradientName,
                TotalWeght = ingradient.TotalWeght,
                CategoryID = ingradient.CategoryID

            });
        }

        public DalIngradient GetById(int key)
        {
            var ormEntity = Context.Set<Ingradient>().FirstOrDefault(ingradient => ingradient.IngradientID == key);
            return new DalIngradient()
            {
                Id = ormEntity.IngradientID,
                IngradientName = ormEntity.IngradientName,
                TotalWeght = ormEntity.TotalWeght,
                CategoryID = ormEntity.CategoryID
            };
        }

        public DalIngradient GetByPredicate(Expression<Func<DalIngradient, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalIngradient e)
        {
            var ingradient = new Ingradient()
            {
                IngradientID = e.Id,
                IngradientName = e.IngradientName,
                TotalWeght = e.TotalWeght,
                CategoryID = e.CategoryID
            };
            Context.Set<Ingradient>().Add(ingradient);
        }

        public void Delete(DalIngradient e)
        {
            var ingradient = Context.Set<Ingradient>().Single(i => i.IngradientID == e.Id);
            Context.Set<Ingradient>().Remove(ingradient);
        }

        public void Update(DalIngradient e)
        {
            var ingradient = new Ingradient()
            {
                IngradientID = e.Id,
                IngradientName = e.IngradientName,
                TotalWeght = e.TotalWeght,
                CategoryID = e.CategoryID
            };

            ingradient = Context.Set<Ingradient>().Single(i => i.IngradientID == e.Id);

            ingradient.IngradientName = e.IngradientName;
            ingradient.TotalWeght = e.TotalWeght;
            ingradient.CategoryID = e.CategoryID;
        }
    }
}
