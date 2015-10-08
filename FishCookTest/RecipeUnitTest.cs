using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FishCookLib;
using System.Configuration;

namespace FishCookTest
{
    [TestClass]
    public class RecipeUnitTest
    {
        private byte ExpectedSingleFishRecipes=3;

        [TestMethod]
        public void RecipeTestMethod()
        {
            RecipesConfigurationSection recipes = ConfigurationManager.GetSection("recipesConfiguration") as RecipesConfigurationSection;
            List<RecipeElement> recipeCards = recipes.Cards.Cast<RecipeElement>().ToList();
            List<char> allIngredients = new List<char>();
            recipeCards.ForEach(x => x.Ingredients.ToCharArray().ToList().ForEach(y => allIngredients.Add(y)));
            allIngredients = allIngredients.Distinct().ToList();
            allIngredients.Sort();

            List<RecipeElement> oneIngedientsOneFish = recipeCards.Where(x => x.Fish == 6 && x.Ingredients.ToCharArray().Length == 1).ToList();

            List<RecipeElement> oneFishTwoIngedients = recipeCards.Where(x => x.Fish == 1 && x.Ingredients.ToCharArray().Length == 2).ToList();
            List<RecipeElement> oneFishThreeIngedients = recipeCards.Where(x => x.Fish == 1 && x.Ingredients.ToCharArray().Length == 1).ToList();

            Assert.AreEqual(recipeCards.Where(x => x.Fish == 1 && x.Ingredients.ToCharArray().Length==1).Count(), this.ExpectedSingleFishRecipes);

        }
    }
}
