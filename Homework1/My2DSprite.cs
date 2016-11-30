using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Homework1
{
    public class My2DSprite: VisibleGameEntity
    {
        public List<Texture2D> Textures;
        public int nTextures;
        public int iTexture;
        public float Left, Top, Width, Height;

        public My2DSprite(List<Texture2D> textures, float left, float top, float width, float height)
        {
            Textures = textures;
            nTextures = textures.Count;
            iTexture = 0;
            Left = left;
            Top = top;
            if (width == 0)
                Width = textures[0].Width;
            else
                Width = width;
            if (height == 0)
                Height = textures[0].Height;
            else
                Height= height;
        }

        public float Delay = 16;

        public override void Update(GameTime gameTime)
        {
            iTexture = (iTexture + 1) % nTextures;

//            iTexture = ((int)(gameTime.TotalGameTime.TotalMilliseconds / Delay)) % nTextures;
            //base.Update(gameTime);
        }

        public int State = 0;
        public override void Draw(GameTime gameTime, object helper)
        {
            //base.Draw(gameTime, helper);
            SpriteBatch spriteBatch = (SpriteBatch)helper;
            if (State == 0)
                spriteBatch.Draw(Textures[iTexture], new Vector2(Left, Top), Color.White);
            else
                spriteBatch.Draw(Textures[iTexture], new Vector2(Left, Top), Color.Yellow);

        }

        public bool IsSelected(float x, float y)
        {
            if (x >= Left && x < Left + Width
                && y >= Top && y < Top + Height)
                return true;
            else
                return false;
        }

    }
}