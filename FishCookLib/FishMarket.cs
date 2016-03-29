using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public class FishMarket : Market
    {
        public new Resource[][] Inventory;
        public override string ToString()
        {
            var sb = new StringBuilder();
            Inventory.ToList().ForEach(x => sb.AppendLine(String.Join("\t", x.Select(y => y.Value))));
            return sb.ToString();
        }
        public void Refill()
        {
            Inventory = new Resource[][]{
                new Resource[] {new Resource {Cost=10}, new Resource {Cost=11 }, new Resource {Cost=13 }, new Resource {Cost=16 }, new Resource {Cost=20 } },
                new Resource[] {new Resource {Cost=8 }, new Resource {Cost=9 }, new Resource {Cost=11 }, new Resource {Cost=13 }, new Resource {Cost=16 } },
                new Resource[] {new Resource {Cost=6 }, new Resource {Cost=7 }, new Resource {Cost=8 }, new Resource {Cost=10 }, new Resource {Cost=12 } },
                new Resource[] {new Resource {Cost=4 }, new Resource {Cost=5 }, new Resource {Cost=6 }, new Resource {Cost=7 }, new Resource {Cost=9 } },
                new Resource[] {new Resource {Cost=2 }, new Resource {Cost=3 }, new Resource {Cost=4 }, new Resource {Cost=5 }, new Resource {Cost=7 } },
                new Resource[] {new Resource {Cost=1 }, new Resource {Cost=2 }, new Resource {Cost=3 }, new Resource {Cost=4 }, new Resource {Cost=5 } }
                };
            int l = Inventory[0].Length;

            var rolls = D6.Roll(12);
            //test
            //rolls = new List<int> { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 };
            var freq = new Dictionary<int, int> { { 6, 0 }, { 5, 0 }, { 4, 0 }, { 3, 0 }, { 2, 0 }, { 1, 0 } };
            rolls.Distinct().OrderByDescending(x => x).ToList().ForEach(x => freq[x] = rolls.Where(y => y == x).Count());
            while (freq.Values.Any(x => x > l))
            {
                var kvp = freq.FirstOrDefault(x => x.Value > l);
                var d = kvp.Value;
                var r = D6.Roll(1).FirstOrDefault();
                while (r == d)
                    r = D6.Roll(1).FirstOrDefault();
                freq[kvp.Key] = d - 1;
                freq[r]++;
            }

            for (int i = 0; i < Inventory.Length; i++)
            {
                //Invert the counter to get the correct die type
                var m = Inventory.Length - i;
                var match = freq[m];
                for (int j = 0; j < match; j++)
                {
                    this.Inventory[i][l - j - 1].Value = m;
                }

            }
            var a = this.ToString();
            Debug.WriteLine(a);

        }
    }
}
