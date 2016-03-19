using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Collision
{
  public class ShieldMini:Shield
    {
     
      private int x, y, width, height;
      public ShieldMini() { }
      public ShieldMini(int x, int y, int width, int height) { this.x = x; this.y = y; this.width = width;
          this.height = height;  }
      
      public void Create() 
      { 
          colObj = new CollisionObject(new Rectangle(x,y,width,height));
         
      
      }

    }
}
