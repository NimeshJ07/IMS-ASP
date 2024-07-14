
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSAppliaction.Model
{
    [Table("Users")]
    [Index(nameof(Email),IsUnique =true)]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }    

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required] 
        [StringLength(50)]
        public string City { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }




    }
}
