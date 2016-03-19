using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Collision
{
    public class Bomb:GameObject
    {   private bool isalive= true; 
        public Bomb()
        {
            this.sprite = new Sprite(SpriteType.Missle);
            this.sprite.SetFrame(24);
            sprite.SetSpeed(new Vector2(0, 0));
            sprite.SetColor(Color.Black);


            this.colObj = new CollisionObject(sprite);
            this.colObj.SetScale(new Point(10, 25));
            
            type = GameObjectType.Missle;

            AddtoManagers();
           
          
        }

        public void SetBomb()
        {
            //SetPosition();
            this.sprite.SetColor(Color.White);
            sprite.SetLayerDepth(0.9f);
            this.sprite.SetSpeed(new Vector2(0, 5));
        
          
           
        }
        public void Dead(Bomb b) 
        {
            b.isalive = false;
            b.sprite.SetPosition(new Vector2(0,0));
            b.sprite.SetSpeed(new Vector2(0, 0));
            b.sprite.SetColor(Color.Black);
            b.sprite.SetLayerDepth(0.7f);
        
        }
        public bool IsAlive() { return isalive; }
        public void AddtoManagers()
        {
            GameObjectMan.Instance().add_Object(this);
            SpriteManager.Instance().AddSprite(sprite);
            SpriteManager.Instance().AddCOL(colObj);
        }
        public override void Update() 
        {
            sprite.Update();
            colObj.Update();
        
        }
        public override CollisionObject GetCol()
        {
            return this.colObj;
        }
        public void Accept(GameObject other)
        {
            Console.Write("[Bomb] ");
            other.VisitBomb(this);


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
        public override void VisitShield(Shield sh, CollisionObject col, Group g)
        {
            Console.WriteLine("Collided with Bomb");
            reactiontoShield(this,sh,col,g);
        
        }
        public override void VisitShip(Ship ship)
        {
            Console.WriteLine("Collided with Bomb");
             base.VisitShip(ship);
        
        
         }
        public override void VisitMissle(Missle m)
        {
            Console.WriteLine("Collided with Bomb");
            base.VisitMissle(m);
        }

        private void reactiontoShield(Bomb b,Shield sh, CollisionObject col, Group g)
        {
            Dead(b);
            int x = col.GetCoordinates().X;
            int y = col.GetCoordinates().Y;
            int width = col.GetCoordinates().Width;
            int height = col.GetCoordinates().Height;
           
            if (g.GetList().Count == 2)
            {
                col.Destroy(col);

                g.RemoveFromGroup(col);
            }

            Exp ex = new Exp(x, y, 26);
            ex.SetFrame(26);
            ex.AddSprite();
            g.Age -= 1;

            if (g.Age == 0)
            {
                Rec rec = new Rec(g.GetCoordinates().X, g.GetCoordinates().Y, g.GetCoordinates().Width + 3, g.GetCoordinates().Height + 3);
                col.Destroy(col);
                g.RemoveFromGroup(col);
                sh.RemoveGroup(g);

            }
            if (sh.GetColGroup().GetList().Count == 0)
            {
                SpriteManager.Instance().RemoveSprite(sh.GetSprite());
                sh.RemoveSuper();
            
            }
        
        
        }
        public void SetPosition(Vector2 v) 
        {
            sprite.SetPosition(v);
        
        }
        //public void SetPosition()
        //{  
        //    Group[] sampe = calculatePosition();
        //    if (sampe[0] != null)
        //    {
        //        sprite.SetPosition(new Vector2(sampe[0].GetCoordinates().X, sampe[0].GetCoordinates().Bottom));
        //    }
        
        //}
        //private Group[] calculatePosition() 
        //{
        //  LinkList list =  GroupManager.Instance().GetLinkList(ColType.Column);
         
        //  int samplecount=3;
        //  Random rand = new Random();
        //  int k = 0;
        //    Group[] samples = new Group[samplecount];
        
        //    if (samplecount <= 0)
        //        throw new ArgumentOutOfRangeException("sampleCount");
        //  for (Node i = list.head; i != null; i = i.next)
        //  {
        //      if (k < samplecount)
        //      {
        //          samples[k] =((Group) i.data);
                     
        //      }
        //      else
        //      {
        //          int j = rand.Next() % k;
        //          if (j < samplecount)
        //              samples[j] = (Group)i.data;
        //      }
        //      k++;

          
          
        //  }

        //  return samples;
        
        //}
    }
}
