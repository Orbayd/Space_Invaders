using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
    public class Shield : GameObject
    {
       private Group colgroup;
       ShieldColumn colum;
       private CollisionObject col1, col2;
       private LinkList shieldColumnList;
       public Shield(int x,int y,int gx ,int gy)
       {
           sprite = new Sprite(SpriteType.Shield);
           SetPosition(x, y);
           SetGrid(gx, gy);
           sprite.SetFrame(25);
           sprite.SetSpeed(new Vector2(0, 0));
           sprite.SetScale(1);
           sprite.SetColor(Color.Green);
           sprite.SetLayerDepth(0.8f);
            SpriteManager.Instance().AddSprite(sprite);
       
       
       }
        public Shield()
        {
            
            sprite = new Sprite(SpriteType.Shield);
            
            sprite.SetFrame(25);
            sprite.SetSpeed(new Vector2(0, 0));
            sprite.SetScale(1);
            sprite.SetColor(Color.Green);
            sprite.SetLayerDepth(0.8f);
           

          

        }



        private void SetGrid(int xgrid, int ygrid)
        {
         
            int height = 80 / ygrid;
            int width = 100 / xgrid;
            int x = (int)sprite.GetPosition().X;
            int y = (int)sprite.GetPosition().Y;
            colum = new ShieldColumn();
            shieldColumnList = new LinkList();
           
            for (int i = 0; i < xgrid * ygrid; i++)
            {
                colgroup = new Group(ColType.Shield);
                if (i % xgrid == 0 && i > 0)
                { 
                    x = (int)sprite.GetPosition().X; y = y + height; 
                }
                col1= new CollisionObject(new Rectangle(x,y,width,height/2));
                col2 = new CollisionObject(new Rectangle(x, y + height / 2, width, height / 2));
                
                
                SpriteManager.Instance().AddCOL(col1);
                SpriteManager.Instance().AddCOL(col2);
                colgroup.AddToGroup(col1);
                colgroup.AddToGroup(col2);
                colgroup.Age = 3;
                colum.AddtoColum(colgroup);
                x = x + width;
                shieldColumnList.AddtoBegining(colum);
              
            }

            colum.update(x,y);

            

        }

        public void SetPosition(int x, int y) { sprite.SetPosition(new Vector2(x, y));  }
        public Group GetColGroup() { return colum.GetcolGroup(); }
        public void RemoveSuper() { colum.removeSuper(); }
        public void RemoveGroup(Group g) { colum.RemovefromColumn(g); }
        public CollisionObject GetSuper() { return colum.colObj; }
        public void Accept(GameObject other, CollisionObject col,Group g)
        {
            Console.Write("[Shield] ");

            other.VisitShield(this, col,g);
        }
        public override void VisitMissle(Missle m)
        {
            Console.WriteLine("Collided with Shield");


        }
        public LinkList GetShieldColumList() { return shieldColumnList; }

    }
}
