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
    public class ShawarmaRepository : IRepository<DalShawarma>
    {

        private readonly DbContext Context;

        public ShawarmaRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalShawarma> GetAll()
        {
            return Context.Set<Shawarma>().Select(shawarma => new DalShawarma()
            {
                Id = shawarma.ShawarmaID,
                ShawarmaName = shawarma.ShawarmaName,
                CookingTime = shawarma.CookingTime
            });
        }

        public DalShawarma GetById(int key)
        {
            var ormEntity = Context.Set<Shawarma>().FirstOrDefault(Shawarma => Shawarma.ShawarmaID == key);
            return new DalShawarma()
            {
                Id = ormEntity.ShawarmaID,
                ShawarmaName = ormEntity.ShawarmaName,
                CookingTime = ormEntity.CookingTime
            };
        }

        public DalShawarma GetByPredicate(Expression<Func<DalShawarma, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalShawarma e)
        {
            var Shawarma = new Shawarma()
            {
                ShawarmaID = e.Id,
                ShawarmaName = e.ShawarmaName,
                CookingTime = e.CookingTime
            };
            Context.Set<Shawarma>().Add(Shawarma);
        }

        public void Delete(DalShawarma e)
        {
            var Shawarma = Context.Set<Shawarma>().Single(i => i.ShawarmaID == e.Id);
            Context.Set<Shawarma>().Remove(Shawarma);
        }

        public void Update(DalShawarma e)
        {
            var Shawarma = new Shawarma()
            {
                ShawarmaID = e.Id,
                ShawarmaName = e.ShawarmaName,
                CookingTime = e.CookingTime
            };

            Shawarma = Context.Set<Shawarma>().Single(i => i.ShawarmaID == e.Id);

            Shawarma.ShawarmaName = e.ShawarmaName;
            Shawarma.CookingTime = e.CookingTime;
        }
    }
}
