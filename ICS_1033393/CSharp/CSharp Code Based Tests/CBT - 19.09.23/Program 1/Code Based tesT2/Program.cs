using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBasedTest2
{
    public class Products
    {
        public string productName; public int productID; public int productPrice;
        public Products(string pname, int pID, int pprice)
        {
            productName = pname;
            productID = pID;
            productPrice = pprice;
        }


        static void Main(string[] args)
        {
            List<Products> products = new List<Products>();
            for (int i = 0; i <= 10; i++)
            {
                Console.Write($"Enter Product-{i + 1} ID: ");
                int productid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Product Name: ");
                string productname = Console.ReadLine();
                Console.Write("Product Price: ");
                int productprice = Convert.ToInt32(Console.ReadLine());

                Products produc = new Products(productname, productid, productprice);
                products.Add(produc);
            }
            List<Products> Sorted = products.OrderBy(p => p.productPrice).ToList();

            foreach (var p in Sorted)
            {
                Console.WriteLine($"Product ID: {p.productID}    Product Name: {p.productName}    Product Price: {p.productPrice}");
            }
            Console.Read();
        }
    }

}
