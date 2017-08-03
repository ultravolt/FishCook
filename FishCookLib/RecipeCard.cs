using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public class RecipeCard : Card
    {
        public short Bonus { get; internal set; }
        public short Fish { get; internal set; }
        public char[] Ingredients { get; internal set; }
        public string Source { get; internal set; }
        public string Title { get; internal set; }
        public short BaseValue { get; internal set; }

        public override string ToString()
        {
            return this.Title;
        }

    }
}
