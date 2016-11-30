﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    public class MyTexture : VisibleGameEntity
    {
        private Texture2D texture = null;
        private int left = 0;
        private int top = 0;
        private int width = 0;
        private int height = 0;

        public MyTexture()
        {

        }

        public MyTexture(string name)
        {
            LoadContent(name);
        }

        public MyTexture(string name, int l, int t, int w, int h)
        {
            left = l;
            top = t;
            width = w;
            height = h;
            LoadContent(name);
        }

        public void LoadContent(string name)
        {
            texture = Global.Content.Load<Texture2D>(name);
        }

        public override void Draw(GameTime gameTime, object helper)
        {
            SpriteBatch spriteBatch = (SpriteBatch)helper;
            spriteBatch.Draw(texture, new Vector2(left, top), Color.White);
            //if (State == 0)
            //    spriteBatch.Draw(Textures[iTexture], new Vector2(Left, Top), Color.White);
            //else
            //    spriteBatch.Draw(Textures[iTexture], new Vector2(Left, Top), Color.Yellow);
        }
    }
}