using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSAppliaction.Model
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Orders Orders { get; set; }

        [ForeignKey("Orders"),Required]
        public int  OrderId {  get; set; }
        public virtual Products Products { get; set; }

        [ForeignKey("Products"),Required]
        public int ProductId { get; set; }
        public int ProductTotal { get; set; }
        public int ProductQty { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        
    }
}
