using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seyr_u_sefer
{
   public class Linkedlist : ListADT
    {

       

        public override void InsertPos(int position, sefer value)
        {
            Node temp = new Node { Data = value };
            Node current = Head;


            if (current != null)
            {
                for (int i = 0; i < position && current.Next != null; i++)
                {
                    current = current.Next;
                }

                temp.Next = current.Next;
                current.Next = temp;
            }
            else
            {
                Head = temp;
            }

            Size++;
        }

     
       

        public override void DeletePos(int position)
        {

          

            Node posNode = Head;
            if (Head == null)
                throw new Exception("Bos");
            if (Size > position)
            {
                Node prevNode = posNode;
                for (int i = 0; i < position; i++)
                {
                    prevNode = posNode;
                    posNode = posNode.Next;
                }
                if (posNode == Head)
                    Head = posNode.Next;
                else if (posNode.Next != null)
                {
                    prevNode.Next = posNode.Next;
                    posNode = null;
                }
                else if (posNode.Next == null)
                {
                    prevNode.Next = null;
                    posNode = null;
                }
            }
            Size--;



        }
        public override Node GetElement(int position)
        {
            Node iter = Head;
            for (int i = 1; i <= position; i++)
            {
                iter = iter.Next;
            }
            return iter;
        }

     

    }
}

