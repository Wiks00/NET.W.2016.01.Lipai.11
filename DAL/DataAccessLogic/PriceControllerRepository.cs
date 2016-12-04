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
    public class PriceControllerRepository : IRepository<DalPriceController>
    {

        private readonly DbContext Context;

        public PriceControllerRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalPriceController> GetAll()
        {
            return Context.Set<PriceController>().Select(priceController => new DalPriceController()
            {
                Id = priceController.PriceControllerID,
                Price = priceController.Price,
                Comment = priceController.Comment,
                ShawarmaID = priceController.ShawarmaID,
                SellingPointID = priceController.SellingPointID

            });
        }

        public DalPriceController GetById(int key)
        {
            var ormEntity = Context.Set<PriceController>().FirstOrDefault(PriceController => PriceController.PriceControllerID == key);
            return new DalPriceController()
            {
                Id = ormEntity.PriceControllerID,
                Price = ormEntity.Price,
                Comment = ormEntity.Comment,
                ShawarmaID = ormEntity.ShawarmaID,
                SellingPointID = ormEntity.SellingPointID
            };
        }

        public DalPriceController GetByPredicate(Expression<Func<DalPriceController, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalPriceController e)
        {
            var PriceController = new PriceController()
            {
                PriceControllerID = e.Id,
                Price = e.Price,
                Comment = e.Comment,
                ShawarmaID = e.ShawarmaID,
                SellingPointID = e.SellingPointID
            };
            Context.Set<PriceController>().Add(PriceController);
        }

        public void Delete(DalPriceController e)
        {
            var PriceController = Context.Set<PriceController>().Single(i => i.PriceControllerID == e.Id);
            Context.Set<PriceController>().Remove(PriceController);
        }

        public void Update(DalPriceController e)
        {
            var PriceController = new PriceController()
            {
                PriceControllerID = e.Id,
                Price = e.Price,
                Comment = e.Comment,
                ShawarmaID = e.ShawarmaID,
                SellingPointID = e.SellingPointID
            };

            PriceController = Context.Set<PriceController>().Single(i => i.PriceControllerID == e.Id);

            PriceController.Price = e.Price;
            PriceController.Comment = e.Comment;
            PriceController.ShawarmaID = e.ShawarmaID;
            PriceController.SellingPointID = e.SellingPointID;
        }
    }
}
