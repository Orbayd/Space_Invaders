using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{
   public class SpriteManager
    {
        private LinkList SpriteList = new LinkList();
        private LinkList ColList = new LinkList();
        private LinkList ParticleList= new LinkList();
        private LinkList Ex = new LinkList();
    
        private bool Lock=true;
        private static SpriteManager instance;
       
        public static SpriteManager Instance()
        {
            if (instance == null)
                instance = new SpriteManager();
            return instance;
        }
        public void AddSprite(Sprite s)
        {
            SpriteList.AddtoBegining(s);
         
            Console.WriteLine(SpriteList.Count);
        
        }
        public void AddEx(Sprite s) { Ex.AddtoBegining(s); Console.WriteLine(Ex.Count); }
        public void RemoveEx(Sprite s) { Ex.Remove(s); }
        public void SearchEx(Sprite s) { Ex.Search(s); }
        public void RemoveSprite(Sprite s) 
        {
            SpriteList.Remove(s);
        
        }
        public void RemoveCol(CollisionObject c)
        { this.ColList.Remove(c); }
        public void RemoveSprite(GameObject gam)
        {
            SpriteList.Remove(gam.GetSprite());
            ColList.Remove(gam.GetCol());
        
        }
        public void AddCOL(CollisionObject s)
        {
            ColList.AddtoBegining(s);
        

        }
        public void AddExpolsion(Rec e)
        {
            ParticleList.AddtoBegining(e);
        }

        public void Draw()
        {
            for (Node i = SpriteList.head; i != null; i = i.next)
            {
                ((Sprite)i.data).Draw();

                if (((Sprite)i.data).GetSpriteType() == SpriteType.Ship) 
                {
                    Console.WriteLine("Collided with Alien");
                }

            }
            if (Lock == false)
            {
                for (Node i = ColList.head; i != null; i = i.next)
                {
                    ((CollisionObject)i.data).Draw();


                }
            }
            if (Ex.head != null)
            {
                for (Node i = Ex.head; i != null; i = i.next)
                {
                    ((Sprite)i.data).Draw(); ;


                }
            }


            if (ParticleList.head != null)
            {
                for (Node i = ParticleList.head; i != null; i = i.next)
                {
                   
                        ((Rec)i.data).Draw();

                }

                // ClearExposions();
            }




        }
        public void Reset() 
        {    
            SpriteList = new LinkList();
            ColList = new LinkList();
            ParticleList= new LinkList();
            Ex = new LinkList();
            AddCOL(Super.Instance().GetCol());
        
        }

     
        public void ClearExposions() 
        {
            for (Node i = ParticleList.head; i != null; i = i.next) 
            {
                ParticleList.Remove(((Particle)i.data));
              
            }
        
        
        }
        public void SetLock()
        {
            if (Lock == true)
                Lock = false;
            else
               Lock= true;
        
        }
        public Vector2 GetSpriteSpeed(SpriteType type) 
        {

            for (Node i = SpriteList.head; i != null; i = i.next)
            {
                if (((Sprite)i.data).GetSpriteType().Equals(type))
                {
                    return ((Sprite)i.data).GetSpeed();
                }
            }
            return new Vector2(0,0) ;
        
        }
        public void SetSpriteSpeed(Vector2 speed)
        {
            for (Node i = SpriteList.head; i != null; i = i.next)
            {

                if (((Sprite)i.data).GetSpriteType().Equals(SpriteType.Allien))
                {
                    ((Sprite)i.data).SetSpeed(speed);
                    ((Sprite)i.data).SetPosition(new Vector2( ((Sprite)i.data).GetPosition().X, ((Sprite)i.data).GetPosition().Y+30));
                }
            }
        }
       
    }
}
