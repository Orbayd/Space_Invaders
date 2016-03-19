using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{
   public class Rec
    {
        private Color color;
        private int height;
        private int width;
        private int x;
        private int y;
        Rectangle particle;
        private Texture2D texture;
        SpriteBatch spriteBatch;
       public Rec(int x, int y,int width,int height)
       {
           this.x = x;
           this.y = y;
           this.width = width;
           this.height = height;
           particle = new Rectangle(x, y, width, height);
           this.color = Color.Black;
           texture = new Texture2D(Game1.GameInstance.GraphicsDevice, 1, 1);
           texture.SetData(new[] { Color.Wheat });
           SpriteManager.Instance().AddExpolsion(this);

        }
       public void Draw()
       {
           spriteBatch = Game1.GameInstance.spriteBatch;
           spriteBatch.Draw(texture, particle, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 0.88f);
       }
    }
}
