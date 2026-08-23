using Task15_CollectionsDataStructures;

class Program
{
    static void Main(string[] args)
    {
        List<Contact> c= new List<Contact>();
        c.Add(new Contact(1,"Abood","abood1@gmail.com","Amman"));
        c.Add(new Contact(2,"zaid","abood2@gmail.com","Zarqa"));
        c.Add(new Contact(3,"qasem","abood3@gmail.com","Balqa"));
        c.Add(new Contact(4,"qq","abood4@gmail.com","Jarash"));
        Contact c1 =new Contact();
        foreach (var item in c)
        {
            
            if (item.Id == 3)
            {
                Console.WriteLine(item.ToString());
            }
                
        }
        foreach (var item in c)
        {
            if (item.Id == 3)
            {
                c.Equals(c1);
            }
            Console.WriteLine(item.ToString());
        }
        
        
    }
}