using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Interfaces
{
    public interface IExpirable
    {
        DateTime ExpirationDate { get; }
        bool IsExpired();

    }
}
