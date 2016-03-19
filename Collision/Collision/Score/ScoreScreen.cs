using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision
{
    public class ScoreScreen
    {
        private SpriteBatch spritebatch;
        private SpriteFont font;
        private static ScoreScreen instance;
        public static ScoreScreen Instance() 
        {
            if (instance == null) { instance = new ScoreScreen(); }
            return instance;
        
        }
        public void Load()
        {
            spritebatch = new SpriteBatch(Game1.GameInstance.GraphicsDevice);
            font = Game1.GameInstance.Content.Load<SpriteFont>("Calibri");
        }
        public void Update() { }

        public void Draw()
        {
            spritebatch = Game1.GameInstance.spriteBatch;

            spritebatch.DrawString(font,"SCORE" +"<"+ScoreManager.Instance().GetScore()+">",new Vector2(50,50),Color.White);
            spritebatch.DrawString(font,"HIGH SCORE"+"<"+ScoreManager.Instance().GetHighScore()+">",new Vector2(200,50),Color.White);
            spritebatch.DrawString(font ,"<"+Player.Instance().GetLevel().ToString()+">",new Vector2(500,50),Color.White);
            spritebatch.DrawString(font,"<LIFE>"+"= "+"<" + Ship.Instance().GetLife().ToString() + ">", new Vector2(650, 50), Color.White);
        
        }
    }
}
