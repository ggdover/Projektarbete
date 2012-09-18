using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace ProjektArbete
{
    class Blocks
    {
        Texture2D block1, block2;
        Rectangle block1position, block2position;


        public void LoadContent(ContentManager Content)
        {
            block1 = Content.Load<Texture2D>("block1");
            block2 = Content.Load<Texture2D>("block2");
            block1position = new Rectangle(0, 200, 100, 50);
            block2position = new Rectangle(300, 150, 20, 60);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(block2, block2position, Color.White);
            spritebatch.Draw(block1, block1position, Color.White);
        }
    }
}
