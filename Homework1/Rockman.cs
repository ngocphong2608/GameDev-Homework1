using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Homework1
{
    public class Rockman : VisibleGameEntity
    {
        private My2DSprite sprite;

        public Rockman(int left, int top)
        {
            List<Texture2D> textures = Global.LoadTextures("Rockman", 11);
            sprite = new My2DSprite(textures, left, top, 0, 0);
            sprite.Delay = 100;
        }

        public override void Draw(GameTime gameTime, object helper)
        {
            //            base.Draw(gameTime, helper);
            sprite.Draw(gameTime, helper);
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);

            sprite.Left += 1;
            if (sprite.Left >= 800)
            {
                sprite.Left = 0;
            }
        }
    }
}