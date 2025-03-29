using PR_10.Library.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_12
{
    public class DoublyLinkedPoint
    {
        public Goods Data;
        public DoublyLinkedPoint Next;
        public DoublyLinkedPoint Prev;

        public DoublyLinkedPoint(Goods data)
        {
            Data = data;
        }
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedPoint Head;
        public DoublyLinkedPoint Tail;

        public void Add(Goods data)
        {
            DoublyLinkedPoint newNode = new DoublyLinkedPoint(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public void Print()
        {
            DoublyLinkedPoint current = Head;
            while (current != null)
            {
                current.Data.Show();
                current = current.Next;
            }
        }

        public void DeleteFirstByName(string name)
        {
            DoublyLinkedPoint current = Head;

            while (current != null)
            {
                if (current.Data.Name == name)
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        Tail = current.Prev;
                    }

                    return;
                }
                current = current.Next;
            }
            Console.WriteLine($"Элемент с названием '{name}' не найден.");
        }


        public void Clear()
        {
            Head = null;
            Tail = null;
        }
    }



}
