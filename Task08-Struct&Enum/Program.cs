class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------struct---------");
        Color c1 = new Color(158, 67, 91);
        Color c2 = c1;
        c2.R = 100;
        Console.WriteLine(c1.R);
        Console.WriteLine(c2.R);
        Console.WriteLine("--------class---------");
        ColorClass c3 = new ColorClass(51, 94, 255);
        ColorClass c4 = c3;
        c4.R=100;
        Console.WriteLine(c3.R);
        Console.WriteLine(c4.R);
        Console.WriteLine("Enum");
        OrderStatus status = OrderStatus.Paid | OrderStatus.Shipped;
        Console.WriteLine(status);
        if ((status & OrderStatus.Paid) == OrderStatus.Paid)
        {
            Console.WriteLine("Order is paid");
        }

    }
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
    [Flags]
    public enum OrderStatus
    {
        None = 0,
        Pending = 1,
        Paid = 2,
        Shipped = 4,
        Delivered = 8
    }
    public class ColorClass
    {
        public byte R;
        public byte G;
        public byte B;

        public ColorClass(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}