using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class Global
    {
        static public ContentManager Content;
        //static public KeyboardHelper KeyboardHelper = new KeyboardHelper();
        static public MouseHelper MouseHelper = new MouseHelper();
        static public Camera2D Camera = new Camera2D();

        public static List<Texture2D> LoadTextures(string strResourcePrefix, int nTextures)
        {
            List<Texture2D> textures = new List<Texture2D>();
            for (int i = 1; i <= nTextures; i++)
            {
                textures.Add(Content.Load<Texture2D>(strResourcePrefix + i.ToString("00")));
            }
            return textures;
        }
    }
}
