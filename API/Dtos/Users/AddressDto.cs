using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Users
{
    public class AddressDto
    {        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public String Street { get; set; }
        
        public String City { get; set; }
        
        public string State { get; set; }
        
        public string ZipCode { get; set; }
        
    }
}
