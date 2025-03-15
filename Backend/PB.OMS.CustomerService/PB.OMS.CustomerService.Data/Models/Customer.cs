using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.CustomerService.Data
{
    public class Customer
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public int Floor { get; set; }
        public required string DisplayName { get; set; }
        public required string PhoneNumber {  get; set; }
        public required string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy {  get; set; }

    }
}
