class Program
{
    static void Main(string[] args)
    {
        int max = 0;
        double avg = 0;
        int[] Grade = new int [10];
        int min = int.MaxValue;
        int temp = 0;
        Console.WriteLine("Enter your Grade");
        for (int i = 0; i < Grade.Length; )
        {
            Console.Write($"Enter Grade {i+1}:");
            var grade = Console.ReadLine();
            int.TryParse(grade, out Grade[i]);          
            if (Grade[i] >= 0) {
                avg += Grade[i];
                if (Grade[i] > max)
                {
                    max = Grade[i];
                }
                if (Grade[i] < min )
                {
                    {
                        min = Grade[i];
                    }

                }
                i++;
            }
            else { Console.WriteLine("Enter positive mark "); }
            
        }
        for (int  i= 0; i < Grade.Length; i++)
        {
            for (int j = 0; j < Grade.Length-1; j++)
            {
                if (Grade[j] > Grade[j + 1])
                {
                    temp = Grade[j];
                    Grade[j] = Grade[j + 1];
                    Grade[j + 1] = temp;
                }
                
            }
        }
        Console.WriteLine("Sorted ");
        for (int i = 0; i < Grade.Length; i++)
        {
            Console.Write($"{Grade[i]},");
        }
        for (int i = 0; i < Grade.Length / 2; i++)
        {
            temp = Grade[i];
            Grade[i] = Grade[Grade.Length - 1 - i];
            Grade[Grade.Length - 1 - i] = temp;
        
        }
        Console.WriteLine();
        Console.WriteLine("Sorted reverse");
        
        for (int i = 0; i < Grade.Length; i++)
        {
            Console.Write($"{Grade[i]},");
        }

        Console.WriteLine();
        avg = avg / Grade.Length;
        Console.WriteLine($"Max Value: {max}");
        Console.WriteLine($"Min Value: {min}");
        Console.WriteLine($"Avg Value: {avg}");
    }
}