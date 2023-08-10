using AO.GenericRepository.Core.Specification;

namespace DemoApp.Models
{
    public class StudentByNameSpecification : BaseSpecifcation<Student>
    {
        public StudentByNameSpecification(string Name) : base(x => x.Name == Name)
        {
            AddOrderBy(x => x.Name);
        }
    }
}