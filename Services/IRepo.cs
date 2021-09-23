using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPIzzaOrderingApplication.Services
{
    public interface IRepo<K>
    {
        ICollection<K> GetOrderDetails();
        K GetOrderItemDetails(int orderId);
    }
}
