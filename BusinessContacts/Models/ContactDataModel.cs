using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessContacts.Models
{
    public class ContactDataModel
    {
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please enter Company name."), MaxLength(30)]
        public string CompanyName { get; set; }

        [Display(Name = "Tax Number")]
        [Required(ErrorMessage = "Please enter Bussiness Tax Number."), MaxLength(11)]
        public string BussinessTaxNumber { get; set; }

        [Required(ErrorMessage = "Please enter City."), MaxLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Address."), MaxLength(50)]
        public string Address { get; set; }

        [Display(Name = "Contact Person"), MaxLength(40)]
        public string ContactPerson { get; set; }

        [Display(Name = "Mobile Phone"), MaxLength(30)]
        public string MobilePhone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}

