using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public class PlayerCollection : List<Player>
    {

        public new void Add(Player player)
        {
            if (this.Count + 1 <= GameLogic.MaxPlayers)
                base.Add(player);
            else
                throw new MaximumPlayersException();
       }
   }
    public class Player
    {
        public const int StartingMoney = 100;
        public int Money { get; set;}
        public string Name { get; set;}
        
        public List<RecipeCard> RecipeCards { get; set;}
        public Player(string name=null)
        {
            this.Name = name;
            this.Money = StartingMoney;
            this.RecipeCards = new List<RecipeCard>();
       }
   }
}
