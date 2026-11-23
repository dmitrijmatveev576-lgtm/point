using System;

namespace PointApp
{
    // Структура StructPoint (тип значення / value type)
    public struct StructPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public StructPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"Структура StructPoint: X = {X}, Y = {Y}");
        }

        // Перевантаження оператора
        public static StructPoint operator +(StructPoint p1, StructPoint p2)
        {
            return new StructPoint(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static bool operator ==(StructPoint p1, StructPoint p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(StructPoint p1, StructPoint p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj is StructPoint other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

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
            Console.WriteLine($"Клас Point: X = {X}, Y = {Y}");
        }

        public static Point operator +(Point p1, Point p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentNullException("Неможливо додати нульові об'єкти точок.");
            
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;
            if (p1 is null || p2 is null)
                return false;
            
            return p1.X == XStaticHelper(p1, p2);
        }

       
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        private static double XStaticHelper(Point p1, Point p2) => p2.X;

        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 1. Тестування функціоналу StructPoint ---\n");

            StructPoint structPoint1 = new StructPoint();
            Console.Write("StructPoint 1 (без параметрів): ");
            structPoint1.Display();
            
            StructPoint structPoint2 = new StructPoint(5.5, 12.0);
            Console.Write("StructPoint 2 (з параметрами): ");
            structPoint2.Display();

            StructPoint structPoint3 = structPoint1 + structPoint2;
            Console.Write("StructPoint 3 (structPoint1 + structPoint2): ");
            structPoint3.Display();

            StructPoint structPoint4 = new StructPoint(5.5, 12.0);
            Console.WriteLine($"Порівняння structPoint2 та structPoint4: structPoint2 == structPoint4 -> {structPoint2 == structPoint4}\n");


            Console.WriteLine("--- 2. Порівняння поведінки копіювання: Клас (Reference Type) vs Структура (Value Type) ---\n");

            // Демонстрація для Класу (Point)
            Console.WriteLine("Оригінальний Класс (Point):");
            Point classPointA = new Point(10, 10);
            classPointA.Display();

            Point classPointB = classPointA; // Копіюється ПОСИЛАННЯ на той самий об'єкт у пам'яті
            classPointB.X = 99; // Змінюємо через другу змінну

            Console.WriteLine("Після зміни classPointB.X = 99:");
            Console.Write("classPointA: "); classPointA.Display(); // Змінилося і тут!
            Console.Write("classPointB: "); classPointB.Display();
            

            Console.WriteLine("\nСтруктура (StructPoint):");
            StructPoint structPointA = new StructPoint(10, 10);
            structPointA.Display();

            StructPoint structPointB = structPointA; // Копіюється самі ДАНІ (значення)
            structPointB.X = 99; // Змінюємо копію

            Console.WriteLine("Після зміни structPointB.X = 99:");
            Console.Write("structPointA: "); structPointA.Display(); // Залишилося незмінним!
            Console.Write("structPointB: "); structPointB.Display();

            Console.ReadKey();
        }
    }
}
