using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Collision
{
    public enum GameState 
    {   MainMenu,
        Player1,
        Player2,
        GameOver
    }


    public class MainMenu 
    {
        SpriteFont font;
        private SpriteBatch spriteBatch;
        private static MainMenu instance;
        private LinkList buttonlist; InputManager input;
        public static MainMenu Instance()
        {
            if (instance == null) instance = new MainMenu();
            return instance;
        
        }
       public static  void Destroy()
       { 
           instance = null;
       }



        public  void Initialize()
        {

            buttonlist = new LinkList();
            UnUpdateable.Instance();
        }
       public  void LoadContent()
        {


            UnUpdateable.Instance().LoadContent();
            spriteBatch = new SpriteBatch(Game1.GameInstance.GraphicsDevice);
            font =Game1.GameInstance.Content.Load<SpriteFont>("Calibri");
            
            Button Sp = new Button(ButtonType.SinglePlayer);
            Sp.SetName("SinglePlayer");
            Sp.SetPosition(new Vector2(375,550));
            Button Mp = new Button(ButtonType.MultiPlayer);
            Mp.SetName("MultiPlayer");
            Mp.SetPosition(new Vector2(375,600));
            buttonlist = new LinkList();
            buttonlist.AddtoBegining(Mp);
            buttonlist.AddtoBegining(Sp);
           
         input = InputManager.Instance();
        }
        public  void UnloadContent()
        {
           
        }
        public void Update(GameTime gameTime)
        {
            for (Node k = buttonlist.head; k != null; k = k.next) { ((Button)k.data).DeSelect(); }
           
               
                input.RunInputCheck();
                for (Node i = buttonlist.head; i != null; i = i.next)
                {
                    ((Button)i.data).Update();


                }
            
        }
        public  void Draw(GameTime gameTime)
        {   
            if (Game1.GameInstance.gamestate == GameState.MainMenu)
            {
                for (Node i = buttonlist.head; i != null; i = i.next)
                {
                    ((Button)i.data).Draw();

                }
                UnUpdateable.Instance().Draw();
            }
        }
        public LinkList getButtonList() 
        {
            return buttonlist;
        
        }
     
    }
}
