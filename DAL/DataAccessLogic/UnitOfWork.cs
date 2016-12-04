using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface;

namespace DAL.DataAccessLogic
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Rollback() //experimental
        {
            Context.ChangeTracker.DetectChanges();

            var entries = Context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged).ToList();


            foreach (var dbEntityEntry in entries)
            {
                var entity = dbEntityEntry.Entity;

                if (entity == null) continue;

                switch (dbEntityEntry.State)
                {
                    case EntityState.Added:
                        var set = Context.Set(entity.GetType());
                        set.Remove(entity);
                        break;
                    case EntityState.Modified:
                        dbEntityEntry.Reload();
                        break;
                    case EntityState.Deleted:
                        dbEntityEntry.State = EntityState.Modified;
                        break;
                }
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
