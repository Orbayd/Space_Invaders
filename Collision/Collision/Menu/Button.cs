using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision
{
    public enum ButtonType 
    { 
        SinglePlayer,
        MultiPlayer,
        none,
    
    }
   public  class Button
   
   {
       private string name;
       private Vector2 position;
       private float scale;
       private ButtonType type;
       private bool isSelected;
       private SpriteFont font;
       private SpriteBatch spriteBatch;
       private Color color;
       public Button() 
       { 
           type = ButtonType.none; isSelected = false;
           color = Color.White;
           scale = 1;
           LoadFont();
       }
       public Button(ButtonType bt)
       {   
           type = bt; isSelected = false;
           color = Color.White;
           scale = 1;
           LoadFont();
       }

      
     
       public void Update()
       {
        
           if (isSelected == true) 
           {
               if (type == ButtonType.SinglePlayer)
               {
                 //  MainMenu.Destroy();
                   Game1.GameInstance.gamestate = GameState.Player1;
                 
               }

               else if (type == ButtonType.MultiPlayer)
               {
                   DeSelect();
                   Game1.GameInstance.gamestate = GameState.Player2;
                   
               }

               DeSelect();
           }
           this.isSelected = false;
       
       }
       public void Draw()
       {

           Vector2 origin = new Vector2(font.MeasureString(GetName()).X/2,font.MeasureString(GetName()).Y/2);
           Game1.GameInstance.spriteBatch.DrawString(font, GetName(), GetPosition(),color,0,origin,GetScale(),SpriteEffects.None,1);
       
       }
       private void LoadFont()
       {
           spriteBatch = new SpriteBatch(Game1.GameInstance.GraphicsDevice);
           font = Game1.GameInstance.Content.Load<SpriteFont>("Calibri");
       }
       public void SetName(string s) { this.name = s; }
       public void SetPosition(int x, int y) { this.position = new Vector2(x, y); }
       public void SetPosition(Vector2 v) { this.position = v; }
       public void SetColor(Color color) { this.color = color; }
       public Color GetColor() { return color; }
       public Vector2 GetPosition() { return position; }
       public float GetScale() { return scale; }
       public void SetScale(float s) { this.scale = s; }
       public string GetName() { return name; }
       public void Select() { isSelected = true;}
       public void DeSelect() { isSelected = false; }
       public bool Isselected() { return isSelected; }
   
   }
}
