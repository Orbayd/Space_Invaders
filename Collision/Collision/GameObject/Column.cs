using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
  public class Column:GameObject
    {
       
        private Group group;
        private Rectangle Coords;

        public Column()
        {
            colObj = new CollisionObject(); SpriteManager.Instance().AddCOL(colObj);
        }
        public Column(Group Group)
        {
            colObj = new CollisionObject(); SpriteManager.Instance().AddCOL(colObj); this.group = Group; 
        }
        public override void Update()
        {
            //this.colObj.SetCoordinates(Rectangle.Union(AllienTop.GetCol().GetCoordinates(),AllienBottom.GetCol().GetCoordinates() ));
            this.colObj.SetCoordinates(CalculateBorders());
           
        }

        private void CreateBomb()
        {
          
        }
        public Rectangle CalculateBorders()
        {
            Rectangle Border;
          
            Node l = group.GetList().head;
            if (l == null)
            {
                GroupManager.Instance().Remove(this, ColType.Column);
                Border = new Rectangle(10, 10, 0, 0);
                SpriteManager.Instance().RemoveCol(colObj);
                GameObjectMan.Instance().RemoveObject(this);

            }
            else{
               Border = ((GameObject)l.data).GetCol().GetCoordinates();

                if (l.next != null)
                {

                    for (Node i = group.GetList().head.next; i != null; i = i.next)
                    {

                        Rectangle xy = ((GameObject)i.data).GetCol().GetCoordinates();

                        Border = Rectangle.Union(Border, xy);

                    }
                }
            }
                Coords = Border;
                return Border;
            
            
        }
        public LinkList getgrouplist() 
        {
           return group.GetList();
        
        
        }
        public override CollisionObject GetCol()
        {
            return this.colObj;
        }
        public override Sprite GetSprite()
        {
            return base.GetSprite();
        }
        
    }
}
