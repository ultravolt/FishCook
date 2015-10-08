using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FishCookLib
{
    public class RecipesConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("recipes", IsDefaultCollection = true)]
        public RecipeElementCollection Cards
        {
            get { return (RecipeElementCollection)this["recipes"]; }
            set { this["recipes"] = value; }
        }
    } 
    [ConfigurationCollection(typeof(RecipeElement))]
    public class RecipeElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RecipeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RecipeElement)element).Title;
        }
    } 

    public class RecipeElement : ConfigurationElement
    {
        public override string ToString()
        {
            return String.Format("{0} {1}{2} {3}+{4}", this.Title, this.Fish,this.Ingredients, this.BaseValue, this.BonusValue);
        }

        [ConfigurationProperty("title", IsKey = true, IsRequired = true)]
        public string Title
        {
            get { return (string)this["title"]; }
            set { this["title"] = value; }
        }

        [ConfigurationProperty("src", IsRequired = true)]        
        public string Source
        {
            get { return (string)this["src"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("fish", IsRequired = false)]
        public byte Fish
        {
            get { return (byte)this["fish"]; }
            set { this["fish"] = value; }
        }
        [ConfigurationProperty("ingredients")]
        public String Ingredients {
            get { return this["ingredients"].ToString(); }
            set { this["ingredients"] = value; }
        }

        [ConfigurationProperty("base")]
        public byte BaseValue {
            get { return (byte)this["base"]; }
            set { this["base"] = value; }
        }

        [ConfigurationProperty("bonus")]
        public byte BonusValue
        {
            get { return (byte)this["bonus"]; }
            set { this["bonus"] = value; }
        }

        
      
    }      
    
}
