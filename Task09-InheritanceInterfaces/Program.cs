using Task09_InheritanceInterfaces;

class Program
{
    static void Main(string[] args)
    {
        Circle c1= new Circle(6);
        Console.WriteLine($"Circle :{c1.CalculateArea():N2}");
        Rectangle r1 = new Rectangle(2,9);
        Console.WriteLine($"Rectangle is:{r1.CalculateArea():N2}");
        Triangle t1 = new Triangle(5, 9);
        Console.WriteLine($"Triangle is:{t1.CalculateArea():N2}");
        c1.Draw();
        c1.Resize(2);
        Console.WriteLine($"Circle :{c1.CalculateArea():N2}");
        t1.Resize(2);
        Console.WriteLine($"Triangle is:{t1.CalculateArea():N2}");
        List<Shape> sh1=new List<Shape>();
        sh1.Add(c1);
        sh1.Add(t1);
        sh1.Add(r1);
        foreach (var item in sh1)
        {
            Console.WriteLine($"{item.GetType().Name} :{item.CalculateArea():N2}");
        }


    }
}
