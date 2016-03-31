using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public abstract class Market 
    {
        public abstract Resource[][] Inventory { get; set; }

        public abstract void Refill();

        public abstract override string ToString();

    }
}
