using Core.Entities;

namespace Core.Specifications
{
    public class DonatorWithCountrySpecification : BaseSpecification<Donator>
    {
        public DonatorWithCountrySpecification()
        {
            Includes.Add(x => x.Country);
        }

        public DonatorWithCountrySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Country);
        }
    }          
}
