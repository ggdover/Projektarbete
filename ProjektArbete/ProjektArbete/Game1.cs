using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ProjektArbete
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Blocks blocks = new Blocks();

        Texture2D guystill, guymove1, guymove2, guyjump;
        Vector2 guyposition;
        Vector2 gravity;

        Boolean hasjumped;

        int draw = 1, frameCounter = 0, frameSwitch = 300, frameCurrent = 1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            blocks.LoadContent(Content);

            guystill = Content.Load<Texture2D>("guystill");
            guymove1 = Content.Load<Texture2D>("guymove1");
            guymove2 = Content.Load<Texture2D>("guymove2");
            guyjump = Content.Load<Texture2D>("guyjump");
            guyposition = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - guystill.Width / 2, 400); 
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {

            guyposition += gravity;

            frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (frameCounter >= frameSwitch && frameCurrent == 1)
            {
                frameCurrent = 2;
                frameCounter = 0;
            }
            
            if (frameCounter >= frameSwitch && frameCurrent == 2)
            {
                 frameCurrent = 1;
                 frameCounter = 0;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Up) && hasjumped == false)
            {
                hasjumped = true;
                guyposition.Y -= 10f;
                gravity.Y = -5f;

            }

            if (hasjumped == true)
            {
                float i = 1f;
                gravity.Y += 0.15f * i;
                draw = 3;
            }

            if (hasjumped == false)
                gravity.Y = 0f;

            if (guyposition.Y >= 400)
                hasjumped = false;
            
            if (guyposition.X <= -10)
            {
            }

            else
            {
                if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left))
                {
                    guyposition.X -= 3;
                }
            }
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left) && hasjumped == false)
            {
                draw = 2;
            }

            if (guyposition.X >= GraphicsDevice.Viewport.Width - 70)
            {
            }
            else
            {
                if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right))
                {
                    guyposition.X += 3;
                }
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right) && hasjumped == false)
            {
                draw = 2;
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyUp(Keys.Right) && Keyboard.GetState(PlayerIndex.One).IsKeyUp(Keys.Left) && hasjumped == false)
            {
                draw = 1;
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            blocks.Draw(spriteBatch);

            if (draw == 1)
            {
                spriteBatch.Draw(guystill, guyposition, Color.White);
            }

            else if (draw == 2)
            {
                if (frameCurrent == 1)
                {
                    spriteBatch.Draw(guymove1, guyposition, Color.White);
                }
                else if (frameCurrent == 2)
                {
                    spriteBatch.Draw(guymove2, guyposition, Color.White);
                }
            }
            else if (draw == 3)
            {
                spriteBatch.Draw(guyjump, guyposition, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
