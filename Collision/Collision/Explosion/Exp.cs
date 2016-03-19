using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
    public class Exp
    {
        private Sprite s;
        private int x, y,f;
        public Exp() { }
        public Exp(int x, int y,int f)
        {
            this.x = x; this.y = y; this.f = f;
            SetSprite();
        }

        public void SetSprite()
        {
            s = new Sprite(SpriteType.Shield);
            s.SetPosition(x, y); s.SetScale(0.30f); s.SetLayerDepth(0.85f);
            s.SetSpeed(new Vector2(0, 0)); s.SetColor(Color.Green);
            
           
        }
        public void SetFrame(int f) { s.SetFrame(f); Console.WriteLine("FrameChanged to"+ f); }
        public void ChangeFrame() { s.UpdateSprite(); }
        public void Remove() { SpriteManager.Instance().RemoveEx(s); }
        public void AddSprite() 
        {
            SpriteManager.Instance().AddEx(s); 

        
        
        }
    }
}
