using System.Text.Json.Serialization;

namespace Task19_Serialization
{
    public class Product
    {
        public int Id { get; set; }

        [JsonPropertyName("product_name")]
        public string? Name { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        // XmlSerializer needs a parameterless constructor
        public Product()
        {
        }

        public Product(int id, string? name, double price, string? description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name ?? "No Name"}, Price: {Price}, Description: {Description ?? "No Description"}";
        }
    }
}