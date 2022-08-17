using Core.Entities;


namespace Core.Specifications
{
    public class EmployeeWithCountrySpecification : BaseSpecification<Employee>
    {
        public EmployeeWithCountrySpecification()
        {
            AddInclude(x => x.Country);
        }

        public EmployeeWithCountrySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Country);
        }
    }        
}
