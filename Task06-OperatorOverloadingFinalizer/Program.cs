public class Program 
{
    static void Main(string[] args)
    {
        Money m1 = new Money(10,"jod");
        Money m2 = new Money(10, "jod");
        Console.WriteLine($"m1+m2=: {m1 + m2}");
        Console.WriteLine($"m1-m2=: {m1- m2}");
        Console.WriteLine($"m1=m2: {m1==m2}");
        Console.WriteLine($"m1!=m2:{m1!= m2}");
        Console.WriteLine($"m1>m2: {m1> m2}");
        Console.WriteLine($"m1<m2: {m1< m2}");
        GC.Collect();

    }
}
class Money
{
    string Currency { get; set; }
    int Amount { get; set; }
    public Money(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator -(Money m1, Money m2)

    {
       
      
        if (m1.Currency.ToLower() == m2.Currency.ToLower())
        {
            Money m3 = new Money((m1.Amount - m2.Amount), m1.Currency);
            return m3;
        }
        else
            return new Money(0, "null");
    }

    public static Money operator +(Money m1, Money m2)
    {
        if (m1.Currency.ToLower() == m2.Currency.ToLower())
        {
            Money m3 = new Money((m1.Amount + m2.Amount), m1.Currency);
            return m3;
        }
        else
        {
            return new Money(0, "null");
        }
    }
    public static bool operator !=(Money m1, Money m2)
    {
        if (m1.Currency.ToLower() == m2.Currency.ToLower())
        {

            return m1.Amount != m2.Amount;
        }
        else
            return true;
                
        
      
    }
    public static bool operator ==(Money m1, Money m2)
    {
        if (m1.Currency.ToLower() == m2.Currency.ToLower())
        {
            return m1.Amount == m2.Amount;
        }
        else
            return false;
      
    }
    public static bool operator >(Money m1, Money m2)
    {
        if (m1.Currency.ToLower() == m2.Currency.ToLower())
        {
            return m1.Amount>m2.Amount;
        }
        else
            return false;


    }
    public static bool operator <(Money m1, Money m2)
    {
        if (m1.Currency.ToLower() == m2.Currency.ToLower())
        {
            return m1.Amount<m2.Amount ;

        }
        else
            return false;
        

    }
    public override string ToString()
    {
        return $"Amount is {Amount}, Currency is :{Currency}";
    }

}