using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collision
{
   public class ScoreManager
    {
       private static ScoreManager instance;
       private int Score;
       private int HighScore;
       ScoreManager() {  }
       public static ScoreManager Instance()
       {
           if (instance == null) instance = new ScoreManager();
           return instance;
       
       }

       public void AddtoScore(GameObject obj)
       {
           if (obj is Allien)
           {
               if (((Allien)obj).GetAllienType() == AllienType.Ant) { Score += 20; }
               else if (((Allien)obj).GetAllienType() == AllienType.Jellyfish) { Score += 10; }
               else if (((Allien)obj).GetAllienType() == AllienType.Squid) { Score += 40; }
           }
           if (obj is UfO)
                 Score += Random(); 
       
       }
       
       public void SetHighScore(int hscore) { HighScore = hscore; }
       public int GetHighScore() {return CompareHighScores(); }
       private int CompareHighScores()
       {
           if (Score > HighScore) { HighScore = Score; }
           return HighScore;
       
       }
       public void Reset() { Score = 0; }
       public int GetScore() { return Score; }
       private int Random() 
       {  
           Random rnd = new  Random();
           int i = rnd.Next(100, 1000);
           return i;
       
       }


    }
}
