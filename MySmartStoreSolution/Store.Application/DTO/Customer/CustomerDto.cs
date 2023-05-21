using Store.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTO.Customer
{
    public class CustomerDto
    {
        
        public Int64? Id { get; set; }
        
        [Required]
        public Int64 UserId { get; set; }
    }
}
