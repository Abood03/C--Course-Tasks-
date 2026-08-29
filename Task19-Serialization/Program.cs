using System.Text.Json;
using System.Xml.Serialization;
using Task19_Serialization;

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();

        products.Add(new Product(1, "Laptop", 800, "Gaming Laptop"));
        products.Add(new Product(2, "Phone", 500, null));
        products.Add(new Product(3, null, 100, "Product without name"));


        // =====================================================
        // 1. JSON Serialization
        // =====================================================

        JsonSerializerOptions options = new JsonSerializerOptions();

        options.WriteIndented = true;


        string json = JsonSerializer.Serialize(products, options);

        File.WriteAllText("products.json", json);


        Console.WriteLine("JSON Serialized");

        Console.WriteLine(json);


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 2. JSON Deserialization
        // =====================================================

        string jsonFile = File.ReadAllText("products.json");

        List<Product>? jsonProducts =
            JsonSerializer.Deserialize<List<Product>>(jsonFile);


        Console.WriteLine("JSON Deserialized");


        if (jsonProducts != null)
        {
            foreach (var item in jsonProducts)
            {
                Console.WriteLine(item);
            }
        }


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 3. XML Serialization
        // =====================================================

        XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(List<Product>));


        using (FileStream file =
               new FileStream("products.xml", FileMode.Create))
        {
            xmlSerializer.Serialize(file, products);
        }


        Console.WriteLine("XML Serialized");


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 4. XML Deserialization
        // =====================================================

        List<Product>? xmlProducts;


        using (FileStream file =
               new FileStream("products.xml", FileMode.Open))
        {
            xmlProducts =
                xmlSerializer.Deserialize(file) as List<Product>;
        }


        Console.WriteLine("XML Deserialized");


        if (xmlProducts != null)
        {
            foreach (var item in xmlProducts)
            {
                Console.WriteLine(item);
            }
        }


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 5. Missing field example
        // =====================================================

        string missingFieldJson =
            """
            {
                "Id": 10,
                "product_name": "Mouse",
                "Price": 20
            }
            """;


        Product? missingProduct =
            JsonSerializer.Deserialize<Product>(missingFieldJson);


        Console.WriteLine("Missing Field Example");

        if (missingProduct != null)
        {
            Console.WriteLine(missingProduct);
        }


        Console.WriteLine("-----------------------------");


        // =====================================================
        // 6. Null value example
        // =====================================================

        string nullJson =
            """
            {
                "Id": 11,
                "product_name": null,
                "Price": 50,
                "Description": null
            }
            """;


        Product? nullProduct =
            JsonSerializer.Deserialize<Product>(nullJson);


        Console.WriteLine("Null Value Example");

        if (nullProduct != null)
        {
            Console.WriteLine(nullProduct);
        }
    }
}