using System;
using System.Collections.Generic;
using System.Collections;

using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision
{
   public enum Type
    {
        sprite,
        exsprite,
        None,
    
    };
    public class FactorySprite 
    {
        private LinkList SpriteList = new LinkList();
        private Hashtable  Sprites = new Hashtable();
        public FactorySprite() 
        {
           // SpriteList.AddtoBegining(new Sprite());
            Sprites.Add(Type.sprite, new FlySprite());
            Sprites.Add(Type.exsprite, new FlyExSprite());
        }
        public GameSprite getSprite(Type type) 
        {
            //  return (Sprite)SpriteList.Search(O);
            GameSprite gamesprite = null;
            if(Sprites.ContainsKey(type))
            {
                gamesprite =( GameSprite)Sprites[type];
            
            }
          return gamesprite;
        }
    
    } 
    
    public abstract class GameSprite 
    {
        protected Texture2D texture;
        protected Texture loadTexture;
        public Vector2 Speed;
        protected Color color;
        public Type type;
        protected float scale;
        protected float layerDepth;

        public virtual void SetColor(Color color) { this.color = color; }
        public virtual Texture2D getTexture() { return texture; }
        public virtual float getScale() { return scale; }
        public virtual Color getColor() { return color; }
        public virtual Vector2 getSpeed() { return Speed; }
        public virtual void SetSpeed(Vector2 speed) { this.Speed = speed; }
        public virtual float getLayerDept() { return layerDepth; }
        public virtual Type getType() { return type; }
        public virtual void setScale(float scale) { this.scale = scale; }
        public virtual void setLayerDept(float l) { layerDepth = l; }
  }
    
       public  class FlySprite : GameSprite
    {
        private  static FlySprite instance;
        public static FlySprite Instance() { if (instance == null)instance = new FlySprite(); return instance; }
        public FlySprite()
        {
            
            scale = .3f;
            layerDepth = 0.9f;
            type = Type.sprite;
            texture = Texture.Instance().GetTexture();
            Speed = new Vector2(1, 0);
            color = Color.White;
            
            
        }

        public override void SetColor(Color color) { this.color = color; }
        public override Texture2D getTexture() { return texture; }
        public override float getScale() { return scale; }
        public override Color getColor() { return color; }
        public override Vector2 getSpeed() { return Speed; }
        public override void SetSpeed(Vector2 speed){this.Speed=speed;}
        public override float getLayerDept() { return layerDepth; }
        public override void  setLayerDept(float l) {  layerDepth=l; }
        public override Type getType() { return type; }
        public override void setScale(float scale) { this.scale = scale; }
      
       
    }
       public class FlyExSprite : GameSprite 
       { 
            public FlyExSprite()
        {
            
            scale = 1f;
            layerDepth = 1f;
            type = Type.sprite;
            texture = Texture.Instance().GetTexture();
            Speed = new Vector2(0, 0);
            color = Color.Black;
            
            
        }
            public override void SetColor(Color color) { this.color = color; }
            public override Texture2D getTexture() { return texture; }
            public override float getScale() { return scale; }
            public override Color getColor() { return color; }
            public override  Vector2 getSpeed() { return Speed; }
            public override void SetSpeed(Vector2 speed) { this.Speed = speed; }
            public override float getLayerDept() { return layerDepth; }
            public override Type getType() { return type; }
            public override void setScale(float scale) { this.scale = scale; }
       
       
       }
}
