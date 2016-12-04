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
    public class ShawarmaRecipeRepository : IRepository<DalShawarmaRecipe>
    {

        private readonly DbContext Context;

        public ShawarmaRecipeRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalShawarmaRecipe> GetAll()
        {
            return Context.Set<ShawarmaRecipe>().Select(ShawarmaRecipe => new DalShawarmaRecipe()
            {
                Id = ShawarmaRecipe.ShawarmaRecipeID,
                Weght = ShawarmaRecipe.Weght,
                IngradientID = ShawarmaRecipe.IngradientID,
                ShawarmaID = ShawarmaRecipe.ShawarmaID
            });
        }

        public DalShawarmaRecipe GetById(int key)
        {
            var ormEntity = Context.Set<ShawarmaRecipe>().FirstOrDefault(ShawarmaRecipe => ShawarmaRecipe.ShawarmaRecipeID == key);
            return new DalShawarmaRecipe()
            {
                Id = ormEntity.ShawarmaRecipeID,
                Weght = ormEntity.Weght,
                IngradientID = ormEntity.IngradientID,
                ShawarmaID = ormEntity.ShawarmaID
            };
        }

        public DalShawarmaRecipe GetByPredicate(Expression<Func<DalShawarmaRecipe, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalShawarmaRecipe e)
        {
            var ShawarmaRecipe = new ShawarmaRecipe()
            {
                ShawarmaRecipeID = e.Id,
                Weght = e.Weght,
                IngradientID = e.IngradientID,
                ShawarmaID = e.ShawarmaID
            };
            Context.Set<ShawarmaRecipe>().Add(ShawarmaRecipe);
        }

        public void Delete(DalShawarmaRecipe e)
        {
            var ShawarmaRecipe = Context.Set<ShawarmaRecipe>().Single(i => i.ShawarmaRecipeID == e.Id);
            Context.Set<ShawarmaRecipe>().Remove(ShawarmaRecipe);
        }

        public void Update(DalShawarmaRecipe e)
        {
            var ShawarmaRecipe = new ShawarmaRecipe()
            {
                ShawarmaRecipeID = e.Id,
                Weght = e.Weght,
                IngradientID = e.IngradientID,
                ShawarmaID = e.ShawarmaID
            };

            ShawarmaRecipe = Context.Set<ShawarmaRecipe>().Single(i => i.ShawarmaRecipeID == e.Id);

            ShawarmaRecipe.Weght = e.Weght;
            ShawarmaRecipe.IngradientID = e.IngradientID;
            ShawarmaRecipe.ShawarmaID = e.ShawarmaID;
        }
    }
}
