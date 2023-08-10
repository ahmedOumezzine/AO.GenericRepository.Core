using System.Linq.Expressions;

namespace AO.GenericRepository.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        List<T> GetAll();
        Task<List<T>> GetAllAsync();

        IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);
         List<T> FindAll(Func<T, bool> match);
         T Find(Expression<Func<T, bool>> match);
         Task<T> FindAsync(Expression<Func<T, bool>> match);

         void Add(T obj);
         void AddAndSave(T obj);
         void AddRange(IEnumerable<T> obj);
         void AddRangeAndSave(IEnumerable<T> obj);
         void Update(T obj);
        void UpdateAndSave(T obj);
        void Delete(T id);
         void DeleteAndSave(T id);
         void DeleteRange(IEnumerable<T> id);
         void DeleteRangeAndSave(IEnumerable<T> id);
         void Save();

        int Count();
        int Count(Expression<Func<T, bool>> match);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> match);
    }
}