using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
namespace Collision
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {   
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch{get;set;}
        public GameTime gameTime { get; set; }
        public GameState gamestate{get;set;}
        private static Game1 Game;
     

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
            //Changes the settings that you just applied
            graphics.ApplyChanges();
        
            Content.RootDirectory = "Content";
            Game = this;
           
        }
       
        public static Game1 GameInstance
        {
            get { return Game1.Game; }
        }
       
      
        protected override void Initialize()
        {
            gamestate = GameState.MainMenu;
            Player.Instance();
            SoundManager.Instance().Initialize();
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MainMenu.Instance().LoadContent();
            Player.Instance().Load();
        }

        
        protected override void UnloadContent()
        {
            
        }


        protected override void Update(GameTime gameTime)
        {
            if (gamestate == GameState.MainMenu) 
            {
                MainMenu.Instance().Update(gameTime); 
            }
            else if (gamestate == GameState.Player1)
            {
                Player.Instance().Update(gameTime);
            }

        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            if (gamestate == GameState.MainMenu)
            { 
                MainMenu.Instance().Draw(gameTime); 
            }
            else if (gamestate == GameState.Player1)
            {
            Player.Instance().Draw(gameTime);
            }
           
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
