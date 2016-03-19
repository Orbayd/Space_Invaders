using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
    public enum AllienType 
    {
        Squid, Jellyfish,Ant,Ufo
    
    
    };

    public class Allien : GameObject
    {
        protected AllienType allientype;
        public Allien() { }
        public Allien(AllienType atype)
        {

          
            sprite = new Sprite(SpriteType.Allien);
            colObj = new CollisionObject(sprite);
            type = GameObjectType.Allien;
            this.allientype = atype;
            Create();
            Animation ani = new Animation(this);

            
            TimerManager.Instance().AddTimeEvent(this,1, new TimerEvent(ani.ChangeFrames));
 
        }
        private bool isDead;
        private void Create()
        {
            this.isDead = false;
          
            SpriteManager.Instance().AddCOL(colObj);
            SpriteManager.Instance().AddSprite(sprite);
            sprite.SetSpeed(new Vector2(0.5f, 0));
           
        
        }
        public override void Update(GameTime gameTime)
        {
          
            sprite.Update();
            colObj.Update();
          
            base.Update();


         
        }
        public AllienType GetAllienType() { return allientype; }
        public void SetFrame(int f) { sprite.SetFrame(f); }
        public  int GetFrame() {return  sprite.GetFrame(); }
        public void SetPosition(Vector2 pos) { sprite.SetPosition(pos); }
        public void SetPosition(int x ,int y) { sprite.SetPosition(x,y); }
    
        public void Accept(GameObject other)
        {
            Console.Write("[Alien] ");

            other.VisitAlien(this);
        }
        public override void VisitMissle(Missle m)
        {
            Console.WriteLine("Collided with Alien");

            reactionToAlien(this, m);
        }

        private void reactionToAlien(Allien a, Wall w)
        {

        }
        private void reactionToAlien(Allien a, Missle m)
        {
          if(Missle.IsAlive())
          {
            Missle.Instance().Destroy();
          
            Dead(a);
          }
         //this.sprite.SetFrame(23);
        
        }
        private void Dead(Allien a)
        {
           // TimerManager.Instance().RemoveTimeEvent(this);
            this.sprite.SetFrame(23);
      
            this.isDead = true;
           
            Animation ani = new Animation(a);

           // Timer timer = new Timer(this, 1, ani.DeadAllien);
            //TimerManager.Instance().AddTimer(timer);
            TimerManager.Instance().AddTimeEvent(this,2, ani.DeadAllien);

            SoundManager.Instance().Play(CueType.AllienKillQue);
            
            ScoreManager.Instance().AddtoScore(a);
            Player.Instance().RemoveFromAllienList(a);

        }
        public bool IsDead() { return isDead; }
     
        
        
        
        public override Sprite GetSprite() { return sprite; }
        public override CollisionObject GetCol() { return colObj; }

    }
} 
    

