using System;

class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"X = {X}, Y = {Y}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point point1 = new Point(3.5, 5.0);
        Point point2 = new Point(-2.1, 4.3);
        Point point3 = new Point(-4.0, -1.5);

        Console.WriteLine("Координати точок:");
        point1.DisplayInfo();
        point2.DisplayInfo();
        point3.DisplayInfo();
    }
}