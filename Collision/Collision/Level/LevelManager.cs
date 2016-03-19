using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Collision
{
    public enum Level 
    { 
        Level1,
        Level2,
        Level3,
    
    }
   public class LevelManager
   {
       private int oldstate;

       private static LevelManager instance;
       public static LevelManager Instance() 
       {
           if (instance == null) instance = new LevelManager();

           return instance;
       }
       public void Update() { 
           LevelCheck();
           CheckAlliens();
        
       }
      private void LevelCheck() 
       {   int AllienCount =Player.Instance().GetAlliensList().Count;
           if (AllienCount == 0)
           { 
               IncreaseDifficulty();
           }
       }
      private void CheckAlliens() 
       {  
           int AllienCount =Player.Instance().GetAlliensList().Count;
           int newstate = AllienCount;
           if  (AllienCount% 5==0 &&AllienCount!=55&& oldstate!=newstate) 
           {
               IncreasAllienSpeed(1.1f);
           }
           oldstate = newstate;
       
       }

       private void IncreaseDifficulty()
       {
           if (Player.Instance().GetLevel() == Level.Level1)
           {
               Player.Instance().Reset();
               Player.Instance().SetLevel(Level.Level2);
               IncreasAllienSpeed(2f);
           }
           else if (Player.Instance().GetLevel() == Level.Level2)
           {
               Player.Instance().Reset();
               IncreasAllienSpeed(3f);
               Player.Instance().SetLevel(Level.Level3);
              

           }
              
           else if (Player.Instance().GetLevel()==Level.Level3){

               Game1.GameInstance.gamestate = GameState.MainMenu;
               Player.Instance().Reset();}

       }
       private void IncreasAllienSpeed(float speed) 
       {
           for (Node i = Player.Instance().GetAlliensList().head; i != null; i = i.next)
           {
               ((Allien)i.data).GetSprite().SetSpeed(new Vector2(((Allien)i.data).GetSprite().GetSpeed().X * speed, ((Allien)i.data).GetSprite().GetSpeed().Y));

                
           }
       
       }

    
    }
}

