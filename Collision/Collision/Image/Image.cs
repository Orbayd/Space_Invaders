using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{
   public  class Image
    {

        private static Image instance;
        private int Frame;
        public static Image Instance()
        {
            if (instance == null)
                instance = new Image();
            return instance;
        }
        public Rectangle drawframe(int frame)
        {
            Frame = frame;
            
            int tileX =5;
            int tileY = 6;

            int tileWith = Texture.Instance().GetWidth() / tileX;
            int tileHeight = Texture.Instance().GetHeight() / tileY;
            //int tileWith = 700 / tileX;
           // int tileHeight =500 / tileY;
            int X = Frame % tileX * tileWith;
            int Y = Frame / tileX * tileHeight;

            return new Rectangle(X , Y , tileWith, tileHeight );
        }
    }
}
