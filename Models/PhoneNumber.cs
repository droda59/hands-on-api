using System.ComponentModel.DataAnnotations;

namespace HandsOnApi.Models
{
    public class PhoneNumber
    {
        public string Type { get; set; }

        public string Country { get; set; }

        [Phone]
        public string Number { get; set; }
    }
}
