using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Collision
{ public enum PairType
  {
    AlienvsAll,
    ShieldvsAll,
    ShieldvsMissle,
    ShieldVsBomb,
    BombVsShip_Missle
  }
    class CollisionPair
    {
 
        Group ColA;
        Group ColB;
        PairType type;
        public CollisionPair() { }
        public CollisionPair(Group _grp1, Group _grp2,PairType type)
        {
            ColA = _grp1; 
            ColB = _grp2;
            this.type = type;
        }
        public CollisionPair(Group _grp1, PairType type) 
        {
            ColA = _grp1;
            ColB = null;
           this.type = type;
        }



     public void checkAlienVsWall()
        {
            if (Super.IsAlive())
            {
                GameObject super = Super.Instance();
                GameObject wall = Wall.Instance();
                bool flag = false;
                flag = wallcollision(super.GetCol());

                if (flag == true)
                {
                    ((Super)super).Accept(wall);
                    flag = false;

                }
            }
        }
     public void checkMissleVsWall() 
        {
          if(Missle.IsAlive())
          {
            GameObject wall = Wall.Instance();
            GameObject missle = Missle.Instance();
            bool flag = false ;

            flag = wallcollision(missle.GetCol());
            if (flag == true) 
            {
                ((Missle)missle).Accept(wall);
                flag = false;
            }
        }
     }
  
     public void checkMissleVsAllien()
     {
         if (Missle.IsAlive())
         {
             GameObject missle = Missle.Instance();


             bool flag = false;
             bool superflag = checkMissleVsSuper();
             if (superflag == true)
             {
                 for (Node i = ColA.GetList().head; i != null; i = i.next)
                 {
                     flag = collision(missle.GetCol(), (((GameObject)i.data).GetCol()));
                     if (flag == true)
                     {
                         //((Allien)allien).Accept(missle);
                         checkMissleVsAllien2(i);

                     }
                 }
             }

         }
     }
     public void checkMissleVsShield() 
        {

            if (Missle.IsAlive())
            {
                GameObject missle = Missle.Instance();

                for (Node i = ColA.GetList().head; i != null; i = i.next)
                {
                    SuperShieldvsMissle(((Shield)i.data).GetSuper());


                }
            }
        
        
        }
     public void checkBombsvsSuperShield() 
     {
        // Node bomb = ColA.GetList().head;
       //  Node shield = 
         bool flag;
         for ( Node bomb = ColA.GetList().head; bomb  !=null; bomb = bomb.next) 
         {
             for (Node shield=ColB.GetList().head; shield != null; shield = shield.next) 
             {
                 flag = collision(((Bomb)bomb.data).GetCol(), ((Shield)shield.data).GetSuper());
                 if (flag == true)
                 {

                     checkBombsvsShield(bomb, shield);
                 }
             
             }
         
         
         
         }
             
     
     }
     public void checkBombvsShip()
     {
         bool flag;
         if (Ship.IsAlive())
         {
             GameObject ship = Ship.GetInstance();
             for (Node bomb = ColA.GetList().head; bomb != null; bomb = bomb.next)
             {
                 flag = collision(((Bomb)bomb.data).GetCol(), ship.GetCol());
                 if (flag == true)
                 {
                     ((Bomb)bomb.data).Accept(ship);
                     break;

                 }
             }

         }
     }
     public void checkBombsvsMissle()
     {
         bool flag;
         if (Missle.IsAlive())
         {
             GameObject missle = Missle.Instance();
             for (Node bomb = ColA.GetList().head; bomb != null; bomb = bomb.next)
             {
                 flag = collision(((Bomb)bomb.data).GetCol(), missle.GetCol());
                 if (flag == true)
                 {
                     ((Bomb)bomb.data).Accept(missle);

                 }
             }
         }
     
     }
     public void checkShipvsSuper() 
     {   
          if (Super.IsAlive()&& Ship.IsAlive())
            {
                GameObject super = Super.Instance();
                GameObject ship = Ship.GetInstance();
                bool flag = false;

                flag = collision(super.GetCol(),ship.GetCol());
                if (flag == true)
                {
                    ((Super)super).Accept(ship);
                  
                }
               

            }
          
        }
     public void checkSupervsShield()
     {
         if (Super.IsAlive())
         {
             GameObject super = Super.Instance();

             for (Node i = ColA.GetList().head; i != null; i = i.next)
             {
                
                 check_Super_vs_ShieldSuper(((Shield)i.data).GetSuper());

             }
         }
     }

     public void checkUFOvsMissle()
     {
         if (Missle.IsAlive() && UfO.IsAlive())
         {
             GameObject ufo = UfO.Instance();
             GameObject missle = Missle.Instance();
             bool flag = false;

             flag = collision(missle.GetCol(),ufo.GetCol());
             if (flag == true)
             {
                 ((Missle)missle).Accept(ufo);
                 flag = false;
             }
         }
     }
     public void checkUFOvsWall()
     {
         if ( UfO.IsAlive())
         {
             GameObject ufo = UfO.Instance();
             GameObject wall =Wall.Instance();
             bool flag = false;

             flag = wallcollision( ufo.GetCol());
             if (flag == true)
             {
                 ((Wall)wall).Accept(ufo);
                 flag = false;
             }
         }
     }

    private void check_Super_vs_ShieldSuper(CollisionObject col)
     {
         if (Super.IsAlive())
         {
             bool flag = false;
             GameObject super = Super.Instance();
             for (Node i = ColA.GetList().head; i != null; i = i.next)
             {
                 flag = collision(super.GetCol(), ((Shield)i.data).GetSuper());
                 if (flag == true)
                 {
                     ColumShieldvsSuper(i);

                 }


             }

         }
    }
    private void ColumShieldvsSuper(Node i)
    {
        if (Super.IsAlive())
        {
            bool flag = false;
            GameObject super = Super.Instance();
            for (Node k = ((Shield)i.data).GetColGroup().GetList().head; k != null; k = k.next)
            {
                for (Node j = ((Group)k.data).GetList().head; j != null; j = j.next)
                {

                    flag = collision(super.GetCol(), ((CollisionObject)j.data));
                    if (flag == true)
                    {
                        ((Shield)i.data).Accept((Super)super, ((CollisionObject)j.data), ((Group)k.data));

                    }
                }

            }
        }
    }
    private void checkMissleVsAllien2(Node i)
     {
         if (Missle.IsAlive())
         {
             bool flag = false;
             GameObject missle = Missle.Instance();
             GameObject alien;
             //Node AllienGroup = ((Column)ColA.GetList().head.data).getgrouplist().head;
             Node c = ((Column)i.data).getgrouplist().head;
             // GameObject alien = ((GameObject)c.data);
             for (; c != null; c = c.next)
             {
                 alien = ((GameObject)c.data);
                 flag = collision(missle.GetCol(), ((GameObject)c.data).GetCol());
                 if (flag == true)
                 {
                     ((Missle)missle).Accept((Allien)alien);


                 }


             }
         }

     }
    private void checkBombsvsShield(Node bomb, Node shield)
     {
         bool flag;
         for (Node k = ((Shield)shield.data).GetColGroup().GetList().head; k != null; k = k.next) 
         {
             for (Node j = ((Group)k.data).GetList().head; j != null; j = j.next)
             {

                 flag = collision(((Bomb)bomb.data).GetCol(), ((CollisionObject)j.data));
                 if (flag == true)
                 {
                     ((Shield)shield.data).Accept((Bomb)bomb.data, ((CollisionObject)j.data), ((Group)k.data));

                 }
             }
         
         
         }
     
     
     }
    private void SuperShieldvsMissle(CollisionObject col)
        {  if(Missle.IsAlive() &&Super.IsAlive())
          {
            bool flag = false;
            GameObject missle = Missle.Instance();
            for (Node i = ColA.GetList().head; i != null; i = i.next)
            {
              flag= collision(missle.GetCol(), ((Shield)i.data).GetSuper());
              if (flag == true) 
              {
                  ColumShieldvsMissle(i);
              
              }
            
            
            }
        
        }
      }
    private void ColumShieldvsMissle(Node i)
        {
            if (Missle.IsAlive())
            {
                bool flag = false;
                GameObject missle = Missle.Instance();
                for (Node k = ((Shield)i.data).GetColGroup().GetList().head; k != null; k = k.next)
                {
                    for (Node j = ((Group)k.data).GetList().head; j != null; j = j.next)
                    {

                        flag = collision(missle.GetCol(), ((CollisionObject)j.data));
                        if (flag == true)
                        {
                            ((Shield)i.data).Accept((Missle)missle, ((CollisionObject)j.data), ((Group)k.data));

                        }
                    }

                }
            }
        
        }
    private bool checkMissleVsSuper()
        {
            if (Missle.IsAlive()&&Super.IsAlive())
            {
                GameObject super = Super.Instance();
                GameObject missle = Missle.Instance();
                bool flag = false;

                flag = collision(super.GetCol(), missle.GetCol());
                if (flag == true)
                {
                    ((Missle)missle).Accept(super);
                    return true;
                }
                return false;

            }
            return false;
        }
    private bool collision(CollisionObject obj1, CollisionObject obj2)
        {
            if (obj1 != null && obj2 != null)
            {
                Rectangle recobj1 = obj1.GetCoordinates();
                Rectangle recobj2 = obj2.GetCoordinates();
                if ((recobj1.Left <= recobj2.Right && recobj1.Right >= recobj2.Left) || (recobj1.Right >= recobj2.Left && recobj1.Left <= recobj2.Right))
                {
                    if (recobj1.Top <= recobj2.Bottom && recobj1.Bottom >= recobj2.Top)
                    {
                        // BOOM! We have a collision
                        return true;
                    }
                    return false;
                }
                 return false;
            }

             return false;
               
        }
    private bool wallcollision(CollisionObject obj1) 
        {
            Rectangle recwall = Wall.Instance().GetCol().GetCoordinates();
            Rectangle recobj = obj1.GetCoordinates();
            if ((recwall.Left >= recobj.Left) || (recwall.Right <= recobj.Right) || (recwall.Top >= recobj.Top) || recwall.Bottom <= recobj.Bottom)
                return true;

            return false;
        }


    public PairType getType() { return type; }
    public void Run(PairType type) 
        {
             if(type.Equals(PairType.AlienvsAll))
             {
                 checkMissleVsAllien();
             }
            if(type.Equals(PairType.ShieldvsMissle)){checkMissleVsShield();checkSupervsShield();}
            if (type.Equals(PairType.ShieldVsBomb)) { checkBombsvsSuperShield(); }
            if (type.Equals(PairType.BombVsShip_Missle)){checkBombsvsMissle(); checkBombvsShip();}
        }
        
    }
}
