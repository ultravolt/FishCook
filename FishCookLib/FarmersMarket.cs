using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public class FarmersMarket : IMarket
    {
        public  IResource[][] Inventory { get; set; }

        private List<int> rolls = new List<int>();

        public FarmersMarket()
        {
            this.Inventory = new FarmedResource[][]
            {
                //Sake
                new FarmedResource[]
                {
                    new FarmedResource {Cost=12},
                    new FarmedResource {Cost=9, FillsOn=new byte[] {1, 2}},
                    new FarmedResource {Cost=7, FillsOn=new byte[] {3, 4}},
                    new FarmedResource {Cost=6, FillsOn=new byte[] {5}},
                    new FarmedResource {Cost=5, FillsOn=new byte[] {6}}
               },

                //Mushrooms
                new FarmedResource[]
                {
                    new FarmedResource {Cost=10},
                    new FarmedResource {Cost=7, FillsOn=new byte[] {1, 2}},
                    new FarmedResource {Cost=6, FillsOn=new byte[] {3}},
                    new FarmedResource {Cost=5, FillsOn=new byte[] {4, 5}},
                    new FarmedResource {Cost=4, FillsOn=new byte[] {6}}
               },

                //?
                new FarmedResource[]
                {
                    new FarmedResource {Cost=8},
                    new FarmedResource {Cost=6, FillsOn=new byte[] {1}},
                    new FarmedResource {Cost=5, FillsOn=new byte[] {2, 3}},
                    new FarmedResource {Cost=4, FillsOn=new byte[] {4, 5}},
                    new FarmedResource {Cost=3, FillsOn=new byte[] {6}}
               },

                //Roe (?) / Ginger (?)
                new FarmedResource[]
                {
                    new FarmedResource {Cost=7},
                    new FarmedResource {Cost=5, FillsOn=new byte[] {1}},
                    new FarmedResource {Cost=4, FillsOn=new byte[] {2, 3}},
                    new FarmedResource {Cost=3, FillsOn=new byte[] {4}},
                    new FarmedResource {Cost=2, FillsOn=new byte[] {5, 6}}
               },
                //Tamago (Egg)
                new FarmedResource[]
                {
                    new FarmedResource {Cost=5},
                    new FarmedResource {Cost=4, FillsOn=new byte[] {1}},
                    new FarmedResource {Cost=3, FillsOn=new byte[] {2}},
                    new FarmedResource {Cost=2, FillsOn=new byte[] {3, 4}},
                    new FarmedResource {Cost=1, FillsOn=new byte[] {5, 6}}
               },
                //Rice
                new FarmedResource[]
                {
                    new FarmedResource {Cost=4},
                    new FarmedResource {Cost=3},
                    new FarmedResource {Cost=2, FillsOn=new byte[] {1, 2}},
                    new FarmedResource {Cost=1, FillsOn=new byte[] {3, 4}},
                    new FarmedResource {Cost=0, FillsOn=new byte[] {5, 6}}
               }
             };
            this.Refill();

        }

        public void Refill()
        {
            rolls.Clear();
            foreach(var resourceArray in this.Inventory)
            {
                var d6 = (byte)Random.D6.Roll(1).FirstOrDefault();
                rolls.Add(d6);
                foreach (var resource in resourceArray.Cast<FarmedResource>())
                {
                    var lof = resource.FillsOn == null ? new byte[] { 0 } : resource.FillsOn;
                    var max = lof.Max();
                    var min = lof.Min();
                    resource.Value = min<=d6 && max <= d6 ? 1 : 0;
                    if (max == min && min == 0)
                        resource.Value = 1;
                }
            }

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Inventory.ToList().ForEach(x => sb.AppendLine(String.Join("\t", x.Select(y => y.Value))));
            return sb.ToString();
        }
    }
}
