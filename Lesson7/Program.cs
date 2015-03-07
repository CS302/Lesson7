using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * небольшой набор действий, чтобы пользователь мог
             * работать с точками через консоль и текстовый файл
             */

            Point p2 = LoadTxt();
            p2.Print();

            p2.x = int.Parse(Console.ReadLine());
            p2.y = int.Parse(Console.ReadLine());
            p2.label = Console.ReadLine();

            SaveTxt(p2);
            SaveBin(p2);

            Console.ReadLine();
        }

        /*
         * метод для считывания информации о точке из текстового файла
         */
        private static Point LoadTxt()
        {
            string path = @"C:\Lesson6\SavedPoint.txt";
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            StreamReader reader = new StreamReader(stream);

            int x = int.Parse(reader.ReadLine());
            int y = int.Parse(reader.ReadLine());
            string label = reader.ReadLine();

            reader.Close();

            Point p = new Point(x, y);
            p.label = label;

            return p;
        }

        /*
         * метод для сохранения информации о точке в текстовый файл
         */
        private static void SaveTxt(Point p1)
        {
            string path = @"C:\Lesson6\SavedPoint.txt";
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(p1.x);
            writer.WriteLine(p1.y);
            writer.WriteLine(p1.label);

            writer.Close();
        }

        /*
         * небольшой набор действий, чтобы дать пользователю возможность
         * поработать с точками
         */
        private static void ShowBin()
        {
            Point p2 = LoadBin();
            p2.Print();

            p2.x = int.Parse(Console.ReadLine());
            p2.y = int.Parse(Console.ReadLine());
            p2.label = Console.ReadLine();

            SaveBin(p2);
        }

        /*
         * метод, с помощью которого информацию о точке можно
         * считать из бинарного файла и вернуть новую точку в виде объекта
         */
        private static Point LoadBin()
        {
            string path = @"C:\Lesson6\SavedPoint.bin";
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] mass = new byte[sizeof(int)]; //4
            
            stream.Read(mass, 0, mass.GetLength(0));
            int x = BitConverter.ToInt32(mass, 0);

            stream.Read(mass, 0, mass.GetLength(0));
            int y = BitConverter.ToInt32(mass, 0);

            stream.Read(mass, 0, mass.GetLength(0));
            int length = BitConverter.ToInt32(mass, 0);

            byte[] labelMass = new byte[length];
            stream.Read(labelMass, 0, labelMass.GetLength(0));
            string label = Encoding.UTF8.GetString(labelMass);


            stream.Close();

            Point p = new Point(x,y);
            p.label = label;

            return p;
         }

        /*
         * Метод, с помощью которого информацию о точке можно сохранить
         * в бинарный файл в виде массива байтов
         */
        private static void SaveBin(Point p1)
        {
            string path = @"C:\Lesson6\SavedPoint.bin";
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            byte[] xMass = BitConverter.GetBytes(p1.x);
            stream.Write(xMass, 0, xMass.GetLength(0));

            byte[] yMass = BitConverter.GetBytes(p1.y);
            stream.Write(yMass, 0, yMass.GetLength(0));

            byte[] labelMass = Encoding.UTF8.GetBytes(p1.label);

            byte[] lengthMass = BitConverter.GetBytes(labelMass.GetLength(0));
            stream.Write(lengthMass, 0, lengthMass.GetLength(0));

            stream.Write(labelMass, 0, labelMass.GetLength(0));

            stream.Close();
        }
    }
    /*
     * для рассмотрения записи/чтения создали класс "точка".
     * три поля, конструктор и метод вывода на консоль информации об объекте.
     */
    class Point
    {
        public int x;
        public int y;
        public string label = "";
        public Point (int x, int y)
	    {
            this.x = x;
            this.y = y;
	    }

        public void Print()
        {
            Console.WriteLine("{0} \nX = {1} \nY = {2}", label, x, y);
        }
    }


}
