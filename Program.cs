using System;

namespace PointApp
{
  
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        
        public Point()
        {
            X = 0;
            Y = 0;
        }

        
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        
        public void Display()
        {
            Console.WriteLine($"Точка з координатами: X = {X}, Y = {Y}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Тестування конструкторів класу Point ---\n");

           
            Point point1 = new Point();
            Console.Write("Об'єкт 1 (без параметрів): ");
            point1.Display();
            
            Point point2 = new Point(5.5, 12.0);
            Console.Write("Об'єкт 2 (з параметрами): ");
            point2.Display();

            Console.ReadKey();
        }
    }
}