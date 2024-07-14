using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSAppliaction.Model
{
    [Table("Orders")]
    [Index(nameof(OrderNumber),IsUnique = true)]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? OrderNumber { get; set; }
        public int OrderTotal { get; set; }

        public DateTime CretedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        
    }
}
