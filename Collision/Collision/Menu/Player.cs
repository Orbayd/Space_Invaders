using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Collision
{  
   public class Player
   {
       private SpriteBatch spriteBatch;
       private static Player instance;
       //private Allien a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13;
       //private Column c1, c2, c3, c4, c5;
       //private Group columns, colum1, colum2, colum3, colum4, colum5;
       private LinkList AllienList = new LinkList();
       private Level level;
       public static Player Instance()
       {
           if (instance == null) instance = new Player();
           return instance;
       
       }
       public static void Destroy() { instance = null; }


       public void Load() {
            level = Level.Level1;
           spriteBatch = new SpriteBatch(Game1.GameInstance.GraphicsDevice);
            #region 
           
           
            Texture.Instance();
            
            //SpriteManager sm = SpriteManager.Instance();
            //GameObjectMan gm = GameObjectMan.Instance();
          
            
         
            //a1 = new Allien(AllienType.Jellyfish);
            //a1.SetFrame(15);
            //a1.SetPosition(100, 100);
            //a2 = new Allien(AllienType.Jellyfish);
            //a2.SetFrame(16);
            //a2.SetPosition(200, 100);
            //a3 = new Allien(AllienType.Jellyfish);
            //a3.SetFrame(15);
            //a3.SetPosition(200, 150);
            //a4 = new Allien(AllienType.Jellyfish);
            //a4.SetFrame(16);
            //a4.SetPosition(250, 100);
            //a5 = new Allien(AllienType.Jellyfish);
            //a5.SetFrame(17);
            //a5.SetPosition(250, 150);
            //a6 = new Allien(AllienType.Jellyfish);
            //a6.SetFrame(15);
            //a6.SetPosition(100, 150);
            //a7 = new Allien(AllienType.Jellyfish);
            //a7.SetFrame(17);
            //a7.SetPosition(50, 100);
            //a8 = new Allien(AllienType.Jellyfish);
            //a8.SetFrame(17);
            //a8.SetPosition(50, 150);
            //a9 = new Allien(AllienType.Jellyfish);
            //a9.SetFrame(17);
            //a9.SetPosition(100, 200);
            //a10 = new Allien(AllienType.Jellyfish);
            //a10.SetFrame(17);
            //a10.SetPosition(200, 200);
            //a11 = new Allien(AllienType.Jellyfish);
            //a11.SetFrame(17);
            //a11.SetPosition(250, 200);
            //a13 = new Allien(AllienType.Jellyfish);
            //a13.SetFrame(17);
            //a13.SetPosition(150, 150);
            //a12 = new Allien(AllienType.Jellyfish);
            //a12.SetFrame(17);
            //a12.SetPosition(150, 100);

            //AllienList.AddtoBegining(a1);
            //AllienList.AddtoBegining(a2);
            //AllienList.AddtoBegining(a3);
            //AllienList.AddtoBegining(a4);
            //AllienList.AddtoBegining(a5);
            //AllienList.AddtoBegining(a6);

            //AllienList.AddtoBegining(a7);
            //AllienList.AddtoBegining(a8);
            //AllienList.AddtoBegining(a9);
            //AllienList.AddtoBegining(a10);
            //AllienList.AddtoBegining(a11);
            //AllienList.AddtoBegining(a12);
            //AllienList.AddtoBegining(a13);

            #region
            //colum5 = new Group(ColType.Column);
            //colum5.AddToGroup(a12);
            //colum5.AddToGroup(a13);

            //colum4 = new Group(ColType.Column);
            //colum4.AddToGroup(a7);
            //colum4.AddToGroup(a8);

            // colum3 = new Group(ColType.Column);
            //colum3.AddToGroup(a1);
            //colum3.AddToGroup(a6);
            //colum3.AddToGroup(a9);
            // colum1 = new Group(ColType.Column);
            //colum1.AddToGroup(a2);
            //colum1.AddToGroup(a3);
            //colum1.AddToGroup(a10);
            //colum2 = new Group(ColType.Column);
            //colum2.AddToGroup(a4);
            //colum2.AddToGroup(a5);
            //colum2.AddToGroup(a11);
          
         

            // c3 = new Column(colum3);
            // c4 = new Column(colum4);
            // c1 = new Column(colum1);
            // c2 = new Column(colum2);
           
            // c5 = new Column(colum5);
////         
//            GroupManager g = GroupManager.Instance();
//    //       
//             g.AddtoList(colum1,ColType.Column);
//             g.AddtoList(colum2,ColType.Column);
//             g.AddtoList(colum3,ColType.Column);
//             g.AddtoList(colum4, ColType.Column);
//             g.AddtoList(colum5, ColType.Column);
           
          
           
            //gm.add_Object(a1);
            //gm.add_Object(a2);
            //gm.add_Object(a3);
            //gm.add_Object(a4);
            //gm.add_Object(a5);
            //gm.add_Object(a6);
            //gm.add_Object(a7);
            //gm.add_Object(a8);
            //gm.add_Object(a9);
            //gm.add_Object(a10);
            //gm.add_Object(a11);
            //gm.add_Object(a13);
            //gm.add_Object(a12);

            //gm.add_Object(c1);
            //gm.add_Object(c2);
            //gm.add_Object(c3);
            //gm.add_Object(c4);
            //gm.add_Object(c5);
            #endregion
            //Wall wall = Wall.Instance();
            //gm.add_Object(wall);



           
          
            #endregion
            #region 

            //Shield shield = new Shield(200,300,3,3);
            //Shield shield2 = new Shield(400,300,3,3);
            //Shield shield3 = new Shield(600,300,3,3);

            //Group Shields = new Group(ColType.Shield);
            //Shields.AddToGroup(shield);
            //Shields.AddToGroup(shield2);
            //Shields.AddToGroup(shield3);
            
            //columns = new Group(ColType.Column);
            //columns.AddToGroup(c1);
            //columns.AddToGroup(c2);
            //columns.AddToGroup(c3);
            //columns.AddToGroup(c4);
            //columns.AddToGroup(c5);

           

            //Group wall2 = new Group(ColType.Wall);
            //wall2.AddToGroup(wall);

           
          

            #endregion
            #region 
           // Bomb b1 = new Bomb();
           // Bomb b2 = new Bomb();
           //// Bomb b3 = new Bomb();
           // Group bombgroup = new Group(ColType.Bomb);
           // bombgroup.AddToGroup(b1);
           // bombgroup.AddToGroup(b2);
           // //bombgroup.AddToGroup(b3);

            //Animation ani = new Animation(bombgroup);
           // TimerManager.Instance().AddTimeEvent(10, ani.CreateBomb);
            //CollisionPair misslevsShield = new CollisionPair(Shields, PairType.ShieldvsMissle);
            //CollisionPair misslevsAllien = new CollisionPair(columns, PairType.AlienvsAll);
            //CollisionPair shieldvsSuper = new CollisionPair(Shields, PairType.ShieldvsMissle);

            //CollisionPair BombvsShield = new CollisionPair(bombgroup, Shields, PairType.ShieldVsBomb);
            //CollisionPair BombvsShip = new CollisionPair(bombgroup, PairType.BombVsShip_Missle);
            //CollisionPair BombvsMissle = new CollisionPair(bombgroup, PairType.BombVsShip_Missle);
           
            //CollisionPairMan.Instance().Add_to_PairList(BombvsShield);
            //CollisionPairMan.Instance().Add_to_PairList(misslevsShield);
            //CollisionPairMan.Instance().Add_to_PairList(misslevsAllien);
            //CollisionPairMan.Instance().Add_to_PairList(BombvsMissle);
            //CollisionPairMan.Instance().Add_to_PairList(BombvsShip);
            //CollisionPairMan.Instance().Add_to_PairList(shieldvsSuper);
           //
           //Animation ani2 = new Animation();
          //  ani2.startufo();
        

            Data.Instance().Load();

          //  UfO.Instance().Create();
           
         //   Super.Instance();
            ScoreScreen.Instance().Load();
            FileManager.Instance().ReadFile();
            Ship.Create();
            #endregion
       }
      
       
       
       
       public void Reset()
       {
           SpriteManager.Instance().Reset();
           GameObjectMan.Instance().Reset();
           GroupManager.Instance().Reset();
           CollisionPairMan.Instance().Reset();
           ScoreManager.Instance().Reset();
           FileManager.Instance().WriteFile();
          
           Load();
       }
       public LinkList GetAlliensList() { return AllienList; }
       public void SetLevel(Level l) {level=l; }
       public Level GetLevel() { return level; }
       public void RemoveFromAllienList(Allien a) { AllienList.Remove(a); }
       public void Update(GameTime gameTime)
       {
           if (Game1.GameInstance.gamestate == GameState.Player1)
           {
               TimerManager.Instance().Update(gameTime);
               GameObjectMan.Instance().update(gameTime);
               CollisionPairMan.Instance().runCollisionCheck();
               InputManager.Instance().RunInputCheck();
               LevelManager.Instance().Update();
           }
       }

       public void Draw(GameTime gameTime)
       {


           if (Game1.GameInstance.gamestate == GameState.Player1)
           {

               SpriteManager.Instance().Draw();
               ScoreScreen.Instance().Draw();
           }

           
       }
    }
}
