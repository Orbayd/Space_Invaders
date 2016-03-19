using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Collision
{
   public class SoundManager
    {

        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;
        AudioCategory musicCategory;

        
       private static SoundManager instance;
       public static SoundManager Instance() 
       {
           if (instance == null) instance = new SoundManager();
           return instance;
       
       }

       public void Initialize()
       {
            audioEngine = new AudioEngine(@"Content\SpaceInvaders.xgs");
            waveBank = new WaveBank(audioEngine, @"Content\Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, @"Content\Sound Bank.xsb");

       }

       public void Play(CueType type)
       {
           Sound sound = new Sound(type);
           
           sound.Play();
       
       }

       public void Resume(GameObject o, CueType type)
       {
           Sound sound = new Sound(type);

          
           sound.Resume();
       }
       public void Pause(GameObject o, CueType type)
       {
           Sound sound = new Sound(type);


           sound.Pause(o);
       }
       public SoundBank GetSoundBank() { return soundBank; }
    }
}
