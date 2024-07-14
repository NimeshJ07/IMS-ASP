using IMSApllication.Data;
using IMSApllication.Respository;
using IMSAppliaction.Model;
using IMSApplication.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApplication.Respository
{
    public class OrderDetailsRepository : Repository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(IMSDbContext dbcontext) : base(dbcontext)
        {
                
        }
    }
}
