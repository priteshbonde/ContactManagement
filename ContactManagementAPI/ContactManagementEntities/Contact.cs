using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContactManagementEntities
{
    public class Contact
    {
        public long ContactID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public bool Status { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
