using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  Microsoft.Xna.Framework;
namespace Collision
{
    public class UnUpdateable
    {
        private LinkList SpriteLabel;
        private LinkList TextLabels;
        private static UnUpdateable instance;
        public static UnUpdateable Instance() 
        {
            if (instance == null) { instance = new UnUpdateable(); }
            return instance;
        
        }
        public static void Create(){instance = new UnUpdateable();}
        public static UnUpdateable GetInstance() { return instance; }
        public static void Destroy() { instance = null; }
        public void LoadContent()
        {
            LoadSpriteLabels();
            LoadTextLabels();
        }
        private void LoadSpriteLabels()
        {
            SpriteLabel = new LinkList();
            Sprite Label = new Sprite(SpriteType.Label);
            Label.SetFrame(28);
            Label.SetScale(2.5f);
            Label.SetColor(Color.Green);
            Label.SetPosition(new Vector2(275, 50));
            Sprite Allien1 = new Sprite(SpriteType.Label);
            Allien1.SetFrame(5);
            Allien1.SetPosition(310+5, 200);
            Allien1.SetColor(Color.White);
            Allien1.SetScale(0.5f);
            Sprite Allien2 = new Sprite(SpriteType.Label);
            Allien2.SetFrame(1);
            Allien2.SetPosition(310,250);
            Allien2.SetColor(Color.White);
           Allien2.SetScale(0.5f);
            Sprite Allien3 = new Sprite(SpriteType.Label);
            Allien3.SetFrame(3);
            Allien3.SetPosition(310, 300);
            Allien3.SetColor(Color.White);
           Allien3.SetScale(0.5f);
            Sprite Allien4 = new Sprite(SpriteType.Label);
            Allien4.SetFrame(20);
            Allien4.SetPosition(310, 350);
            Allien4.SetScale(0.5f);
            Allien4.SetColor(Color.Red);

            SpriteLabel.AddtoBegining(Label);
            SpriteLabel.AddtoBegining(Allien1);
            SpriteLabel.AddtoBegining(Allien2);
            SpriteLabel.AddtoBegining(Allien3);
            SpriteLabel.AddtoBegining(Allien4);


        }
        private void LoadTextLabels()
        {
            TextLabels = new LinkList();
            TextLabel Allien1Text = new TextLabel();
            Allien1Text.SetName(" = 10 Points");
            Allien1Text.SetPosition(new Vector2(360, 210));
            Allien1Text.SetScale(1);
            TextLabel Allien2Text = new TextLabel();
            Allien2Text.SetName(" = 20 Points");
            Allien2Text.SetPosition(new Vector2(360, 260));
            Allien2Text.SetScale(1);

            TextLabel Allien3Text = new TextLabel();
            Allien3Text.SetName(" = 40 Points");
            Allien3Text.SetPosition(new Vector2(360, 310));
            Allien3Text.SetScale(1);

            TextLabel Allien4Text = new TextLabel();
            Allien4Text.SetName(" = ??? Points");
            Allien4Text.SetPosition(new Vector2(360, 360));
            Allien4Text.SetScale(1);
            TextLabels.AddtoBegining(Allien1Text);
            TextLabels.AddtoBegining(Allien2Text);
            TextLabels.AddtoBegining(Allien3Text);
            TextLabels.AddtoBegining(Allien4Text);

        }

        public void Draw()
        {
            for (Node i = SpriteLabel.head; i != null; i = i.next)
            {
                ((Sprite)i.data).Draw();
            }
            for (Node k = TextLabels.head; k != null; k = k.next)
            {
                ((TextLabel)k.data).Draw();

            }

        }


    }
}
