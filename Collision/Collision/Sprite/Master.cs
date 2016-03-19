using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{
  public abstract class Master
    {
       
       protected Vector2 position;



        //public void SetPosition(float x,float y) 
        //{
        //    position.X = x;
        //    position.Y = y;
        //}
        //public void SetPosition(Vector2 pos) { this.position = pos; }
        public virtual void Update(){}
        public virtual void Draw(){}
        public virtual void SetPosition(int x, int y) { }
    }
}
