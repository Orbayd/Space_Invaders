using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Collision
{
   public  class Ship : GameObject
   {
      private static Ship instance;
      private int life;
      private bool isAlive;
      private Ship() 
       {
           sprite = new Sprite(SpriteType.Ship);
           colObj = new CollisionObject(sprite);
           sprite.SetFrame(21);
           sprite.SetScale(0.5f);
           sprite.SetColor(Color.AntiqueWhite);
           sprite.SetPosition(Game1.GameInstance.Window.ClientBounds.Width/2, Game1.GameInstance.Window.ClientBounds.Bottom-250);
           //sprite.SetPosition(Game1.GameInstance.Window.ClientBounds.Width / 2, 700);
           colObj.SetScale();
           life = 3;
           isAlive = true;
           SpriteManager.Instance().AddSprite(sprite);
           SpriteManager.Instance().AddCOL(colObj);
           //sprite.SetFrame(2);
           type = GameObjectType.Ship;
       
       }
      public static Ship Instance() 
      {
          if (instance == null) instance = new Ship();
          return instance;
      
      }
      public static void Create()
      {
          instance = new Ship();
      
      }
      public static Ship GetInstance() { return instance; }
      public static bool IsAlive()
      {
          if (instance == null)
          {
              return false;
          }

          return true;
      }
      public  void Destroy()
      {
          if (instance != null)
          {

              SpriteManager.Instance().RemoveCol(this.colObj);
              SpriteManager.Instance().RemoveSprite(this.sprite);
              instance = null;
          }
      }

       public override void  Update()
       {
           colObj.Update();

           base.Update();

       
       }
       public void Move(int x) 
       {
           this.sprite.Move(x);
       
       }
       public void reset()
       {

           isAlive = true;
           sprite.SetFrame(21);
           sprite.SetScale(0.5f);

           sprite.SetPosition(Game1.GameInstance.Window.ClientBounds.Width / 2, Game1.GameInstance.Window.ClientBounds.Bottom-250);
       }
       public void DecreaseLife(){life--;}
       public void IncreaseLife() { life++; }
       public void SetLife(int l) { life = l; }
       public int GetLife() { return life; }
       public override Sprite GetSprite()
       {
           return this.sprite;
       }
       public override CollisionObject GetCol()
       {
           return this.colObj;
       }
      
      
       public void Accept(GameObject other)
       {
           Console.Write("[Ship] ");
          
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
           reactionToShip(s);
       
       }
       public override void VisitBomb(Bomb b)
       {
           Console.WriteLine("Collided with Ship");
           reactionToShip(b);
         //  base.VisitBomb(b);
          
       }
       private void reactionToShip(Bomb b) 
       {
           SoundManager.Instance().Play(CueType.ExplosionQue);

           if (life == 0)
           {
               Ship.Instance().Destroy();
               b.Dead(b);
               Gamereset();




           }
           else
               DecreaseLife();
           
               sprite.SetFrame(22);
               this.isAlive = false;
               Animation ani = new Animation(this);
               TimerManager.Instance().AddTimeEvent(this, 3, ani.DeadShip);
           

          
           b.Dead(b);
       
       }
       private void reactionToShip(Super s)
       {
           Gamereset();
       }
       private void Gamereset()
       {
           this.isAlive = false;
           Game1.GameInstance.gamestate = GameState.MainMenu;
           Player.Instance().Reset();

       }
       public bool GetIsAlive() { return isAlive; }
    }
}
