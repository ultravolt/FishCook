using System;
using System.Collections.Generic;
using System.Linq;

namespace FishCookLib
{
    public class RecipeCardDeck : Stack<RecipeCard>
    {

        public RecipeCardDeck()
        {
            this.Push(new RecipeCard
            {
                Source = "Assets_img_2",//.png
                Title = "Lotus-Wrapped Mystery Fish",
                Fish = 1,
                Ingredients = "r".ToCharArray(),
                BaseValue = 14,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_3",//.png
                Title = "Anchovy Soup with Pastry Ball",
                Fish = 1,
                Ingredients = "b".ToCharArray(),
                BaseValue = 16,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_4",//.png
                Title = "Knackered Smelt",
                Fish = 1,
                Ingredients = "p".ToCharArray(),
                BaseValue = 18,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_5",//.png
                Title = "Sardines with Lemon and Green Stuff",
                Fish = 1,
                Ingredients = "yg".ToCharArray(),
                BaseValue = 23,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_6",//.png
                Title = "Singing Smelt with Lemon",
                Fish = 1,
                Ingredients = "wyp".ToCharArray(),
                BaseValue = 32,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_7",//.png
                Title = "Pullayup Bento with Anchovies",
                Fish = 1,
                Ingredients = "rgb".ToCharArray(),
                BaseValue = 34,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_8",//.png
                Title = "Sweet Shrimps on a Rice Pancake",
                Fish = 2,
                Ingredients = "w".ToCharArray(),
                BaseValue = 13,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_9",//.png
                Title = "Crab Chowder with Ginger",
                Fish = 2,
                Ingredients = "r".ToCharArray(),
                BaseValue = 15,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_10",//.png
                Title = "Fat Prawns with Miso",
                Fish = 2,
                Ingredients = "wb".ToCharArray(),
                BaseValue = 24,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_11",//.png
                Title = "Hot Crustacean Plate",
                Fish = 2,
                Ingredients = "gp".ToCharArray(),
                BaseValue = 29,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_12",//.png
                Title = "Oakland Roll",
                Fish = 2,
                Ingredients = "wyg".ToCharArray(),
                BaseValue = 30,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_13",//.png
                Title = "Healthy Ginger Nabe",
                Fish = 2,
                Ingredients = "yrb".ToCharArray(),
                BaseValue = 33,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_14",//.png
                Title = "Tuna Nigiri",
                Fish = 3,
                Ingredients = "w".ToCharArray(),
                BaseValue = 15,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_15",//.png
                Title = "Three-Fish Soup",
                Fish = 3,
                Ingredients = "b".ToCharArray(),
                BaseValue = 19,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_16",//.png
                Title = "Bonito with Rice and Lemons",
                Fish = 3,
                Ingredients = "wy".ToCharArray(),
                BaseValue = 23,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_17",//.png
                Title = "Mackerel with Roe and Lemon",
                Fish = 3,
                Ingredients = "yr".ToCharArray(),
                BaseValue = 25,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_18",//.png
                Title = "Mackerel with Pickled Garlic",
                Fish = 3,
                Ingredients = "yrp".ToCharArray(),
                BaseValue = 37,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_19",//.png
                Title = "Fish Soup with Shredded Daikon",
                Fish = 3,
                Ingredients = "rgb".ToCharArray(),
                BaseValue = 37,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_20",//.png
                Title = "Stars of Squid Meat with Egg",
                Fish = 4,
                Ingredients = "y".ToCharArray(),
                BaseValue = 19,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_21",//.png
                Title = "Squiddies with Rice and Veggies",
                Fish = 4,
                Ingredients = "wg".ToCharArray(),
                BaseValue = 28,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_22",//.png
                Title = "Tentacle Segments with Cherry Branch",
                Fish = 4,
                Ingredients = "gp".ToCharArray(),
                BaseValue = 33,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_23",//.png
                Title = "Octopus Halves with Miso",
                Fish = 4,
                Ingredients = "wyb".ToCharArray(),
                BaseValue = 36,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_24",//.png
                Title = "Surprise Love Basket",
                Fish = 4,
                Ingredients = "wrp".ToCharArray(),
                BaseValue = 39,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_25",//.png
                Title = "Fried Octopus with 1000-Year Egg",
                Fish = 4,
                Ingredients = "ygp".ToCharArray(),
                BaseValue = 41,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_26",//.png
                Title = "Yellowtail Nigiri",
                Fish = 5,
                Ingredients = "w".ToCharArray(),
                BaseValue = 21,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_27",//.png
                Title = "Eel with Plastic Vegatable Garnish",
                Fish = 5,
                Ingredients = "wr".ToCharArray(),
                BaseValue = 29,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_28",//.png
                Title = "Teriyaki Trout with Head",
                Fish = 5,
                Ingredients = "yg".ToCharArray(),
                BaseValue = 31,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_29",//.png
                Title = "Grilled Samon, Sliced Up",
                Fish = 5,
                Ingredients = "rg".ToCharArray(),
                BaseValue = 32,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_30",//.png
                Title = "Troutfish with Ginger Sauce",
                Fish = 5,
                Ingredients = "yrp".ToCharArray(),
                BaseValue = 43,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_31",//.png
                Title = "Fish Soup with All the Fixin's",
                Fish = 5,
                Ingredients = "wbp".ToCharArray(),
                BaseValue = 44,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_32",//.png
                Title = "Shark Steak with Mushrooms",
                Fish = 6,
                Ingredients = "b".ToCharArray(),
                BaseValue = 28,
                Bonus = 3
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_33",//.png
                Title = "Abalone with Ginger",
                Fish = 6,
                Ingredients = "wr".ToCharArray(),
                BaseValue = 32,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_34",//.png
                Title = "Pan-Seared Rockfish",
                Fish = 6,
                Ingredients = "yg".ToCharArray(),
                BaseValue = 34,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_35",//.png
                Title = "Shark Fin Soup",
                Fish = 6,
                Ingredients = "gb".ToCharArray(),
                BaseValue = 37,
                Bonus = 4
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_36",//.png
                Title = "Marinated Swordfish Surprise",
                Fish = 6,
                Ingredients = "wrp".ToCharArray(),
                BaseValue = 45,
                Bonus = 5
           });
            this.Push(new RecipeCard
            {
                Source = "Assets_img_37",//.png
                Title = "Turtle Soup with Fancy Spoon",
                Fish = 6,
                Ingredients = "ygb".ToCharArray(),
                BaseValue = 45,
                Bonus = 5
           });
       }

        public List<RecipeCard> Deal(int count)
        {
            var rv = new List<RecipeCard>();
            for (int i=0; i< count; i++)
            {
                rv.Add(this.Pop());
           }
            return rv;
       }

        public bool AreShuffled { get; internal set;}

   }
    
}