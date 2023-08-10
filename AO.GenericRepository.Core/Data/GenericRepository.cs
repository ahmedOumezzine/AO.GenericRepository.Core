using AO.GenericRepository.Core.Contexts;
using AO.GenericRepository.Core.Interfaces;
using AO.GenericRepository.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DbContext = AO.GenericRepository.Core.Contexts.DbContext;

namespace AO.GenericRepository.Core.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context = null)
        {
            _context = context;
        }

        public IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }

        public List<T> FindAll(Func<T, bool> match)
        {
            return  _context.Set<T>().Where(match).ToList();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(match);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Add(T obj)
        {
            _context.Add(obj); 
        }  
        
        public void AddAndSave(T obj)
        {
            Add(obj);
            Save();
        }
        public void AddRange(IEnumerable<T> obj)
        {
            _context.AddRange(obj);

        }     
        public void AddRangeAndSave(IEnumerable<T> obj)
        {
            AddRange(obj);
            Save();

        }
        public void Update(T obj)
        {
            _context.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }    
        public void UpdateAndSave(T obj)
        {
            Update(obj);
            Save();
        }

        public void Delete(T existing)
        {
            _context.Remove(existing);
        } 

        public void DeleteAndSave(T existing)
        {
            Delete(existing);
            Save();
        } 
        public void DeleteRange(IEnumerable<T> existing)
        {
            _context.RemoveRange(existing);

        }  
        
        public void DeleteRangeAndSave(IEnumerable<T> existing)
        {
            DeleteRange(existing);
            Save();

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
        public int Count()
        {
            return  _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> match)
        {
            return  _context.Set<T>().Where(match).Count();
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).CountAsync();
        }
    }
}