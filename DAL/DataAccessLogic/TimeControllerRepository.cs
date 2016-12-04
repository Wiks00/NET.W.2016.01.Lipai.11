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
    public class TimeControllerRepository : IRepository<DalTimeController>
    {

        private readonly DbContext Context;

        public TimeControllerRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalTimeController> GetAll()
        {
            return Context.Set<TimeController>().Select(TimeController => new DalTimeController()
            {
                Id = TimeController.TimeControllerID,
                WorkStart = TimeController.WorkStart,
                WorkEnd = TimeController.WorkEnd,
                SellerID = TimeController.SellerID
            });
        }

        public DalTimeController GetById(int key)
        {
            var ormEntity = Context.Set<TimeController>().FirstOrDefault(TimeController => TimeController.TimeControllerID == key);
            return new DalTimeController()
            {
                Id = ormEntity.TimeControllerID,
                WorkStart = ormEntity.WorkStart,
                WorkEnd = ormEntity.WorkEnd,
                SellerID = ormEntity.SellerID
            };
        }

        public DalTimeController GetByPredicate(Expression<Func<DalTimeController, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalTimeController e)
        {
            var TimeController = new TimeController()
            {
                TimeControllerID = e.Id,
                WorkStart = e.WorkStart,
                WorkEnd = e.WorkEnd,
                SellerID = e.SellerID
            };
            Context.Set<TimeController>().Add(TimeController);
        }

        public void Delete(DalTimeController e)
        {
            var TimeController = Context.Set<TimeController>().Single(i => i.TimeControllerID == e.Id);
            Context.Set<TimeController>().Remove(TimeController);
        }

        public void Update(DalTimeController e)
        {
            var TimeController = new TimeController()
            {
                TimeControllerID = e.Id,
                WorkStart = e.WorkStart,
                WorkEnd = e.WorkEnd,
                SellerID = e.SellerID
            };

            TimeController = Context.Set<TimeController>().Single(i => i.TimeControllerID == e.Id);

            TimeController.WorkStart = e.WorkStart;
            TimeController.WorkEnd = e.WorkEnd;
            TimeController.SellerID = e.SellerID;
        }
    }
}
