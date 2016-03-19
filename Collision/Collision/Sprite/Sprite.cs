using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{  public enum SpriteType
   { 
      Allien,
      Wall,
      Missle,
      Shield,
      Ship,
      UFO,
      Label,
   }

   public  class Sprite 
    {
       private int frame;
       private SpriteType type;
     
       protected Vector2 position;
       private FlySprite sprite;
       private SpriteBatch Spritebatch;
       public Sprite(SpriteType type) 
       
       {
          this.type = type;
          FactorySprite factory = new FactorySprite();
          sprite  = (FlySprite)factory.getSprite(Type.sprite);
         
          Spritebatch = Game1.GameInstance.spriteBatch;
        
       }
 

       public  void Draw()
       {
          // Vector2 Origin = new Vector2(GetSpriteBounds().Width / 2, GetSpriteBounds().Height / 2);
           Vector2 Origin = Vector2.Zero;


           Spritebatch.Draw(sprite.getTexture(),
               position, Image.Instance().drawframe(frame)
               , sprite.getColor(),
               0, Vector2.Zero, sprite.getScale()
               , SpriteEffects.None,
               sprite.getLayerDept());
       
       }

       public  void Update() { Move(); }

       public void UpdateSprite() { frame++; }

       public Vector2 GetSpeed() {return sprite.getSpeed(); }
       public void SetSpeed(Vector2 speed) {sprite.SetSpeed(speed); }
       public Vector2 GetPosition() { return position; }
       public void SetFrame(int frame) { this.frame = frame; }
       public  int GetFrame() { return frame; }
       public void SetColor(Color color) { sprite.SetColor(color); }
       public Color GetColor(){return sprite.getColor();}
       public void SetPosition(int x, int y) { this.position = new Vector2(x, y); }
       public void SetPosition(Vector2 pos) { this.position = pos; }
       public void Move() { this.position += sprite.getSpeed(); }
       public void Move(int x) { this.position +=  new Vector2(x, 0); }
       public SpriteType GetSpriteType() { return this.type; }
       public Vector2 GetSpriteBounds() {return  new Vector2( Image.Instance().drawframe(frame).Width,Image.Instance().drawframe(frame).Height); }
       public void SetScale(float scale) { sprite.setScale(scale); }
       public float GetScale() { return sprite.getScale(); }
       public void SetLayerDepth(float l) { sprite.setLayerDept(l); }
       
    }
}
