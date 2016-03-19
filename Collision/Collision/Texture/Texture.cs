using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Collision
{
    public class Texture
    {
        private Texture2D texture,ex;
        private static  Texture instance;
        public  Texture() 
        {
            this.texture =Game1.GameInstance.Content. Load<Texture2D>(@"Spaceinvaders");
            this.ex= Game1.GameInstance.Content.Load<Texture2D>(@"Ex");
           
        
        }
        public static Texture Instance()
        {
            if (instance == null)
                instance = new Texture();
            return instance;
        }
   
        public Texture2D GetTexture() 
        {
            return this.texture;
        
        }
        public Texture2D GetEx() { return this.ex; }
        public int GetWidth() 
        {
            return texture.Width;
        
        }
        public int GetHeight() 
        {
            return texture.Height;
           
        
        }
    }
}
