using System;
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

        public IEnumerable<Email> Emails { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }
    }
}
