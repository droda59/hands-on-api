using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HandsOnApi.Models
{
    public class Employee : Document
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
