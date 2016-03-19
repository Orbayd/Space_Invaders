using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Collision
{
    public enum GameObjectType 
    { 
        Allien,Allien1,Allien2,Allien3,Missle,Wall,Super,Column,Ship
    
    }
       public abstract class GameObject
        {
           

            protected string name;
            protected Sprite sprite;
            protected CollisionObject colObj;
            protected GameObjectType type;

            public GameObject() { }

            public GameObject(Sprite s, CollisionObject col) { this.colObj = col; this.sprite = s; }

            public virtual void Update()
            {

            }
            public virtual void Update(GameTime GameTime) { }
            public virtual Sprite GetSprite() { return null; }
            public virtual CollisionObject GetCol() { return null; }
            public virtual void VisitAlien(Allien a)
            {
                Console.Write("Alien Visitor not implemented\n");
            }

            public virtual void VisitWall(Wall w)
            {
                Console.Write("Wall Visitor not implemented\n");
            }

            public virtual void VisitSuper(Super s)
            {
                Console.Write("Super Visitor not implemented\n");
            }

            public virtual void VisitMissle(Missle m)
            {
                Console.Write("Missle Visitor not implemented\n");
            
            
            }
            public virtual void VisitShield(Shield sh,CollisionObject col,Group g)
            {
                Console.Write("Shield Visitor not implemented\n");


            }
            public virtual void VisitShip(Ship ship)
            {
                Console.Write("Shield Visitor not implemented\n");


            }
            public virtual void VisitBomb(Bomb b)
            {
                Console.Write("Shield Visitor not implemented\n");


            }




        }
    }

