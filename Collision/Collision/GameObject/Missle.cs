using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
    public class Missle:GameObject
    {
        private static Missle instance;
       
        public static Missle Instance() 
        {
            if (instance == null) 
            {
                instance = new Missle();
            }
            return instance;
        }
        public void Destroy()
        {
            if (instance != null)
            {
                
                SpriteManager.Instance().RemoveCol(this.colObj); 
                SpriteManager.Instance().RemoveSprite(this.sprite);
                instance = null;
            }
        }
        public static  bool IsAlive() { 
            if(instance ==null)
            {
                return false;
            }

            return true;
        }
        private Missle() { 
             
             sprite= new Sprite(SpriteType.Missle);
             sprite.SetFrame(24);
        
             sprite.SetPosition(new Vector2(Ship.Instance().GetSprite().GetPosition().X , Game1.GameInstance.Window.ClientBounds.Height - 50));
             colObj = new CollisionObject(sprite);
             colObj.SetScale(new Point(10,5));
             type = GameObjectType.Missle;

             sprite.SetSpeed(new Vector2(0, -10));
             SpriteManager.Instance().AddSprite(sprite);
             SpriteManager.Instance().AddCOL(colObj);

             SoundManager.Instance().Play(CueType.ShootQue);
        
        }

        public override void Update()
        {
            sprite.Update();
            colObj.Update();

            base.Update();
        }

       

        public override CollisionObject GetCol()
        {
            return this.colObj;
        }
        public  void Accept(GameObject other)
        {
            Console.Write("[Missle] ");
            other.VisitMissle(this);
        }
        
        public override void VisitWall(Wall w)
        {
            base.VisitWall(w);
        }
        public override void VisitAlien(Allien a)
        {
            base.VisitAlien(a);
        }
        public override void VisitSuper(Super s)
        {
            base.VisitSuper(s);
        }
        public override void VisitBomb(Bomb b)
        {
            Console.WriteLine("Collided with Missle");
            reactionToMissle(b);
           // base.VisitBomb(b);
        
        }
        private void reactionToMissle(Bomb bomb)
        {
            if (Missle.IsAlive())
            {
                Missle.Instance().Destroy();
                //  Missle.Instance();
            }
          
            bomb.Dead(bomb);
        
        }
        public override void VisitShield(Shield sh,CollisionObject col,Group g)
        {
            Console.WriteLine("Collided with Missle");
            reactionToMissle(sh,col,this,g);
            //base.VisitShield(sh,col);
        }

        private void reactionToMissle(Shield s,CollisionObject col, Missle m,Group g)
        {
            int x = col.GetCoordinates().X;
            int y = col.GetCoordinates().Y;
            int width = col.GetCoordinates().Width;
            int height = col.GetCoordinates().Height;
              m.Destroy();
              if (g.GetList().Count == 2)
              {
                  col.Destroy(col);

                  g.RemoveFromGroup(col);
              }
            
              Exp ex = new Exp(x,y,26);
              ex.SetFrame(26);
              ex.AddSprite();
              g.Age -= 1;
             
              if (g.Age == 0)
              {
                  Rec rec = new Rec(g.GetCoordinates().X, g.GetCoordinates().Y, g.GetCoordinates().Width+3, g.GetCoordinates().Height+2);
                  col.Destroy(col);
                  g.RemoveFromGroup(col);
                  s.RemoveGroup(g);
                
              }
              if (s.GetColGroup().GetList().Count == 0)
              {
                  SpriteManager.Instance().RemoveSprite(s.GetSprite());
                  s.RemoveSuper();

              }
           
        }
        private void explosion(int x,int y) 
        {  
            Explosion ex = new Explosion(10, x, y);
            ex.SetExplosion();
          
        
        }
        private void clear(int x, int y) { Explosion ex = new Explosion(10, x, y);
            ex.Clear(colObj.GetCoordinates().Width,colObj.GetCoordinates().Height); }
       
    }


}
