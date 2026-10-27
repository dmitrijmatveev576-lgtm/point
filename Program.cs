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

        // Перевантаження оператора + (додавання координат двох точок)
        public static Point operator +(Point p1, Point p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentNullException("Неможливо додати нульові об'єкти точок.");
            
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        // Перевантаження оператора ==
        public static bool operator ==(Point p1, Point p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;
            if (p1 is null || p2 is null)
                return false;
            
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        // Перевантаження оператора != (обов'язково в парі з ==)
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        // Перевизначення Equals для уникнення попереджень компілятора
        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        // Перевизначення GetHashCode відповідно до Equals
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Тестування конструкторів та операторів класу Point ---\n");

            Point point1 = new Point();
            Console.Write("Об'єкт 1 (без параметрів): ");
            point1.Display();
            
            Point point2 = new Point(5.5, 12.0);
            Console.Write("Об'єкт 2 (з параметрами): ");
            point2.Display();

            // Тест оператора +
            Point point3 = point1 + point2;
            Console.Write("Об'єкт 3 (point1 + point2): ");
            point3.Display();

            // Тест операторів порівняння == та !=
            Point point4 = new Point(5.5, 12.0);
            Console.WriteLine($"\nПорівняння point2 та point4 (однакові координати): point2 == point4 -> {point2 == point4}");
            Console.WriteLine($"Порівняння point1 та point2 (різні координати): point1 != point2 -> {point1 != point2}");

            Console.ReadKey();
        }
    }
}