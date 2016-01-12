using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrmDemo.Models
{
    public class Contact
    {
        public Contact()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact DOB is required")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Contact Phone is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number")]
        public string Phone { get; set; }
    }
}
