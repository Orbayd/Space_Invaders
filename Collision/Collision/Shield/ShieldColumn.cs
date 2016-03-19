using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Collision
{
    public class ShieldColumn : Shield
    {
        Group colgroup;
        
      
        public ShieldColumn()
        {
            colgroup = new Group(ColType.Shield);
            this.colObj = new CollisionObject();
            
          
            SpriteManager.Instance().AddCOL(this.colObj);
           
        }
        public void  AddtoColum(Group group){ colgroup.AddToGroup(group);}
        public void RemovefromColumn(Group group) { colgroup.RemoveFromGroup(group); }
        public void update(int x,int y) {this.colObj.SetCoordinates( CalculateSuper(x,y )); }
        public void removeSuper() { SpriteManager.Instance().RemoveCol(this.colObj); }
        public Rectangle CalculateSuper(int x, int y) 
        
        {
            Rectangle SuperBorders=new Rectangle(x,y,0,0);
            for (Node i = colgroup.GetList().head; i != null; i = i.next) 
            {
                for (Node k = ((Group)i.data).GetList().head; k != null; k = k.next) 
                {
                    Rectangle rec = ((CollisionObject)k.data).GetCoordinates();

                    SuperBorders = Rectangle.Union(SuperBorders, rec);
                }
            
            
            }
            return SuperBorders;

        
        
        }

        public Group GetcolGroup() { return colgroup; }

        


        }
    
    }

