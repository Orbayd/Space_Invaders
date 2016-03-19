using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{
  public delegate void TimerEvent() ;
  public class Timer
    {
       
        
            private double interval;
            private TimerEvent timerevent;
            private GameTime gametime;
            private GameObject obj;
           public double timeRemaning;


            public Timer(double interval, TimerEvent timerevent)
            {
                this.interval = interval;
                this.timerevent = timerevent;


            }
            public Timer(GameObject o,double interval, TimerEvent timerevent)
            {
                this.obj = o;
                this.interval = interval;
                this.timerevent = timerevent;


            }
         

            public void Update(GameTime gametime)
            {
                this.gametime = gametime;
                
                    timeRemaning -= gametime.ElapsedGameTime.TotalSeconds;

                    if (timeRemaning <= -0)
                    {

                        timerevent();
                        timeRemaning = interval;
                    }
                


            }


            public GameObject GetAllien()
            {
                return this.obj;

            }

        }

    
}
