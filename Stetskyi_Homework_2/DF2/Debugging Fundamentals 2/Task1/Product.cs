using System;

namespace Task1
{
    public class Product
    {
        private string _Name;
        private double _Price;
        public string Name 
        { 
            get { return _Name; } 
            set { _Name = value; } 
        }
        public double Price
        {
            get { return _Price; }
            set 
            {
                if (value >= 0)
                {
                    _Price = value;
                }
                else
                {
                    throw new ArgumentException("negative price exception");
                }
            }
        }

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
