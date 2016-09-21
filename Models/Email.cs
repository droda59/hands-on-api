using System.ComponentModel.DataAnnotations;

namespace HandsOnApi.Models
{
    public class Email
    {
        public string Type { get; set; }

        [EmailAddress]
        public string Address { get; set; }
    }
}
