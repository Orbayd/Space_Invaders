using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
    public enum ColType
    {
        Allien,
        Wall,
        Shield,
        Missle,
        Column,
        Columns,
        Super,
        Bomb
    };
  public  class CollisionObject
    {
        private Texture2D texture;
        private Rectangle rec;
        private SpriteBatch spritebatch;
        private int bw;
        private int height,slipy;
        private int width,slipx;
        private Sprite sprite;
        private int Age;
        public CollisionObject()
        {
            texture = new Texture2D(Game1.GameInstance.GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Violet });
            spritebatch = Game1.GameInstance.spriteBatch;
            bw = 2; width = height = 30;
            slipx=slipy= 0;
            Age=2;
        }
        public CollisionObject(Rectangle rec)  :this()
        {
            this.rec = rec;
        }
        public CollisionObject(Sprite s) :this()
        {
         
            this.sprite = s;
            
        }

        public  void  Draw()
        {


            spritebatch.Draw(texture, new Rectangle(rec.Left, rec.Top, bw, rec.Height), null, Color.Magenta, 0, Vector2.Zero, SpriteEffects.None, 1); // Left
            spritebatch.Draw(texture, new Rectangle(rec.Right, rec.Top, bw, rec.Height), null, Color.Magenta, 0, Vector2.Zero, SpriteEffects.None, 1); // Right
            spritebatch.Draw(texture, new Rectangle(rec.Left, rec.Top, rec.Width, bw), null, Color.Magenta, 0, Vector2.Zero, SpriteEffects.None, 1); // Top
            spritebatch.Draw(texture, new Rectangle(rec.Left, rec.Bottom, rec.Width, bw), null, Color.Magenta, 0, Vector2.Zero, SpriteEffects.None, 1); 
        
        
        }
        public void Destroy(CollisionObject col) 
        {
            col.rec = new Rectangle(1, 1, 0, 0);
            SpriteManager.Instance().RemoveCol(col);
        
        
        }
        public  void  Update() 
        {
       
            Move();
         
        
        }
        public void SetScale(Point xy) { this.width = xy.X; this.height = xy.Y; slipx = xy.X; slipy = xy.Y; }
        public void SetScale()
        {
            Vector2 vec = this.sprite.GetSpriteBounds();
            float scale = this.sprite.GetScale();
            vec.X *= scale-0.1f;
            vec.Y *= scale-0.1f;
            width = (int)vec.X  ;
            height =(int) vec.Y;
   
        
        }
        public Rectangle GetCoordinates() { return rec; }
        public void SetCoordinates(Rectangle coord) { this.rec = coord; } 
        private void Move()
        {
          //  Point xy =sprite.GetSpriteBounds().Center;
            Vector2 pos = sprite.GetPosition();
               
            this.rec = new Rectangle((int)pos.X+slipx, (int)pos.Y, width, height);
                  
        }
        private Vector2 SetOrigin()
        {
            Vector2 Origin;

            if (sprite != null)
            {
               
                return Origin = new Vector2(sprite.GetSpriteBounds().X / 2, sprite.GetSpriteBounds().Y / 2);
            }
            else return Vector2.Zero;
        
        }
        public void SetAge(int age) { this.Age = age; }
        public int GetAge() { return this.Age; }
      
    }
}
