using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDAL
{
    public class Repository<TObject> where TObject : class
    {
        protected Context _context;

        /// <summary>
        /// By default, we are using just one DB so only one Context
        /// </summary>
        public Repository()
        {
            _context = new Context();
        }

        public IQueryable<TObject> GetAll()
        {
            return _context.Set<TObject>();
        }

        public TObject Find(int id)
        {
            return _context.Set<TObject>().Find(id);
        }

        public TObject FindSingleOrDefault(Expression<Func<TObject, bool>> match)
        {
            return _context.Set<TObject>().SingleOrDefault(match);
        }

        public IQueryable<TObject> Where(Expression<Func<TObject, bool>> match)
        {
            return _context.Set<TObject>().Where(match);
        }

        public TObject Save(TObject t)
        {
            _context.Set<TObject>().Add(t);
            _context.SaveChanges();
            return t;
        }

        public List<TObject> SaveMultiple(List<TObject> listT)
        {

            foreach (var t in listT)
            {
                _context.Set<TObject>().Add(t);
            }

            _context.SaveChanges();
            return listT;
        }

        public TObject Update(TObject updated, int key)
        {
            if (updated == null)
                return null;

            TObject existing = _context.Set<TObject>().Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.SaveChanges();
            }
            return existing;
        }

        public List<TObject> UpdateMultiple(List<TObject> listT)
        {
            if (listT == null)
                return null;

            foreach (var t in listT)
            {
                PropertyInfo propInfo = t.GetType().GetProperty("Id"); //this returns null
                object itemKey = propInfo.GetValue(t, null);
                TObject existing = _context.Set<TObject>().Find(itemKey);
                if (existing != null)
                {
                    _context.Entry(existing).CurrentValues.SetValues(t);
                }
            }
            _context.SaveChanges();

            return listT;
        }

        public TObject Update(TObject updated)
        {
            if (updated == null)
                return null;
            try
            {

                _context.Entry(updated).State = EntityState.Modified;
                _context.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return updated;
        }

        public void Delete(TObject t)
        {
            _context.Set<TObject>().Remove(t);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<TObject>().Count();
        }
    }
}
