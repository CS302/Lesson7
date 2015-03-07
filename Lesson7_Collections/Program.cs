using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersLibrary;

namespace Lesson7_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[5];
            workers[0] = new Manager("Svetlana", 23, 14518, 9);
            workers[1] = new Driver("Ivan", 45, 1233215, "BMW", 250);
            workers[2] = new Manager("Elena", 23, 14518, 9);
            workers[3] = new Driver("Vasya", 29, 84567852, "Audi", 256);
            workers[4] = new Driver("Sasha", 52, 8456123, "Porsche", 150);

            //ShowCol(workers);

            //ShowList(workers);

            //ShowDict();

            //ShowStack();
            // () {} []
            // ({[]})
            //({[)]}

            /*
             * обобщенная коллекция - очередь
             */
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            foreach (int item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(queue.Peek());

            Console.WriteLine();

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.ReadLine();
        }

        /*
         * обощенная коллекция - стек
         */
        private static void ShowStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        /*
         * обобщенная коллекция - словарик(ключ - значение)
         */
        private static void ShowDict()
        {
            string[] exs = "exe.pdf.dll.js.txt.exe.js.pdf".Split('.');

            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < exs.GetLength(0); i++)
            {
                if (!dict.ContainsKey(exs[i]))
                    dict.Add(exs[i], 0);
            }


            dict.Add(".exe", 0);
            dict.Add(".txt", 0);

            string ex = ".txt";
            int count = dict[ex];
            dict[ex] += 1;
        }

        /*
         * обобщенная коллекция - список
         */
        private static void ShowList(Worker[] workers)
        {
            List<Worker> list = new List<Worker>();
            list.AddRange(workers);

            list.Insert(0, new Manager("Evgenii", 23, 78452, 15));

            foreach (Worker item in list)
            {
                item.Print();
            }
        }

        /*
         * в этом методе рассмотрено взаимодействие с необобщенными коллекциями
         */
        private static void ShowCol(Worker[] workers)
        {
            ArrayList list = new ArrayList();
            list.AddRange(workers);

            list.Add("rabotnik");

            foreach (object item in list)
            {
                (item as Worker).Print();
            }

            /*list.Add(new Manager("Svetlana", 23, 14518, 9));
            list.Add(new Driver("Ivan", 45, 1233215, "BMW", 250));
            list.Add(new Manager("Elena", 23, 14518, 9));
            list.Add(new Driver("Vasya", 29, 84567852, "Audi", 256));
            list.Add(new Driver("Sasha", 52, 8456123, "Porsche", 150));

            foreach (object item in list)
            {
                (item as Worker).Print();
            }

            Console.WriteLine(list.Count);
            Console.WriteLine();

            list.RemoveAt(3);
            foreach (object item in list)
            {
                (item as Worker).Print();
            }

            (list[3] as Worker).Print();*/



            Console.WriteLine();
        }
    }
}
