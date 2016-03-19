using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
namespace Collision
{
    public enum CueType 
    {   AllienQue,
        ShootQue,
        AllienKillQue,
        UFOQue,
        ExplosionQue,
        FasterAllienQue,
      FastestAllienQue
       
        
    
    }
   
   public  class Sound
    { 
       
       private CueType  type;
       private SoundBank soundBank;
       private Cue cue;
       
       private Cue[] list;
       private LinkList CueList;
       public Sound(CueType T) { this.type = T; this.soundBank = SoundManager.Instance().GetSoundBank(); cue = null; Create(); }
       
       
       public void Create()
       {
           if (type == CueType.AllienKillQue) { cue = soundBank.GetCue("AllienKillQue"); }

           else if (type == CueType.AllienQue)
           {


               cue = soundBank.GetCue("AllienQue");
           }


           else if (type == CueType.FasterAllienQue) { cue = soundBank.GetCue("FasterAllienQue"); }
           else if (type == CueType.FastestAllienQue) { cue = soundBank.GetCue("FastestAllienQue"); }
           else if (type == CueType.ShootQue) { cue = soundBank.GetCue("ShootQue"); }

           else if (type == CueType.UFOQue) {cue = soundBank.GetCue("UFOQue"); }

           else if(type==CueType.ExplosionQue){cue = soundBank.GetCue("ExplosionQue"); }

           
       }
       public void Play() { cue.Play(); }
       public void Resume()
       {
          
           
     
       }
       
           

       public void Pause(GameObject o) { TimerManager.Instance().RemoveTimeEvent(o); }
    }

   
}
