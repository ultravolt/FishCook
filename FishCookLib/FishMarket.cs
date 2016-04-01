using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public class FishMarket : IMarket
    {
        public IResource[][] Inventory { get; set;}
        public override string ToString()
        {
            var sb = new StringBuilder();
            Inventory.ToList().ForEach(x => sb.AppendLine(String.Join("\t", x.Select(y => y.Value))));
            return sb.ToString();
       }
        public FishMarket()
        {
            this.Refill();
        }
        public void Refill()
        {
            Inventory = new FishResource[][]
            {
                new FishResource[] 
                {
                    new FishResource {Cost=10},
                    new FishResource {Cost=11},
                    new FishResource {Cost=13},
                    new FishResource {Cost=16},
                    new FishResource {Cost=20}
               },
                new FishResource[] 
                {
                    new FishResource {Cost=8},
                    new FishResource {Cost=9},
                    new FishResource {Cost=11},
                    new FishResource {Cost=13},
                    new FishResource {Cost=16}
               },
                new FishResource[] 
                {
                    new FishResource {Cost=6},
                    new FishResource {Cost=7},
                    new FishResource {Cost=8},
                    new FishResource {Cost=10},
                    new FishResource {Cost=12}
               },
                new FishResource[] 
                {
                    new FishResource {Cost=4},
                    new FishResource {Cost=5},
                    new FishResource {Cost=6},
                    new FishResource {Cost=7},
                    new FishResource {Cost=9}
               },
                new FishResource[] 
                {
                    new FishResource {Cost=2},
                    new FishResource {Cost=3},
                    new FishResource {Cost=4},
                    new FishResource {Cost=5},
                    new FishResource {Cost=7}
               },
                new FishResource[] 
                {
                    new FishResource {Cost=1},
                    new FishResource {Cost=2},
                    new FishResource {Cost=3},
                    new FishResource {Cost=4},
                    new FishResource {Cost=5}
               }
           };
            int l = Inventory[0].Length;

            var rolls = D6.Roll(12);
            //test
            //rolls = new List<int> { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6};
            var freq = new Dictionary<int, int> { { 6, 0}, { 5, 0}, { 4, 0}, { 3, 0}, { 2, 0}, { 1, 0}};
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
