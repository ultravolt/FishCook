using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public class FarmersMarket : Market
    {
        public override Resource[][] Inventory { get; set; }

      

        public FarmersMarket()
        {
            this.Refill();

        }

        public override void Refill()
        {
            this.Inventory = new Resource[][]
            {
                new Resource[]
                {
                    new Resource {Cost=12 },
                    new Resource {Cost=9 },
                    new Resource {Cost=7 },
                    new Resource {Cost=6 },
                    new Resource {Cost=5 }
                },
                new Resource[]
                {
                    new Resource {Cost=10 },
                    new Resource {Cost=7 },
                    new Resource {Cost=6 },
                    new Resource {Cost=5 },
                    new Resource {Cost=4 }
                },
                new Resource[]
                {
                    new Resource {Cost=8 },
                    new Resource {Cost=6 },
                    new Resource {Cost=5 },
                    new Resource {Cost=4 },
                    new Resource {Cost=3 }
                },
                new Resource[]
                {
                    new Resource {Cost=7 },
                    new Resource {Cost=5 },
                    new Resource {Cost=4 },
                    new Resource {Cost=3 },
                    new Resource {Cost=2 }
                },
                new Resource[]
                {
                    new Resource {Cost=5 },
                    new Resource {Cost=4 },
                    new Resource {Cost=3 },
                    new Resource {Cost=2 },
                    new Resource {Cost=1 }
                },
                new Resource[]
                {
                    new Resource {Cost=4 },
                    new Resource {Cost=3 },
                    new Resource {Cost=2 },
                    new Resource {Cost=1 },
                    new Resource {Cost=0 }
                }
            };

        }

        public override string ToString()
        {
            return this.GetType().FullName;
        }
    }
}
