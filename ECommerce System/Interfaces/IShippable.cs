using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Interfaces
{
    public interface IShippable
    {
        string Name { get; }
        double Weight { get; }

    }
}
