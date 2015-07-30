using FishCookLib;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FishCook32
{

    partial class FishCook32Form
    {
        private ILog log;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            try
            {
                this.SuspendLayout();
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(784, 561);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);

                log = LogManager.GetLogger(this.GetType());
                log4net.Config.XmlConfigurator.Configure();
                log4net.NDC.Push(this.GetType().Assembly.FullName);
                RecipesConfigurationSection recipes = ConfigurationManager.GetSection("recipesConfiguration") as RecipesConfigurationSection;
                List<RecipeElement> recipeCards = recipes.Cards.Cast<RecipeElement>().ToList();

                if (Sprites == null)
                    Sprites = new SpriteCollection();

                if (Sprites.Count == 0)
                {

                    string[] images = null;
                    int horizontalOffset = 0;
                    int verticalOffset = 0;

                    images = new string[] { 
                    "./images/boards/FishMarket.png",
                    "./images/boards/IngredientMarket.png"
                    //"./images/cards/Assets_img_2.png"
                };

                    foreach (string i in images)
                    {
                        Sprite s = new Sprite(i, .10);                        
                        s.Y = verticalOffset;
                        verticalOffset += s.Height;
                        Sprites.Add(s);
                    }

                    images = new string[] { 
                    "./images/counters/b.png",
                    "./images/counters/g.png",
                    "./images/counters/p.png",
                    "./images/counters/r.png",
                    "./images/counters/w.png",
                    "./images/counters/y.png"                    
                };

                    foreach (string i in images)
                    {
                        Sprite s = new Sprite(i, .25 );                        
                        s.X = horizontalOffset;
                        horizontalOffset += s.Width;
                        Sprites.Add(s);
                    }


                }
                //Events.Run();
                //Video.Close();
            }
            catch (TypeInitializationException e)
            {
                log.Error(e.InnerException.Message, e);
            }
        }

        private new void Paint(object sender, PaintEventArgs e)
        {
            if (Sprites == null)
                return;

            Graphics g = e.Graphics;
            Sprites.ForEach(sprite =>
            {
                g.DrawImage(sprite.Surface, new Point { X = sprite.X, Y = sprite.Y });
            });
        }

        private new void KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        public List<Sprite> Sprites { get; set; }
    }
}

