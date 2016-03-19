using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
   public class Super:GameObject
    {
      

        private static Super instance;
        private int oldstate;
        public static Super Instance()
        {

            if (instance == null) 
               instance = new Super(); 
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
        private Super()
        { 
            this.colObj = new CollisionObject();
            SpriteManager.Instance().AddCOL(this.colObj);
            type = GameObjectType.Super;
           

        }
        public override void Update()
        {
            checkSound();
            this.colObj.SetCoordinates( CalculateBorders());
           // Rectangle rec = Rectangle.Union(topLeftAlien.GetCol().GetCoordinates(), botRightAlien.GetCol().GetCoordinates());
           // this.colObj.SetCoordinates(Rectangle.Union(botLeftAlien.GetCol().GetCoordinates(), rec));
        }



        public Rectangle CalculateBorders()
        {
         
            Rectangle superborders = new Rectangle(0,0,0,0);
            Node k = GroupManager.Instance().GetLinkList(ColType.Column).head;
          
            if (k == null) { Destroy(); }
            else
            {
                superborders = ((Group)k.data).CalculateBorders();
                if (k.next != null)
                {
                    for (Node i = k.next; i != null; i = i.next)
                    {
                        Rectangle xy = ((Group)i.data).CalculateBorders();


                        superborders = Rectangle.Union(superborders, xy);
                    }
                }
            }
            return superborders; 
           
           

        }

        public void Destroy()
        {
            if (instance != null)
            {
                SoundManager.Instance().Pause(this,CueType.AllienQue);
                SpriteManager.Instance().RemoveCol(this.colObj);
                instance = null;
               
            }
        }

        public override CollisionObject GetCol()
        {
            return this.colObj;
        }
        public override Sprite GetSprite()
        {
            return this.sprite;
        }
        public override void VisitWall(Wall w)
        {
            Console.WriteLine("Collided with Super");
            reactionToSuper(this, w);
        }
        public override void VisitShield(Shield sh, CollisionObject col, Group g)
        {
            reactionToSuper(sh, col, g);
            
        }
        public void Accept(GameObject other)
        {
            Console.Write("[Super] ");

            other.VisitSuper(this);
        }
        public void reactionToSuper(Super s, Wall w)
        {
        }
        public void reactionToSuper(Shield sh, CollisionObject col, Group g)
        {
            int x = col.GetCoordinates().X;
            int y = col.GetCoordinates().Y;
            int width = col.GetCoordinates().Width;
            int height = col.GetCoordinates().Height;
            col.Destroy(col);
            g.RemoveFromGroup(col);
            Rec rec = new Rec(g.GetCoordinates().X, g.GetCoordinates().Y, g.GetCoordinates().Width + 3, g.GetCoordinates().Height + 2);
            sh.RemoveGroup(g);
        }

        private void checkSound()
        {
            int AllienCount = Player.Instance().GetAlliensList().Count;
            Animation a = new Animation();
            int newstate = AllienCount;
            if(oldstate!=newstate)
            {
                if (AllienCount == 55)
                {
                    TimerManager.Instance().RemoveTimeEvent(Super.Instance());
                    TimerManager.Instance().AddTimeEvent(this, 2, a.AllienSound);

                }
                else if (AllienCount == 25)
                {
                    TimerManager.Instance().RemoveTimeEvent(Super.Instance());
                    TimerManager.Instance().AddTimeEvent(this, 1, a.FasterAllienSound);
                }

                else if (AllienCount == 12)
                {
                    TimerManager.Instance().RemoveTimeEvent(Super.Instance());
                    TimerManager.Instance().AddTimeEvent(this, 0.5, a.FasterAllienSound);
                }
            }
            oldstate = newstate;
            



        }
       
    
    }
}
