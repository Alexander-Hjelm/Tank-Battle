using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankBattle
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        Tank tank1;
        Tank tank2;

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

            tank1 = new Tank();
            tank2 = new Tank();

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
            Texture2D tankTexture2D = Content.Load<Texture2D>("Graphics\\tank");
            Texture2D bulletTexture2D = Content.Load<Texture2D>("Graphics\\bullet");

            Vector2 origin = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y);
            Vector2 max = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.Width, GraphicsDevice.Viewport.TitleSafeArea.Height);

            Vector2 tank1Position = new Vector2(origin.X + tankTexture2D.Width/2 + 50, origin.Y + tankTexture2D.Height/2 + 50);
            Vector2 tank2Position = new Vector2(max.X - tankTexture2D.Width/2 - 50, max.Y - tankTexture2D.Height/2 - 50);

            tank1.Initialize(tankTexture2D, bulletTexture2D, GraphicsDevice.Viewport, tank1Position, 0f);
            tank2.Initialize(tankTexture2D, bulletTexture2D, GraphicsDevice.Viewport, tank2Position, MathHelper.Pi);
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

            // TODO: Add your update logic here
            HandleInput();

            tank1.Update();
            tank2.Update();

            base.Update(gameTime);
        }

        public void HandleInput()
        {
            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                tank2.Move(1f);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                tank2.Move(-1f);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                tank2.Turn(1f);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                tank2.Turn(-1f);
            }

            if (currentKeyboardState.IsKeyDown(Keys.RightControl))
            {
                tank2.Shoot();
            }

            if (currentKeyboardState.IsKeyDown(Keys.W))
            {
                tank1.Move(1f);
            }

            if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                tank1.Move(-1f);
            }

            if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                tank1.Turn(1f);
            }

            if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                tank1.Turn(-1f);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Space))
            {
                tank1.Shoot();
            }

            previousKeyboardState = currentKeyboardState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();    //Begin drawing

            tank1.Draw(spriteBatch);
            tank2.Draw(spriteBatch);
            
            spriteBatch.End();  //End drawing


            base.Draw(gameTime);
        }
    }
}
