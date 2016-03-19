using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Collision
{
  public class UfO: GameObject
  {
     

      private static UfO instance;
      private Animation ani=new Animation();
      public static UfO Instance() 
      { 
          if(instance==null)instance= new UfO();
          
          return instance;
      }
      public static bool IsAlive()
      {
          if (instance == null)
          {
              return false;
          }

          return true;
      }
      public void Destroy()
      {
          if (instance != null)
          {

              SpriteManager.Instance().RemoveCol(this.colObj);
              SpriteManager.Instance().RemoveSprite(this.sprite);
              TimerManager.Instance().RemoveTimeEvent(this);
              SoundManager.Instance().Pause(this, CueType.UFOQue);

              instance = null;
              
             
          }
      }
      private AllienType t=AllienType.Ufo;
      private UfO() 
      {
       
          
          sprite = new Sprite(SpriteType.UFO);
          colObj = new CollisionObject(sprite);
          sprite.SetFrame(20);
          sprite.SetScale(0.5f);
          sprite.SetPosition(new Vector2(50,100));
          sprite.SetSpeed(new Vector2(0, 0));
          colObj.SetScale();

          Animation ani3 = new Animation();
          TimerManager.Instance().AddTimeEvent(this,0.25, ani3.PlayUfo);
         


          Console.WriteLine("UfO Created");
         
        
      
       
      }
      public void Start()
      {
          

          Create();
          
      }
      public override void Update()
      {
          colObj.Update();
          sprite.Update();
      }
      public override void VisitWall(Wall w)
      {
       
          UfO.instance.Destroy();
          Create();
      }
      public override void VisitMissle(Missle m)
      {
        
          m.Destroy();
          ScoreManager.Instance().AddtoScore(this);
          UfO.instance.Destroy();
          
          //TimerManager.Instance().AddTimeEvent(this,10, ani.CreateUFO);
          Create();
      }
      public override CollisionObject GetCol()
      {
          return colObj;
      }
      public override Sprite GetSprite()
      {
          return sprite;
      }
      public void SetMove() { sprite.SetSpeed(new Vector2(4, 0));  }
      public void Reset()
      {
          sprite.SetPosition(new Vector2(0, 100));
          sprite.SetSpeed(new Vector2(0, 0));
      }
      private int Random()
      {
          Random rnd = new Random();
          int x = rnd.Next(10, 20);
          return x;

      }

      public  void Create()
      {
         
         
          Timer timer = new Timer(this,3,ani.CreateUFO);
       
      
      }
  
  }
}
