using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collision
{
   public class Data
    {
       private int frame;
       private static Data instance;
       private Group Shields,bombgroup,columnGroup;
       public static Data Instance() {
           if (instance == null)instance = new Data();
           return instance;
       }
       public void Load ()
       {
           CreateAlliens();
           CreateShield();
           CreateWall();
           CreateBomb();
           CreateCollisionPairs();
           CreateUFO();
       }

       private void CreateAlliens()
       {
           int width = 0;
           int height = 0;
            columnGroup = new Group(ColType.Column);
           for (int i = 0; i < 11; i++)
           {
             
               Group alliengroup = new Group(ColType.Column);
               for (int k = 0; k < 5; k++)
               {
                   Allien Allien;
                   if (k < 1)
                   {
                       Allien = new Allien(AllienType.Squid);
                       Allien.SetPosition(100 + width, 150 + height);
                       Allien.SetFrame(2);
                   }
                   else if (k >= 1 && k < 3)
                   {
                       Allien = new Allien(AllienType.Ant);
                       Allien.SetPosition(100 + width, 150 + height);
                       Allien.SetFrame(0);
                      // Allien.GetSprite().SetScale(0.32f);
                   }
                   else
                   {
                       Allien = new Allien(AllienType.Jellyfish);
                       Allien.SetPosition(100 + width, 150 + height);
                       Allien.SetFrame(4);
                       //Allien.GetSprite().SetScale(0.35f);
                   
                   }
                  
                   
                   
                   height += 30;
                   GameObjectMan.Instance().add_Object(Allien);
                   Player.Instance().GetAlliensList().AddtoBegining(Allien);
                   alliengroup.AddToGroup(Allien);
               }
               Column column = new Column(alliengroup);
               columnGroup.AddToGroup(column);
               GameObjectMan.Instance().add_Object(column);
               GroupManager.Instance().AddtoList(alliengroup, ColType.Column);
               width += 50;
               height = 0;
           
           
           }
            
       
       
       
       }

       private void CreateUFO() {
           Animation ani2 = new Animation();
           TimerManager.Instance().AddTimeEvent(Rand(), ani2.CreateUFO);
       }
       private int Rand()
       {
        Random rnd = new Random();
       int a = rnd.Next(15,35);
       return a;
       }
       private void CreateWall()
       {
           Wall.Instance();
       
       }
       private void CreateShield() 
       {
           Shield shield = new Shield(50, 600, 3, 3);
           Shield shield2 = new Shield(250, 600, 3, 3);
           Shield shield3 = new Shield(450, 600, 3, 3);
           Shield shield4 = new Shield(650, 600, 3, 3);

           Shields = new Group(ColType.Shield);
           Shields.AddToGroup(shield);
           Shields.AddToGroup(shield2);
           Shields.AddToGroup(shield3);
           Shields.AddToGroup(shield4);
       
       
       }

       private void CreateBomb()
       {
           Bomb b1 = new Bomb();
           Bomb b2 = new Bomb();
           Bomb b3 = new Bomb();
           bombgroup = new Group(ColType.Bomb);
           bombgroup.AddToGroup(b1);
           bombgroup.AddToGroup(b2);
           bombgroup.AddToGroup(b3);
           Animation ani = new Animation(bombgroup);
           TimerManager.Instance().AddTimeEvent(3, ani.CreateBomb);
           
       }

       private void CreateCollisionPairs()
       {
         
            
           CollisionPair misslevsAllien = new CollisionPair(columnGroup, PairType.AlienvsAll);
           CollisionPair misslevsShield = new CollisionPair(Shields, PairType.ShieldvsMissle);
           CollisionPair shieldvsSuper = new CollisionPair(Shields, PairType.ShieldvsMissle);
       

           CollisionPair BombvsShield = new CollisionPair(bombgroup, Shields, PairType.ShieldVsBomb);
           CollisionPair BombvsShip = new CollisionPair(bombgroup, PairType.BombVsShip_Missle);
           CollisionPair BombvsMissle = new CollisionPair(bombgroup, PairType.BombVsShip_Missle);
           
            CollisionPairMan.Instance().Add_to_PairList(BombvsShield);
            CollisionPairMan.Instance().Add_to_PairList(misslevsShield);
            CollisionPairMan.Instance().Add_to_PairList(misslevsAllien);
            CollisionPairMan.Instance().Add_to_PairList(BombvsMissle);
            CollisionPairMan.Instance().Add_to_PairList(BombvsShip);
            CollisionPairMan.Instance().Add_to_PairList(shieldvsSuper);
       
       
       
       
       }
      
    }
}
