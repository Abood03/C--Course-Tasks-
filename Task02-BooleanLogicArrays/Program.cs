using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int x = 3;
        double d = 4.6;
        d = x;
        //x = d; error 
        x = (int)d;
        byte b = 200;
        int z = 300;
        
            //b = (byte)z;
        
        string s = "50";

        Console.WriteLine(int.Parse(s));
        string st = "hello";
        try
        {
            int.Parse(st);
            Console.WriteLine(st);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        //Console.WriteLine(Convert.ToInt32("")); //error
        //Console.WriteLine(Convert.ToInt32("hello")); //error

        string number = "hello";
        int numm;
        int.TryParse(number, out numm);
        Console.WriteLine(numm);



        //boxing unboxing 
        int o = 15;
        Object obj = o;
        Console.WriteLine($"boxing :{o}");
        int newnum=(int)o;
        Console.WriteLine($"unboxing :{newnum}");


        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        for (int i = 0; i < 1000000; i++) 
        {
            int sum = 3 + 5;
        } 
       sw.Stop();
        Console.WriteLine($"Normal Loop Time: {sw.ElapsedMilliseconds} ms");
        sw.Restart();
        for (int i = 0; i < 1000000; i++) 
        {
            int q = 2;
            Object obj2 = q;
            int newnum2 = (int)o;


        }

        sw.Stop();
        Console.WriteLine($"Normal Loop Time: {sw.ElapsedMilliseconds} ms");
    }

}