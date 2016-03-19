using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{

    public class Group
    {
       
            private LinkList group;
            private ColType type;
            private Rectangle Border;
            public int Age;
            public Group(ColType type) { this.type = type; group = new LinkList(); Age = 0;  }

            public void AddToGroup(GameObject _obj)
            {
                group.AddtoBegining(_obj);
                //Border = CalculateBorders();
            }
            public void AddToGroup(CollisionObject obj) 
            {
                group.AddtoBegining(obj);
                Border = CalculateBorders();
            
            }
            public void AddToGroup(Group g) { group.AddtoBegining(g);  }
            public void Clear() 
            {
                group.Clear();
            }
            public void RemoveFromGroup(GameObject o)
            {
                group.Remove(o);
            }
            public void RemoveFromGroup(CollisionObject col) { group.Remove(col); }
            public void RemoveFromGroup(Group g) { group.Remove(g);  }
            public LinkList GetList() { return group; }
            public ColType GetColType() { return type; }

            public object  Search(object o) {return group.Search(o); }

            public Rectangle CalculateBorders()
            {


                Node l = group.head;
                if (l == null) { GroupManager.Instance().Remove(this, ColType.Column); Border = new Rectangle(250, 250, 0, 0); }
                else
                {
                    if (l.data is GameObject)
                    {
                        Border = ((GameObject)l.data).GetCol().GetCoordinates();
                    }
                    if (l.data is CollisionObject) { Border = ((CollisionObject)l.data).GetCoordinates(); }



                    if (l.next != null)
                    {
                        for (Node i = group.head.next; i != null; i = i.next)
                        {
                            Rectangle xy= new Rectangle(0,0,0,0);
                            if (i.data is GameObject)
                            {
                               xy = ((GameObject)i.data).GetCol().GetCoordinates();
                            }
                            else if (i.data is CollisionObject)
                            {
                                xy = ((CollisionObject)i.data).GetCoordinates();
                            }
                            Border = Rectangle.Union(Border, xy);
                        }
                    }
                }

                return Border;

            }
           
            public Rectangle GetCoordinates() 
            {
                return Border;
            
            
            }
         

          
            
            
            
        
    }
}
