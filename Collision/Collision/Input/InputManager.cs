using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace Collision
{
    public class InputManager
    {
        KeyboardState OldKeyInput;
        GamePadState OldGamepadState;
        Node i;
       
        private static InputManager instance;
        private InputManager()
        {
            SetInputState();
            SetButtonConfig();
          
         
        }

        public static InputManager Instance()
        {
            if (instance == null) instance = new InputManager();
            return instance;

        }
        private void SetInputState()
        {
            OldKeyInput = Keyboard.GetState();
            OldGamepadState = GamePad.GetState(PlayerIndex.One);
        }
        private void SetButtonConfig()
        {
            i = MainMenu.Instance().getButtonList().head;
            ((Button)i.data).SetColor(Color.Red);
            ((Button)i.data).SetScale(1.5f);
        }
        public void RunInputCheck()
        {
            keyboardinput();


        }
        private void keyboardinput()
        {

            GamePadState CurrentGamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState KeyInput = Keyboard.GetState();

            Ship ship = Ship.GetInstance();
           
                if ((KeyInput.IsKeyDown(Keys.Left))
                    || (CurrentGamePadState.DPad.Left == ButtonState.Pressed))
                {
                    if (Game1.GameInstance.gamestate == GameState.Player1)
                    {
                        if (Ship.Instance().GetIsAlive())
                        {
                            ship.Move(-5);
                        }
                    }


                }
                if ((KeyInput.IsKeyDown(Keys.Right))
                    || (CurrentGamePadState.DPad.Right) == ButtonState.Pressed)
                {
                    if (Game1.GameInstance.gamestate == GameState.Player1)
                    {
                        if (Ship.Instance().GetIsAlive())
                        {
                            ship.Move(+5);
                        }
                    }
                }
                if (KeyInput.IsKeyDown(Keys.Up) ||
                    (CurrentGamePadState.DPad.Up == ButtonState.Pressed))
                {
                    if (Game1.GameInstance.gamestate == GameState.Player1)
                    {
                        if (!Missle.IsAlive()&& Ship.IsAlive())
                        {
                            Missle missle = Missle.Instance();
                            Group mg = new Group(ColType.Missle);
                            mg.AddToGroup(missle);
                            GameObjectMan.Instance().add_Object(missle);
                        }
                    }

                    else if (Game1.GameInstance.gamestate == GameState.MainMenu)
                    {

                        if (i.prev != null)
                        {
                            ((Button)i.data).SetColor(Color.White);
                            ((Button)i.data).SetScale(1f);
                            i = i.prev;
                            ((Button)i.data).SetColor(Color.Red);
                            ((Button)i.data).SetScale(1.5f);
                           
                        }
                       
                    }

                }
                if ((KeyInput.IsKeyDown(Keys.Down) && !OldKeyInput.IsKeyDown(Keys.Down)) ||
                    (CurrentGamePadState.DPad.Down == ButtonState.Pressed && OldGamepadState.DPad.Down == ButtonState.Released))
                {
                    if (Game1.GameInstance.gamestate == GameState.Player1)
                    {
                        SpriteManager.Instance().SetLock();
                    }

                    else if (Game1.GameInstance.gamestate == GameState.MainMenu)
                    {

                        if (i.next != null)
                        {
                            ((Button)i.data).SetColor(Color.White);
                            ((Button)i.data).SetScale(1f);
                              i = i.next;
                           
                            ((Button)i.data).SetColor(Color.Blue);
                            ((Button)i.data).SetScale(1.5f);
                          
                        }
                          
                     }
                   }
                    if ((KeyInput.IsKeyDown(Keys.A)) ||
                        (CurrentGamePadState.Buttons.A == ButtonState.Pressed))
                    {

                        ((Button)i.data).Select();
                        



                    }
                    if ((KeyInput.IsKeyDown(Keys.B)) ||
                        (CurrentGamePadState.Buttons.B == ButtonState.Pressed))
                    {
                     

                    }
                    if ((KeyInput.IsKeyDown(Keys.X)) ||
                        (CurrentGamePadState.Buttons.X == ButtonState.Pressed))
                    {


                    }
                    if ((KeyInput.IsKeyDown(Keys.Y)) ||
                        (CurrentGamePadState.Buttons.Y == ButtonState.Pressed))
                    {



                    }
                    OldGamepadState = CurrentGamePadState;
                    OldKeyInput = KeyInput;




                
            }
        }
    
}
