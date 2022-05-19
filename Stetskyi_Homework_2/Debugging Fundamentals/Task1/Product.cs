namespace Task1
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Product parsedObjectToCompare = obj as Product;
                return (Name == parsedObjectToCompare.Name) && (Price == parsedObjectToCompare.Price);
            }
        }

    }
}
