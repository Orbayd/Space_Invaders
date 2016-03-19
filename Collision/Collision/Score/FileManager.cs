using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Collision
{
   public  class FileManager
   {
       private FileManager() { }
       private static FileManager instance;
       public static FileManager Instance() 
       {
           if (instance == null) instance = new FileManager();
           return instance;
       
       }

       public void ReadFile()
       {
           string path = @"Score.txt";
           if (!File.Exists(path))
           {
               // Create a file to write to. 
               using (StreamWriter sw = File.CreateText(path))
               {
                  
                 
               }
           }

           // Open the file to read from. 
           using (StreamReader sr = File.OpenText(path))
           {
               string s = "";
               while ((s = sr.ReadLine()) != null)
               {
                   int score = Convert.ToInt16(s);
                   ScoreManager.Instance().SetHighScore(score);
               }
           }
       
       }
       public void WriteFile()
       {
           string text = ScoreManager.Instance().GetHighScore().ToString();
           // WriteAllText creates a file, writes the specified string to the file, 
           // and then closes the file.
           System.IO.File.WriteAllText(@"Score.txt", text);
       }
   }
}
