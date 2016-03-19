using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{
   public  class DrawManager
    {
       private SpriteBatch spritebatch;
       private static DrawManager instance;
       private LinkList DrawList = new LinkList();
       private DrawManager() {  }
       public static DrawManager Instance()
        {
            if (instance == null)
                instance = new DrawManager();
            return instance;
        }
       public void Add(object o) 
       {
           DrawList.AddtoBegining(o);
       
       }
       public void Draw()
       {
           spritebatch = Game1.GameInstance.spriteBatch;
           spritebatch.Begin();

           for (Node i = DrawList.head; i != null; i = i.next) 
           {
               if (i.data is Sprite)
               { 
                   ((Sprite)i.data).Draw();
                   
               }
               if (i.data is CollisionObject) 
               {
                   ((CollisionObject)i.data).Draw();
               }
               if (i.data is Particle) 
               {
                   ((Particle)i.data).Draw();
               }
           
           }
           spritebatch.End();

       }
   }
}
