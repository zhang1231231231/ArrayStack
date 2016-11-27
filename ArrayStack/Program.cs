using System;

namespace ArrayStack
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> stack = new ArrayStack<int>(10);
            Console.WriteLine(stack.IsEmpty());

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(rand.Next(1, 100));
            }
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
            Console.WriteLine("Size:{0}", stack.Size);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 10; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
            Console.WriteLine("Size:{0}", stack.Size);
            Console.WriteLine("-------------------------------");
            Console.ReadLine();
        }
    }

    public class ArrayStack<T>
    {
        private T[] nodes;
        private int index;

        public ArrayStack(int capacity)
        {
            this.nodes = new T[capacity];
            this.index = 0;
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="node"></param>
        public void Push(T node)
        {
            if(index == nodes.Length)
            {
                //增大数组容量
                ResizeCapacity(nodes.Length * 2);
            }

            nodes[index] = node;
            index++;
        }
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if(index ==0)
            {
                return default(T);
            }

            T node = nodes[index - 1];
            index--;
            nodes[index] = default(T);
            if(index >0&&index ==nodes.Length/4)
            {
                ResizeCapacity(nodes.Length / 2);
            }
            return node;
        }
        /// <summary>
        /// 重置数组大小
        /// </summary>
        /// <param name="newCapacity">新的容器</param>
        private void ResizeCapacity(int newCapacity)
        {
            T[] newNodes = new T[newCapacity];
            if(newCapacity > nodes.Length)
            {
                for(int i = 0;i<nodes.Length;i++)
                {
                    newNodes[i] = nodes[i];
                }
            }
            else
            {
                for(int i = 0; i<newCapacity;i++)
                {
                    newNodes[i] = nodes[i];
                }
            }

            nodes = newNodes;
        }
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.index == 0;
        }
        /// <summary>
        /// 栈中节点数
        /// </summary>
        public int Size
        {
            get
            {
                return this.index;
            }
        }

    }

}
