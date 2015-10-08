using System;
using System.Linq;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Input;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Sprites;
using System.IO;
using log4net;
using log4net.Config;
using System.Configuration;
using System.Collections.Generic;
using FishCookLib;


namespace FishCook
{
    public class SDLApplication : IDisposable
    {

        private Surface surface;

        private static Random rand = new Random();

        private Surface screen;

        public static Random Randomizer
        {
            get { return SDLApplication.rand; }
            set { SDLApplication.rand = value; }
        }


        public virtual Surface RenderSurface()
        {
            Sprites.Cast<Sprite>().ToList().ForEach(x => surface.Blit(x.Surface, x.Rectangle));
            return surface;
        }


        #region IDisposable Members

        private bool disposed;
        private ILog log;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.surface != null)
                    {
                        this.surface.Dispose();
                        this.surface = null;
                    }
                    foreach (Sprite s in this.Sprites)
                    {
                        if (s != null)
                        {
                            this.Sprites.Remove(s);
                            s.Dispose();
                        }
                    }
                }
                this.disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        public void Close()
        {
            Dispose();
        }

        ~SDLApplication()
        {
            Dispose(false);
        }

        #endregion

        public void Initialize(int width, int height)
        {
            log = LogManager.GetLogger(this.GetType());
            log4net.Config.XmlConfigurator.Configure();
            log4net.NDC.Push(this.GetType().Assembly.FullName);
            RecipesConfigurationSection recipes = ConfigurationManager.GetSection("recipesConfiguration") as RecipesConfigurationSection;
            List<RecipeElement> recipeCards = recipes.Cards.Cast<RecipeElement>().ToList();
            
            
            try
            {
                this.Height = height;
                this.Width = width;
                Video.Initialize();
                Video.WindowIcon();
                var caption = "SDL.NET - Sprite Demos";
                Video.WindowCaption = caption;
                Video.Close();
                log.Info(caption + " Started");
                screen = Video.SetVideoMode(Width, Height);
                
                Events.Fps = 100;
                Events.KeyboardDown += new EventHandler<KeyboardEventArgs>(this.KeyboardDown);
                Events.Tick += new EventHandler<TickEventArgs>(this.Tick);
                Events.Quit += new EventHandler<QuitEventArgs>(this.Quit);
                if (surface == null)
                    surface = new Surface(this.Width, this.Height);
                surface.Fill(Color.Black);
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
                        Sprite s = new Sprite(i);
                        s.Surface = s.Surface.CreateScaledSurface(.10, true);
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
                        Sprite s = new Sprite(i);
                        s.Surface = s.Surface.CreateScaledSurface(.25, true);
                        s.X = horizontalOffset;
                        horizontalOffset += s.Width;
                        Sprites.Add(s);
                    }





                }
                Events.Run();
                Video.Close();
            }
            catch (TypeInitializationException e)
            {
                log.Error(e.InnerException.Message, e);
            }
        }


        #region Events

        private void KeyboardDown(object sender, KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                case Key.Q:
                    Events.QuitApplication();
                    break;
                /*
                case Key.C:
                    break;
                case Key.One:
                    SwitchDemo(0);
                    break;
                case Key.Two:
                    SwitchDemo(1);
                    break;
                case Key.Three:
                    SwitchDemo(2);
                    break;
                case Key.Four:
                    SwitchDemo(3);
                    break;
                case Key.Five:
                    SwitchDemo(4);
                    break;
                case Key.M:
                    Video.IconifyWindow();
                    break;
                 */
            }
        }


        private void Tick(object sender, TickEventArgs args)
        {
            screen.Blit(this.RenderSurface());
            screen.Update();
        }

        private void Quit(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }

        #endregion


        public void Dispose()
        {
            if (!this.disposed)
            {
                if (this.surface != null)
                {
                    this.surface.Dispose();
                    this.surface = null;
                }
                try
                {
                    foreach (Sprite s in this.Sprites)
                    {
                        if (s != null)
                        {
                            this.Sprites.Remove(s);
                            s.Dispose();
                        }
                    }

                }
                catch { }
                this.disposed = true;
                //log.Info("Complete");
            }

        }


        public SpriteCollection Sprites { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
    }



}
