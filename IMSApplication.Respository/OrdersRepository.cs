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
    public class OrdersRepository : Repository<Orders>, IOrdersRepository
    {
        public OrdersRepository(IMSDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
