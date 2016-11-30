using HomeWork1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    public abstract class VisibleGameEntity : GameEntity
    {
        public virtual void Draw(GameTime gameTime, object helper)
        {

        }

        public int State = 0;

        public abstract bool IsSelected(float x, float y);
    }
}