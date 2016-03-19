using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Collision
{
   public class GameObjectMan
    {
        private static GameObjectMan instance;
        private LinkList GameObjectList = new LinkList();
        public static GameObjectMan Instance()
        {
            if (instance == null)
                instance = new GameObjectMan();
            return instance;
        }
        
        LinkList alien = new LinkList();
        LinkList Wall = new LinkList();
        LinkList Collums = new LinkList();
        LinkList bomb = new LinkList();
        LinkList Ufo = new LinkList();
        public void add_Object(GameObject o)
        {
            if (o is Allien)
            {
                alien.AddtoBegining(o);
               

            }
            else if (o is Wall)
            {

                Wall.AddtoBegining(o);
            }

         
            else if (o is Column)
            {
                Collums.AddtoBegining(o);

            }
            else if (o is Bomb) 
            {
                bomb.AddtoBegining(o);
            
            }
          //  else if (o is UfO) { Ufo.AddtoBegining(o); }
         



        }

        public void RemoveObject(GameObject o) 
        {
            if (o is Allien)
            {   
                
               // SpriteManager.Instance().RemoveSprite(o.GetSprite());
               // SpriteManager.Instance().RemoveCol(o.GetCol());
                GroupManager.Instance().RemoveObject(o);
                alien.Remove(o);

            }
            else if (o is Wall)
            {

                Wall.Remove(o);
            }

            else if (o is Column)
            {
                Collums.Remove(o);

            }
           
        
        }


        public void update(GameTime gameTime)
        {
            alienObjsUpdate(gameTime);
            wallObjUpdate();
            CollumsUpdate();
            SuperUpdate();
            MissleUpdate();
            ShipUpdate();
            bombObjUpdate();
            UfOUpdate();
           
        }
        private void bombObjUpdate()
        {
            Node ptr =bomb.head;

            while (ptr != null)
            {
                ((Bomb)ptr.data).Update();

                ptr = ptr.next;
            }
        }
        private void alienObjsUpdate(GameTime gameTime)
        {
            Node ptr = alien.head;

            while (ptr != null)
            {
                ((Allien)ptr.data).Update(gameTime);

                ptr = ptr.next;
            }


        }
        private void wallObjUpdate()
        {
        }
        private void CollumsUpdate()
        {
            for (Node i = Collums.head; i != null; i = i.next)
            {
                ((GameObject)i.data).Update();


            }


        }
        private void ShipUpdate()
        {
            if (Ship.IsAlive()) 
              Ship.GetInstance().Update();
             
        }
        private void UfOUpdate() { if (UfO.IsAlive()) { UfO.Instance().Update(); } }
        private void MissleUpdate() 
        {
            if (Missle.IsAlive())
            {
                Missle.Instance().Update();
            }
        
        }
        private void SuperUpdate()
        {
            Super.Instance().Update();
        
        }
        public void DestroyMissle() 
        {
            if (Missle.IsAlive())
            {
                Missle.Instance().Destroy();
            }
        
        }
        public void Reset()
        {
          
            alien = new LinkList();
            Wall = new LinkList();
            Collums = new LinkList();
            bomb = new LinkList();
        
        }
    }
}
