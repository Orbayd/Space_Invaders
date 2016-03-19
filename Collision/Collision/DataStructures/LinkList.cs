using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collision
{
  
        public class Node
        {
            public object data;
            public Node next;
            public Node prev;
            
            public Node(object data)
            {
                this.data = data;
                this.next = null;
                this.prev = null;
            }
            public void AddtoEnd(object data)
            {
                if (next == null)
                {
                    next = new Node(data);
                    
                }
                else

                    next.AddtoEnd(data);


            }
            public void Addsorted(object data)
            {
                if (next == null) { next = new Node(data); }
                else if ((double)data < (double)next.data)
                {
                    Node temp = new Node(data);
                    temp.next = this.next;
                    this.next = temp;
                }
                else
                {
                    next.Addsorted(data);
                }



            }

        }
        public class LinkList
        {
            public Node head;
            private Node tail;
            public int Count;
            public LinkList()
            {
                head = null;
                Count = 0;

            }
            public void AddtoEnd(object data)
            {
                if (head == null) { tail =head = new Node(data);  }

                else
                   head.AddtoEnd(data);
                   
                Count++;
            }
            public void AddtoBegining(object data)
            {

                if (head == null) { tail= head = new Node(data); }

                else
                {

                    Node temp = new Node(data);
                    temp.next =head;
                    head.prev = temp;
                    head = temp;


                }
                Count++;


            }
            public void AddSorted(object data)
            {
                if (head == null) { head = new Node(data); }
                else if ((double)data < (double)head.data) { AddtoBegining(data); }
                else
                    head.Addsorted(data);

                Count++;


            }
            public Object Search(object Data)
            {
               
                for (Node i = head; i != null; i = i.next)
                {
                    if (Data.Equals( Type.sprite))
                    {
                     
                        
                            return (Sprite)head.data;

                        
                    }
                    if (Data.Equals(i.data))
                        return i.data;
                }
                return null;
            }


            public void Clear() { head = null; }

            public void Remove(object Data)
            {
                Node ptr = head;

                while (ptr != null)
                {
                    if ((ptr.data).Equals(Data))
                    {
                        // if solo node
                        if (ptr.next == null && ptr.prev == null)
                        {
                            head = null;
                        }

                        // if front
                        else if (ptr.prev == null && ptr.next != null)
                        {
                            ptr.next.prev = null;
                            head = ptr.next;
                            ptr.next = null;
                        }

                        // if middle 
                        else if (ptr.prev != null && ptr.next != null)
                        {
                            ptr.next.prev = ptr.prev;
                            ptr.prev.next = ptr.next;

                            ptr.next = null;
                            ptr.prev = null;

                        }

                        // if end 
                        else if (ptr.prev != null && ptr.next == null)
                        {
                            ptr.prev.next = null;
                            ptr.prev = null;

                        }
                        else { }
                        Count--;
                    }
                    ptr = ptr.next;

                }



                //for (Node i = head; i != tail; i = i.next)
                //{

                //    if (i.next == null && i.prev == null)
                //    {
                //        head = null;
                //    }
                //    if (head.data.Equals(Data)) { head = head.next; Count--; break; }
                //    if (tail.data.Equals(Data)) { tail.prev.next = null; Count--; break; }
                //    if (i.data.Equals(Data))
                //    {
                //        i.prev.next = i.next;
                //        Count--;
                //        break;
                //    }

                //}
                
            }
            
           
            
        }
    }

