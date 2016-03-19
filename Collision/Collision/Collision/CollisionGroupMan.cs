using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collision
{
    public class CollisionGroupMan
    {
        private static  CollisionGroupMan instance;
        private LinkList AllienGroup = new LinkList();
        private LinkList WallGroup = new LinkList();
        private LinkList ShieldGroup = new LinkList();
        private LinkList MissleGroup = new LinkList();
        private LinkList ColumGroup = new LinkList();
        public static CollisionGroupMan Instance() 
        {
            if (instance == null)
                instance = new CollisionGroupMan();

            return instance;
        
        
        }

        public void AddGroup(object o)
        {
            if (o is Allien) { AllienGroup.AddtoBegining(o); }
            else if (o is Wall) { WallGroup.AddtoBegining(o); }
            else if (o is Column) { WallGroup.AddtoBegining(o); }
        
        }
        public void RemoveGroup(object o) 
        {
            if (o is Allien) { AllienGroup.Remove(o); }
            else if (o is Wall) { WallGroup.Remove(o); }
        
        }
        public LinkList getLinkList(object o) 
        {
            if (o is Allien) { return AllienGroup; }
            else if (o is Wall) {return WallGroup; }
            else if (o is Column) { return ColumGroup; }
            return null;
        }

    }
}
