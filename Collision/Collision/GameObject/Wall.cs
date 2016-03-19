using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
   public class Wall : GameObject
    {
       private static Wall instance;
       public static Wall Instance() 
       {
           if (instance == null)
               instance = new Wall();
           return instance;
       
       }
       private Wall() { colObj = new CollisionObject(new Rectangle(0, 0, Game1.GameInstance.Window.ClientBounds.Width-2, Game1.GameInstance.Window.ClientBounds.Height-2));
       SpriteManager.Instance().AddCOL(colObj); type = GameObjectType.Wall;
       }

        public override void Update()
        {


        }
        public override CollisionObject GetCol()
        {
            return this.colObj;
        }
        public override Sprite GetSprite()
        {
            return this.sprite;
        }

        public void Accept(GameObject other)
        {
            Console.Write("[Wall] ");
            other.VisitWall(this);
        }

        public override void VisitSuper(Super s)
        {
            Console.WriteLine("Collided with Wall");
            reactionToWall(this, s);
        }

          public override void VisitMissle(Missle m)
           {
               Console.WriteLine("Collided with Wall");
               reactionToWall(this, m);
           }

        public override void VisitAlien(Allien a)
        {

            Console.WriteLine("Collided with Wall");
           
         //   a.GetSprite().SetSpeed(a.GetSprite().GetSpeed() * -1);
           

        }

        private void reactionToWall(Wall w, Super s)
        {  

            SpriteManager.Instance().SetSpriteSpeed( SpriteManager.Instance().GetSpriteSpeed(SpriteType.Allien)*-1);
            
        }

          private void reactionToWall(Wall w, Missle m)
          {
              if (Missle.IsAlive())
              {
                  Missle.Instance().Destroy();
                //  Missle.Instance();
              }
          }
    }
}
