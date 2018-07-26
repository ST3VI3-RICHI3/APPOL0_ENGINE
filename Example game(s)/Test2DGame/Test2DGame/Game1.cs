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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D PlayerTexture;
        Vector2 PlayerPos;
        
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

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
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                // TODO: Add your update logic here
                //--Controls--\\
                int speed = 2;
                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0||Keyboard.GetState().IsKeyDown(Keys.D))
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
                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0||Keyboard.GetState().IsKeyDown(Keys.W))
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
                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0||Keyboard.GetState().IsKeyDown(Keys.S))
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
                if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {
                    GamePad.SetVibration(PlayerIndex.One, 10, 10);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(PlayerTexture, PlayerPos);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
