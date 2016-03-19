using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collision
{
    class CollisionPairMan
    {
        LinkList pairList = new LinkList();
        private static CollisionPairMan instance;
        public static CollisionPairMan Instance()
        {
            if (instance == null)
                instance = new CollisionPairMan();
            return instance;
        }

          public void Add_to_PairList(object a) 
        {
            pairList.AddtoBegining(a);
        
        
        }
        public void runCollisionCheck()
        {
            Node ptr = pairList.head;


            ColCheckstatic();
            CollisionPair pair;
            
            while (ptr != null)
            {
             
                        pair = ((CollisionPair)ptr.data);
                        pair.Run(((CollisionPair)ptr.data).getType());
                      //  pair.checkMissleVsAllien();
                      //  pair.checkMissleVsShield();
                       // pair.checkAlienVWall();
                       //pair.checMissleVWall();
               
                ptr = ptr.next;
            }
        }
        public void ColCheckstatic() 
        {
            CollisionPair col = new CollisionPair();
            col.checkAlienVsWall();
            col.checkMissleVsWall();
            col.checkShipvsSuper();
            col.checkUFOvsMissle();
            col.checkUFOvsWall();
        }

        public void Reset() {  pairList = new LinkList(); }

    }
}
