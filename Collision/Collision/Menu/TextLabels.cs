using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{
     public class TextLabel
      {
       private string name;
       private  Color color;
       private Vector2 position;
       private float scale;
       private SpriteFont font;
       private SpriteBatch spriteBatch;
       public TextLabel() { LoadFont(); this.scale = 1; this.color = Color.White; }
       public void SetString(string s) { name = s; }
       public void SetColor(Color color) { this.color = color;  }

    
       public void Draw()
       {
            //Vector2 origin = new Vector2(font.MeasureString(GetName()).X / 2, font.MeasureString(GetName()).Y / 2);
            Game1.GameInstance.spriteBatch.DrawString(font,GetName(), GetPosition(), color, 0, Vector2.Zero, GetScale(), SpriteEffects.None, 1);

        }
       public void SetName(string s) { this.name = s; }
       public void SetPosition(int x, int y) { this.position = new Vector2(x, y); }
       public void SetPosition(Vector2 v) { this.position = v; }
       private void LoadFont()
      {
          spriteBatch = new SpriteBatch(Game1.GameInstance.GraphicsDevice);
          font = Game1.GameInstance.Content.Load<SpriteFont>("Calibri");
      }
       public Color GetColor() { return color; }
       public Vector2 GetPosition() { return position; }
       public float GetScale() { return scale; }
       public void SetScale(float s) { this.scale = s; }
       public string GetName() { return name; }
  
    }
}
