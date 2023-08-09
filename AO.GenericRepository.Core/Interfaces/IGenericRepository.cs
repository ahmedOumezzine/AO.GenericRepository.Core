using System.Linq.Expressions;

namespace AO.GenericRepository.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);
        public List<T> FindAllAsync(Func<T, bool> match);

        public void Add(T obj);
        public void AddAndSave(T obj);
        public void AddRange(IEnumerable<T> obj);
        public void AddRangeAndSave(IEnumerable<T> obj);
        public void Update(T obj);
        public void UpdateAndSave(T obj);
        public void Delete(T id);
        public void DeleteAndSave(T id);
        public void DeleteRange(IEnumerable<T> id);
        public void DeleteRangeAndSave(IEnumerable<T> id);
        public void Save();

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> match);
    }
}