using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApplication.DTO
{
    public class UserDto
    {
        public record CreateUserDto(

            [Required]
            [StringLength(50)]
            string FullName,

            [Required]
            [StringLength(50)]
            string Email,

            [Required]
            [StringLength(50)]
            string City,
            DateTime CreatedAt,
            
            DateTime UpdatedAt
        );

    }
}
