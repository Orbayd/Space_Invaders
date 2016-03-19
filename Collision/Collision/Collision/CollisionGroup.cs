using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collision
{
   
     public  class CollisionGroup
    {
        private LinkList ColList;
        private ColType type;
        public CollisionGroup(ColType type) { this.type = type; ColList = new LinkList(); }

        public void addToGroup(GameObject _obj)
        {
            ColList.AddtoBegining(_obj);
        }
        public LinkList GetList() { return ColList; }

        public ColType GetColType() { return type; }
    }
}
