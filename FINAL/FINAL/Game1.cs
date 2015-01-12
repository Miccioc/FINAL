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

namespace FINAL
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture1;

        Rectangle rectangle1;
        Rectangle rectangle2;
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
            rectangle1 = new Rectangle(0, 0, 1920, 1080);
            rectangle2 = new Rectangle(0, 1080, 1920, 1080);
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
            texture1 = Content.Load<Texture2D>("background");
            Song song = Content.Load<Song>("music");
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 10.0f;
            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic here
            // Simple bounds check. If the right edge of rectangle1 is offscreen to the left, 
			// the code moves it to the right side of rectangle2.
			if (rectangle1.Y + texture1.Height <= 0)
				rectangle1.Y = rectangle2.X + texture1.Height;
			// Then repeat this check for rectangle2.
			if (rectangle2.Y + texture1.Height <= 0)
				rectangle2.Y = rectangle1.X + texture1.Height;

			// 6. Incrementally move the rectangles to the left. 
			// Optional: Swap X for Y if you want to scroll vertically.

			rectangle1.Y -= 15;
			rectangle2.Y -= 15;

           
              


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(texture1, rectangle1, Color.White);
            spriteBatch.Draw(texture1, rectangle2, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
