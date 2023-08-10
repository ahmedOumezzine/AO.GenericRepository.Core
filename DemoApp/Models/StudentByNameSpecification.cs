using AO.GenericRepository.Core.Specification;

namespace DemoApp.Models
{
    public class StudentByNameSpecification : BaseSpecifcation<Student>
    {
        public StudentByNameSpecification(string Name) : base(x => x.Name == nameof)
        {
            AddOrderBy(x => x.Name);
        }
    }
}