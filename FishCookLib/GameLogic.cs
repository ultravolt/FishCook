using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public class GameLogic
    {

        public List<Day> Days { get; set;}
        public const byte MinPlayers = 2;
        public const byte MaxPlayers = 6;
        public PlayerCollection Players { get; set;}
        public RecipeCardDeck Recipes { get; set;}

        public FishMarket FishMarket { get; set;}
        public FarmersMarket FarmersMarket { get; set;}

        public int NumberOfDaysByPlayers {
            get
            {
                switch (Players.Count)
                {
                    case MinPlayers:
                        return 3;
                    case 3:
                    case 4:
                        return 4;
                    case MaxPlayers:
                        return 5;
                    default:
                        return 0;
               }
           }

       }
        public GameLogic()
        {
            Initialize();

       }
        public GameLogic(byte numberOfPlayers)
        {
            Initialize();
            //this.NumberOfPlayers = numberOfPlayers;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                this.Players.Add(new Player());
           }

       }
        private void Initialize()
        {
            Players = new PlayerCollection();
            Recipes = new RecipeCardDeck();
            FarmersMarket = new FarmersMarket();
            FishMarket = new FishMarket();
            var shuff=Recipes.Shuffle().ToList();
            Recipes.Clear();
            shuff.ForEach(x => Recipes.Push(x));
            Recipes.AreShuffled = true;
       }
   }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");            
            return source.ShuffleIterator();
       }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = Random.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
           }
       }
   }
}
