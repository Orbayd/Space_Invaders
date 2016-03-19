using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.Pex.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Collision
{
    
    public class Explosion
    {
      //  private Particle[] particles;           // particles in the explosion
        private int x, y;                       // the explosion's origin
                           // number of particles
        private int pnumber;
       LinkList list;
        public Explosion (int pnumber,int x,int y)
        {
            this.x = x;
            this.y = y;
            this.pnumber = pnumber;
           // SetExplosion();
            list = new LinkList();
          
           
        }
      
        public void Clear(int width,int height) 
        { 
            
           // list.AddtoBegining(new Particle(x-2,y-2,width,height));
          //  SpriteManager.Instance().AddExpolsion(list);
        
        }
      
        public void SetExplosion()
        {
            int k = 8;
            Random rnd = new Random();
            Particle par = new Particle(x + rnd.Next(0, 0), y - rnd.Next(1, 10));
            Particle par2 = new Particle(x + rnd.Next(-2,-2), y - rnd.Next(-3, 15));
            Particle par3 = new Particle(x + rnd.Next(-2,2), y - rnd.Next(-3, 15));
            Particle par4 = new Particle(x + rnd.Next(-2, 2), y - rnd.Next(-3, 15));
            Particle par5 = new Particle(x + rnd.Next(-2, 2), y - rnd.Next(-3, 15));
            for (int i = 0; i < 100; i++)
            {
                
                if (i % 25==0) { k=k-2; }
                Particle Par = new Particle(x + (rnd.Next(-k, k)), y - rnd.Next(-k, k + 10));
            
                  list .AddtoBegining(Par);
            }


           
            list.AddtoBegining(par);
            list.AddtoBegining(par2);
            list.AddtoBegining(par3);
            list.AddtoBegining(par4);
            list.AddtoBegining(par5);
           // SpriteManager.Instance().AddExpolsion(list);
        }

        public LinkList GetList() { return list; }
      
        
        
    }

    public class Particle 
    {
        private Color color;
        private int height;
        private int width;
        private int x;
        private int y;
        Rectangle particle;
        private Texture2D circle;
       
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        public Particle(int x, int y, int width, int height) 
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            particle = new Rectangle(x, y, width,height);
            this.color = Color.Black;
            texture = new Texture2D(Game1.GameInstance.GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Wheat });
            circle = texture;
            
        
        }
        public Particle(int x, int y)
        {
            this.x = x;
            this.y = y;
            //Random rnd = new Random();
            width =2;
                //rnd.Next(1,8);
            height =2;
            //= rnd.Next(1, 8);
            particle = new Rectangle(x, y, width, height);
            this.color = Color.White;
            //texture= Texture.Instance().GetEx();
            texture = new Texture2D(Game1.GameInstance.GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Black });
            this.circle = CreateCircle(Game1.GameInstance.GraphicsDevice, width);
            //this.circle = createCircleText(width);
    
        }

        public void Draw()
        {
            spriteBatch = Game1.GameInstance.spriteBatch;
          spriteBatch.Draw(texture, particle,null ,Color.White,1.57079f,Vector2.Zero,SpriteEffects.None,1f);
          //Vector2 Origin = new Vector2(width / 2, height / 2);
          //spriteBatch.Draw(circle,
          //    particle
          //    //new Vector2(x,y,width,height)
          //    , null,
          //    Color.Cyan, 0, Origin, SpriteEffects.FlipHorizontally, 0.9f);
          //spriteBatch.Draw(texture, new Rectangle(x, y, width, height), Color.Black);
        
        }
       
      public static Texture2D CreateCircle(GraphicsDevice importedGraphicsDevice, int radius)
          {
        int outerRadius = radius * 2 + 2; // So circle doesn't go out of bounds
        Texture2D texture = new Texture2D(importedGraphicsDevice, outerRadius, outerRadius);

        Color[] data = new Color[outerRadius * outerRadius];
       
        // Colour the entire texture transparent first.
        for (int i = 0; i < data.Length; i++)
            data[i] = Color.Transparent;
           // data[i] = Color.Black;

        // Work out the minimum step necessary using trigonometry + sine approximation.
        double angleStep = 1f / radius;

        for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
        {
            // Use the parametric definition of a circle: 
            int x = (int)Math.Round(radius + radius * Math.Cos(angle));
            int y = (int)Math.Round(radius + radius * Math.Sin(angle));

            data[y * outerRadius + x + 1] = Color.White;
        }

                    //width
        for (int i = 0; i < outerRadius; i++)
        {
            int yStart = -1;
            int yEnd = -1;


            //loop through height to find start and end to fill
            for (int j = 0; j < outerRadius; j++)
            {

                if (yStart == -1)
                {
                    if (j == outerRadius - 1)
                    {
                        //last row so there is no row below to compare to
                        break;
                    }

                    //start is indicated by Color followed by Transparent
                    if (data[i + (j * outerRadius)] == Color.White && data[i + ((j + 1) * outerRadius)] == Color.Transparent)
                    {
                        yStart = j + 1;
                        continue;
                    }
                }
                else if (data[i + (j * outerRadius)] == Color.White)
                {
                    yEnd = j;
                    break;
                }
            }

            //if we found a valid start and end position
            if (yStart != -1 && yEnd != -1)
            {
                //height
                for (int j = yStart; j < yEnd; j++)
                {
                    data[i + (j * outerRadius)] = new Color(255, 255, 255, 255);
                }
            }
        }

        texture.SetData(data);
        return texture;
    }
      private Texture2D createCircleText(int radius)
        {
            Texture2D texture = new Texture2D(Game1.GameInstance.GraphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
    
    
    }
}
