using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test2DGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        bool Paused;
        GraphicsDeviceManager graphics;
        int PauseCooldown = 0;
        SpriteBatch spriteBatch;
        Texture2D PlayerTexture;
        Vector2 PlayerPos;
        SpriteFont DefaultFont;
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
            System.Random random = new System.Random();
            // TODO: Add your initialization logic here
            PlayerPos = new Vector2(0, 0);
            PlayerTexture = new Texture2D(this.GraphicsDevice, 100, 100);
            Color[] ColorData = new Color[100 * 100];
            for (int i = 0; i < 10000; i++)
            {
                ColorData[i] = Color.Green;
                PlayerTexture.SetData<Color>(ColorData);
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
            DefaultFont = Content.Load<SpriteFont>("Fonts/DefaultFont");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            PlayerTexture.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (Paused == true)
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        IsMouseVisible = false;
                        Paused = false;
                    }
                }
                if (Paused == false)
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        if (PauseCooldown == 0)
                        {
                            Paused = true;
                            IsMouseVisible = true;
                            PauseCooldown = 15;
                            System.Threading.Thread.Sleep(250);
                        }
                    }
                    if (PauseCooldown != 0)
                    {
                        PauseCooldown = PauseCooldown - 1;
                    }
                    //--Controls--\\
                    int speed = 3;
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0 || Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
                        {
                            PlayerPos.X += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * speed;
                        }
                        else
                        {
                            PlayerPos.X += speed;
                        }
                    }
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0 || Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)
                        {
                            PlayerPos.X = PlayerPos.X + GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * speed;
                        }
                        else
                        {
                            PlayerPos.X = PlayerPos.X - speed;
                        }
                    }
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 || Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0)
                        {
                            PlayerPos.Y = PlayerPos.Y - GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * speed;
                        }
                        else
                        {
                            PlayerPos.Y = PlayerPos.Y - speed;
                        }
                    }
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 || Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)
                        {
                            PlayerPos.Y = PlayerPos.Y - GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * speed;
                        }
                        else
                        {
                            PlayerPos.Y += speed;
                        }
                    }
                }
                //--WindowColitions--\\
                if (PlayerPos.X > this.GraphicsDevice.Viewport.Width - 100)
                {
                    PlayerPos.X = this.GraphicsDevice.Viewport.Width - 100;
                }
                if (PlayerPos.Y > this.GraphicsDevice.Viewport.Height - 100)
                {
                    PlayerPos.Y = this.GraphicsDevice.Viewport.Height - 100;
                }
                if (PlayerPos.X < 0)
                {
                    PlayerPos.X = 0;
                }
                if (PlayerPos.Y < 0)
                {
                    PlayerPos.Y = 0;
                }
                //--Collisions--\\
                
                //--Update--\\
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
#pragma warning disable CS0618 // Type or member is obsolete
            spriteBatch.Draw(PlayerTexture, PlayerPos);
            spriteBatch.DrawString(DefaultFont, "Player", PlayerPos, Color.White);
            if (Paused == true)
            {
                Vector2 TextPos = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 4);
                spriteBatch.DrawString(DefaultFont, "Paused", TextPos, Color.White);
            }
#pragma warning restore CS0618 // Type or member is obsolete
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
