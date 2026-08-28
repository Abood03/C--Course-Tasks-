using Task15_CollectionsDataStructures;

class Program
{
    static void Main(string[] args)
    {
        // =====================================================
        // 1. List<Contact>
        // Main contact list
        // =====================================================

        List<Contact> c = new List<Contact>();

        // Add
        c.Add(new Contact(1, "Abood", "abood1@gmail.com", "Amman"));
        c.Add(new Contact(2, "Zaid", "abood2@gmail.com", "Zarqa"));
        c.Add(new Contact(3, "Qasem", "abood3@gmail.com", "Balqa"));
        c.Add(new Contact(4, "QQ", "abood4@gmail.com", "Jarash"));
        c.Add(new Contact(5, "Ali", "ali@gmail.com", "Amman"));


        // Search in List by Id
        Console.WriteLine("List Search");

        foreach (var item in c)
        {
            if (item.Id == 3)
            {
                Console.WriteLine(item);
            }
        }


        // Remove from List by Id
        Contact? contactToRemove = null;

        foreach (var item in c)
        {
            if (item.Id == 4)
            {
                contactToRemove = item;
            }
        }

        if (contactToRemove != null)
        {
            c.Remove(contactToRemove);
        }


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 2. Dictionary<string, List<Contact>>
        // Group contacts by city
        // =====================================================

        Dictionary<string, List<Contact>> cityContacts =
            new Dictionary<string, List<Contact>>();


        // Add contacts to Dictionary
        foreach (var item in c)
        {
            if (cityContacts.ContainsKey(item.City))
            {
                cityContacts[item.City].Add(item);
            }
            else
            {
                cityContacts.Add(item.City, new List<Contact>());
                cityContacts[item.City].Add(item);
            }
        }


        // Search by city
        Console.WriteLine("Dictionary Search");

        if (cityContacts.ContainsKey("Amman"))
        {
            foreach (var item in cityContacts["Amman"])
            {
                Console.WriteLine(item);
            }
        }


        // Remove city from Dictionary
        cityContacts.Remove("Zarqa");


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 3. Stack<string>
        // Undo history
        // =====================================================

        Stack<string> undoHistory = new Stack<string>();


        // Add
        undoHistory.Push("Add Contact 1");
        undoHistory.Push("Add Contact 2");
        undoHistory.Push("Remove Contact 4");


        // Search
        Console.WriteLine("Stack Search");

        if (undoHistory.Contains("Add Contact 2"))
        {
            Console.WriteLine("Operation Found");
        }


        // Remove
        string lastOperation = undoHistory.Pop();

        Console.WriteLine("Removed from Stack:");
        Console.WriteLine(lastOperation);


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 4. Queue<string>
        // Pending operations
        // =====================================================

        Queue<string> pendingOperations = new Queue<string>();


        // Add
        pendingOperations.Enqueue("Send Email to Abood");
        pendingOperations.Enqueue("Send Email to Zaid");
        pendingOperations.Enqueue("Update Contact");


        // Search
        Console.WriteLine("Queue Search");

        if (pendingOperations.Contains("Update Contact"))
        {
            Console.WriteLine("Pending Operation Found");
        }


        // Remove
        string firstOperation = pendingOperations.Dequeue();

        Console.WriteLine("Removed from Queue:");
        Console.WriteLine(firstOperation);


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 5. HashSet<string>
        // Store unique emails
        // =====================================================

        HashSet<string> emails = new HashSet<string>();


        // Add
        foreach (var item in c)
        {
            emails.Add(item.Email);
        }


        // Search
        Console.WriteLine("HashSet Search");

        if (emails.Contains("abood3@gmail.com"))
        {
            Console.WriteLine("Email Found");
        }


        // Remove
        emails.Remove("abood3@gmail.com");


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 6. LinkedList<Contact>
        // Favorite contacts
        // =====================================================

        LinkedList<Contact> favorites = new LinkedList<Contact>();


        // Add
        favorites.AddLast(c[0]);
        favorites.AddLast(c[1]);


        // Search
        Console.WriteLine("LinkedList Search");

        foreach (var item in favorites)
        {
            if (item.Id == 2)
            {
                Console.WriteLine(item);
            }
        }


        // Remove
        favorites.Remove(c[1]);


        Console.WriteLine("-----------------------------");


        // Display remaining favorite contacts
        Console.WriteLine("Favorites");

        foreach (var item in favorites)
        {
            Console.WriteLine(item);
        }
    }
}