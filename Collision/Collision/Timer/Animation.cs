using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Collision
{
    public enum AnimationType 
    { 
        bomb,
        changeFrames,
        ChangeScale,
        none
    
    
    }
   public  class Animation

    {
       private GameObject obj;
       
       private Group Bombgroup;
      
       private AnimationType type;
       int count = 0;
     
        public Animation(GameObject s) { this.obj = s; type=AnimationType.none;}
        public Animation(Group g) { this.Bombgroup=g; type=AnimationType.none;}
        public Animation() { type=AnimationType.none;}

       public void DeadAllien() 
        {
            GameObjectMan.Instance().RemoveObject((Allien)obj);
            SpriteManager.Instance().RemoveSprite(((Allien)obj));
            TimerManager.Instance().RemoveTimeEvent((Allien)obj);
           
        }
      
       public void ChangeFrames()
       {
           Allien allien = (Allien)obj;
           int frame = allien.GetFrame();

           if (!allien.IsDead())
           {

               if (count == 0)
               {
                   frame = frame + 1;

                   allien.GetSprite().SetFrame(frame);

                   count++;
               }
               else
               {

                   frame -= 1;
                   allien.GetSprite().SetFrame(frame);

                   count--;
               }
           }
                
        }
       public void DeadShip()
       {   
           Ship.Instance().reset();
           TimerManager.Instance().RemoveTimeEvent(obj);
        
       
       }

       public void AllienSound() 
       { 
           SoundManager.Instance().Play(CueType.AllienQue);
       
       }
       public void FasterAllienSound()
       {
           SoundManager.Instance().Play(CueType.FasterAllienQue);

       }
       public void FastestAllienSound()
       {
           SoundManager.Instance().Play(CueType.FastestAllienQue);

       }

       public void CreateUFO()
       {
          
               UfO.Instance().GetSprite().SetPosition(new Vector2(50, 100));
               UfO.Instance().GetSprite().SetSpeed(new Vector2(4,0 ));
          //    TimerManager.Instance().AddTimeEvent(UfO.Instance(),-0, PlayUfo);
               SpriteManager.Instance().AddSprite(  UfO.Instance().GetSprite());
               SpriteManager.Instance().AddCOL(UfO.Instance().GetCol());
           
       }
       public void startufo() { if (!UfO.IsAlive()) { TimerManager.Instance().AddTimeEvent(UfO.Instance(), Random(), CreateUFO); } }
       public void DestroyUFO()
       {

           //UfO.Instance().Reset();
       
       }
     
       public void PlayUfo() { SoundManager.Instance().Play(CueType.UFOQue); }
     
    
       public void CreateBomb()
       {
           int k = 0;
           Group[] group = calculatePosition();
           for (Node i = Bombgroup.GetList().head; i != null; i = i.next)
           {

               if (Super.IsAlive())
               {

                   ((Bomb)i.data).SetBomb();
                   if (group[k] != null)
                   {
                       ((Bomb)i.data).SetPosition(new Vector2(group[k].GetCoordinates().X, group[k].GetCoordinates().Bottom));
                   }
               }
               k++;

           }



       }
       public Group[] calculatePosition()
       {
           LinkList list = GroupManager.Instance().GetLinkList(ColType.Column);

           int samplecount = 3;
           Random rand = new Random();
           int k = 0;
           Group[] samples = new Group[samplecount];

           if (samplecount <= 0)
               throw new ArgumentOutOfRangeException("sampleCount");
           for (Node i = list.head; i != null; i = i.next)
           {
               if (k < samplecount)
               {
                   samples[k] = ((Group)i.data);

               }
               else
               {
                   int j = rand.Next() % k;
                   if (j < samplecount)
                       samples[j] = (Group)i.data;
               }
               k++;



           }

           return samples;

       }
       private int Random()
        {
            Random rnd = new Random();
            int x = rnd.Next(8, 20);
            return x;

        }
      
      
    }
}
