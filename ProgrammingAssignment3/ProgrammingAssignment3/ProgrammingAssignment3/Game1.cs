using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ProgrammingAssignment3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        Random rand = new Random();
        Vector2 centerLocation = new Vector2(
            WINDOW_WIDTH / 2, WINDOW_HEIGHT / 2);

        // STUDENTS: declare variables for 3 rock sprites
        Texture2D srock00;
        Texture2D srock01;
        Texture2D srock02;
        // STUDENTS: declare variables for 3 rocks
        Rock rock00;
        Rock rock01;
        Rock rock02;

        // delay support
        const int TOTAL_DELAY_MILLISECONDS = 1000;
        int elapsedDelayMilliseconds = 0;

        // random velocity support
        const float BASE_SPEED = 0.15f;
        Vector2 upLeft = new Vector2(-BASE_SPEED, -BASE_SPEED);
        Vector2 upRight = new Vector2(BASE_SPEED, -BASE_SPEED);
        Vector2 downRight = new Vector2(BASE_SPEED, BASE_SPEED);
        Vector2 downLeft = new Vector2(-BASE_SPEED, BASE_SPEED);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // change resolution
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
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

            // STUDENTS: Load content for 3 sprites
            srock00 = Content.Load<Texture2D>("greenrock");
            srock01 = Content.Load<Texture2D>("magentarock");
            srock02 = Content.Load<Texture2D>("whiterock");
            // STUDENTS: Create a new random rock by calling the GetRandomRock method
            Rock rock00 = GetRandomRock();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // STUDENTS: update rocks
            rock00.Update(gameTime);
            rock01.Update(gameTime);
            rock02.Update(gameTime);

            // update timer
            elapsedDelayMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedDelayMilliseconds >= TOTAL_DELAY_MILLISECONDS)
            {
                // STUDENTS: timer expired, so spawn new rock if fewer than 3 rocks in window
                if (rock00 != null)
                {
                    if (rock00.OutsideWindow)
                    {
                        rock00 = GetRandomRock();
                    }
                }
                if (rock01 != null)
                {
                    if (rock01.OutsideWindow)
                    {
                        rock01 = GetRandomRock();
                    }
                }
                if (rock02 != null)
                {
                    if (rock02.OutsideWindow)
                    {
                        rock02 = GetRandomRock();
                    }
                }
                // restart timer
                elapsedDelayMilliseconds = 0;
            }

            // STUDENTS: Check each rock to see if it's outside the window. If so
            // spawn a new random rock for it by calling the GetRandomRock method
            // Caution: Only check the property if the variable isn't null

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // STUDENTS: draw rocks
            spriteBatch.Begin();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Gets a rock with a random sprite and velocity
        /// </summary>
        /// <returns>the rock</returns>
        private Rock GetRandomRock()
        {
            // STUDENTS: Uncomment and complete the code below to randomly pick a rock sprite by calling the GetRandomSprite method
            Texture2D sprite = GetRandomSprite();

            // STUDENTS: Uncomment and complete the code below to randomly pick a velocity by calling the GetRandomVelocity method
            Vector2 velocity = GetRandomVelocity();

            // STUDENTS: After completing the two lines of code above, delete the following two lines of code
            // They're only included so the code I provided to you compiles
           
            // return a new rock, centered in the window, with the random sprite and velocity
            return new Rock(sprite, centerLocation, velocity, WINDOW_WIDTH, WINDOW_HEIGHT);
        }

        /// <summary>
        /// Gets a random sprite
        /// </summary>
        /// <returns>the sprite</returns>
        private Texture2D GetRandomSprite()
        {
            // STUDENTS: Uncommment and modify the code below as appropriate to return 
            // a random sprite
            int spriteNumber = rand.Next(3);
            if (spriteNumber == 0)
            {
                return srock00;
            }
            else if (spriteNumber == 1)
            {
                return srock01;
            }
            else
            {
                return srock02;
            }

            // STUDENTS: After completing the code above, delete the following line of code
            // It's only included so the code I provided to you compiles
            // return null;
        }

        /// <summary>
        /// Gets a random velocity
        /// </summary>
        /// <returns>the velocity</returns>
        private Vector2 GetRandomVelocity()
        {
            // STUDENTS: Uncommment and modify the code below as appropriate to return 
            // a random velocity
            int velocityNumber = rand.Next(5);
            if (velocityNumber == 0)
            {
                return upLeft;
            }
            else if (velocityNumber == 1)
            {
                return upRight;
            }
            else if (velocityNumber == 2)
            {
                return downRight;
            }
            else
            {
                return downLeft;
            }

            // STUDENTS: After completing the code above, delete the following line of code
            // It's only included so the code I provided to you compiles
            //return Vector2.Zero;
        }
    }
}
