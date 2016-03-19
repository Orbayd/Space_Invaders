using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Collision
{
  public class TimerManager
    {
    
        private LinkList  TimerList= new LinkList();
        private TimerEvent timerevent;
        private double interval;
        private double timeRemaning;
        public GameTime gameTime;
        private GameObject obj;
       
        private AnimationType type;
        private Timer timer;
        private static  TimerManager instance;
        public static  TimerManager Instance() 
        {
            if (instance == null) { instance = new TimerManager(); }
            return instance;                              
        }
        public TimerManager() { }
        public void AddTimer(Timer t)
        { 
            TimerList.AddtoBegining(t); 
        }

        public void AddTimeEvent(double interval,TimerEvent timerevent)
        {
          
            this.interval = interval;
            this.timeRemaning = interval;
            this.timerevent = timerevent;
            this.type = AnimationType.none;
            TimerList.AddtoBegining(new Timer(interval,timerevent));
        }
        public void AddTimeEvent(GameObject obj,double interval, TimerEvent timerevent)
        {
            
            this.interval = interval;
            this.timeRemaning = interval;
            this.timerevent = timerevent;
            this.obj = obj;

            this.timer = new Timer(obj, interval, timerevent);
            TimerList.AddtoBegining(this.timer);
        }

        public void RemoveTimeEvent(GameObject a) 
        {
            for (Node i = TimerList.head; i != null; i = i.next)
            {
                if (((Timer)i.data).GetAllien() == a)
                {
                    TimerList.Remove(((Timer)i.data));

                }

            }
        
        }
        public void RemoveTimer(Timer t) { TimerList.Remove(t); }

        public void Update(GameTime gameTime) 
        {
           
          
            for(Node i=TimerList.head; i!=null;i=i.next)
            {
                ((Timer)i.data).Update(gameTime);
            
            
            }
        
        
        }
    }
    
}
