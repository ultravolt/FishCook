using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FishCookLib;
using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace FishCook
{
  
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Dictionary<int, Texture2D> RecipeCardTextureLookup { get; private set; }
        public GameLogic GameLogic { get; private set; }
        public RecipeCardDeck RecipeDeck { get { return this.GameLogic.Recipes; } set { this.GameLogic.Recipes = value; } }

        public SpriteFont Emulogic { get; private set; }
        public Texture2D FishMarketTexture { get; private set; }
        public Texture2D BlankDieTexture { get; private set; }
        public Texture2D GreyDieTexture { get; private set; }

        public Dictionary<int, Texture2D> DieFaces { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.GameLogic = new FishCookLib.GameLogic();
            try
            {
                this.RecipeDeck = this.GameLogic.Recipes;
                //Deck<RecipeCard> deck = new Deck<RecipeCard>(this.GameLogic.Recipes);
                if (this.GameLogic.Recipes.AreShuffled)
                {
                    //deck.Pop(2)
                    GameLogic.Players.Add(new Player { Name = "Alex", RecipeCards = RecipeDeck.Deal(2) });
                    GameLogic.Players.Add(new Player { Name = "Gloria", RecipeCards = RecipeDeck.Deal(2) });
                    GameLogic.Players.Add(new Player { Name = "Mike", RecipeCards = RecipeDeck.Deal(2) });
                    GameLogic.Players.Add(new Player { Name = "Brent", RecipeCards = RecipeDeck.Deal(2) });
                    GameLogic.Players.Add(new Player { Name = "Halina", RecipeCards = RecipeDeck.Deal(2) });
                    GameLogic.Players.Add(new Player { Name = "Dave", RecipeCards = RecipeDeck.Deal(2) });
                    //this.GameLogic.Players.Add(new Player { Name = "Roosevelt", RecipeCards = RecipeDeck.Deal(2) });
                }
                GameLogic.FishMarket.Refill();   
            }
            catch (MaximumPlayersException exception)
            {

            }
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            var x = nameof(Emulogic);
            this.Emulogic = Content.Load<SpriteFont>(x);
            var rcc = new FishCookLib.RecipeCardDeck();
            this.RecipeCardTextureLookup = new Dictionary<int, Texture2D>();
            rcc.Select(recipeCard => recipeCard.Source).ToList().ForEach(source =>
            {

                var a = rcc.FirstOrDefault(y => y.Source == source);
                var b = Content.Load<Texture2D>(source);
                this.RecipeCardTextureLookup.Add(a.GetHashCode(), b);

            }
            );
            this.FishMarketTexture = Content.Load<Texture2D>(nameof(FishMarketTexture));
            this.BlankDieTexture = Content.Load<Texture2D>(nameof(BlankDieTexture));
            this.GreyDieTexture = Content.Load<Texture2D>(nameof(GreyDieTexture));

            this.DieFaces = new Dictionary<int, Texture2D>();
            DieFaces.Add(1, Content.Load<Texture2D>("One"));
            DieFaces.Add(2, Content.Load<Texture2D>("Two"));
            DieFaces.Add(3, Content.Load<Texture2D>("Three"));
            DieFaces.Add(4, Content.Load<Texture2D>("Four"));
            DieFaces.Add(5, Content.Load<Texture2D>("Five"));
            DieFaces.Add(6, Content.Load<Texture2D>("Six"));


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                this.GameLogic.FishMarket.Refill();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            var texture = this.FishMarketTexture;//.RecipeCardTextureLookup.FirstOrDefault().Value;
            Vector2? position = null;// new Vector2 { X = 0, Y = 0 };
            var scale = 1.0;
            //
            
            Rectangle? sourceRectangle = null;

            Color? color = null;
            //     A color mask.
            //
            float rotation = 0f;
            //     A rotation of this sprite.
            //
            Vector2? origin = null;
            //     Center of the rotation. 0,0 by default.
            //
            Vector2? scaleV = new Vector2 { X =(float)(texture.Height * scale), Y = (float)(texture.Width * scale) };
            //     A scaling of this sprite.
            //
            Rectangle? destinationRectangle = new Rectangle { X = 0, Y = 0, Height=(int)scaleV.Value.X, Width=(int)scaleV.Value.Y };
            SpriteEffects effects = SpriteEffects.None;
            //     Modificators for drawing. Can be combined.
            //
            var layerDepth = 0f;
            //     A depth of the layer of this sprite.
            spriteBatch.Draw(texture, position, destinationRectangle, sourceRectangle, origin, rotation, scaleV, color,  effects, layerDepth);
            //spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            //spriteBatch.DrawString(Emulogic, "Score: 0", new Vector2(100, 100), Color.Black);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var res=this.GameLogic.FishMarket.Inventory[5 -j][i];
                    if (res.Value == null)
                    {
                        spriteBatch.Draw(GreyDieTexture, new Vector2(25 + (j * 100), 25 + (i * 74)), null);

                    }
                    else
                    {
                        spriteBatch.Draw(BlankDieTexture, new Vector2(25 + (j * 100), 25 + (i * 74)), null);
                        int z = j + 1;
                        var df = DieFaces[z];
                        spriteBatch.Draw(df, new Vector2(28 + (j * 100), 28 + (i * 74)), null);
                    }

                }
            }
            //spriteBatch.Draw(BlankDie, new Vector2(25, 98), null);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
