using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
   public class GroupManager
    {
       private static GroupManager instance;
       public LinkList grouplist = new LinkList();
       public LinkList groupslist = new LinkList();
       
       
       public static GroupManager Instance() 
       {
           if (instance == null) { instance = new GroupManager(); }
           return instance;

       
       }

       public void AddtoList(object o,ColType type) 
       {
           if (type.Equals(ColType.Column))
           {
               grouplist.AddtoBegining(o);
              
           }
           else if (type.Equals(ColType.Columns))
           {
               groupslist.AddtoBegining(o);

           }
         
       
       }
       public void RemoveObject (GameObject o)
      {
           
           for (Node i = grouplist.head; i != null; i = i.next) 
           {
                ((Group)i.data).RemoveFromGroup(o);
                
           }

       }
       public object Search(GameObject o)
       {
           GameObject a;
           for (Node i = grouplist.head; i != null; i = i.next) 
           {
                a= (GameObject)((Group)i.data).Search(o);
                if (a  !=null) { return a;  }
           }
           return null;
       
       }
       public void Remove(object o, ColType type)
       {
           if (type.Equals(ColType.Column))
           {
               grouplist.Remove(o);
           }
       }
       public LinkList GetLinkList(ColType type)
       {
           if (type.Equals(ColType.Column))
               return grouplist;
           else
               return null;
       }

       public void Reset()
       {   
         grouplist = new LinkList();
         groupslist = new LinkList(); 
       }
       //public Rectangle CalculateSuper() 
       //{
           

       //        Node l = super.head;
       //        Rectangle superborders = ((Group)l.data).CalculateBorders();
       //        if (l.next != null)
       //        {
       //            for (Node i = grouplist.head.next; i != null; i = i.next)
       //            {
       //                Rectangle xy = ((Group)i.data).CalculateBorders();


       //                superborders = Rectangle.Union(superborders, xy);
       //            }
       //        }
       //        return superborders; 
           
           
           
           
       
       
       //}
    }
}
