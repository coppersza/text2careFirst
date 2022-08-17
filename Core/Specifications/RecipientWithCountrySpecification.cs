using Core.Entities;

namespace Core.Specifications
{

    public class RecipientWithCountrySpecification : BaseSpecification<Recipient>
    {
        public RecipientWithCountrySpecification()
        {
            AddInclude(x => x.Country);
        }

        public RecipientWithCountrySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Country);
        }
    }    
}
