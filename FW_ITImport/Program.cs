using System;
using System.IO;
using System.Xml.Serialization;

namespace FW_ITImport
{
    class Program
    {
        // Metode der beder brugeren om at logge ind.
        // Returnerer true, hvis brugeren via login har adgang til systemet
        static bool Login(Ordersys p_sys)
        {
            bool success = false;
            Console.Write("Username: ");
            string m_username = Console.ReadLine();
            Console.Write("Password: ");
            string m_password = Console.ReadLine();
            foreach (User m_user in p_sys.Users.User)
                if ((m_user.Name == m_username) && (m_user.Password == m_password))
                    success = true;
            return success;
        }

        // Denne metode udskriver en liste over produkter i p_sys
        static void ProductList(Ordersys p_sys)
        {
            Console.WriteLine("Product-list");
            Console.WriteLine("".PadLeft(120, '-'));
            Console.Write("ProductID");
            Console.SetCursorPosition(10, Console.CursorTop);
            Console.Write("Locat.");
            Console.SetCursorPosition(18, Console.CursorTop);
            Console.Write("Shelf");
            Console.SetCursorPosition(26, Console.CursorTop);
            Console.Write("Productname");
            Console.WriteLine();
            Console.WriteLine("".PadLeft(120, '-'));

            foreach (Product m_product in p_sys.Products.Product)
            {
                Console.Write(m_product.Pid);
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.Write(m_product.Location);
                Console.SetCursorPosition(18, Console.CursorTop);
                Console.Write(m_product.Shelf);
                Console.SetCursorPosition(26, Console.CursorTop);
                Console.Write(m_product.Name);
                Console.WriteLine();
            }
            Console.WriteLine("".PadLeft(120, '-'));
            Console.WriteLine("Number of products: " + p_sys.Products.Product.Count.ToString());
            Console.WriteLine("".PadLeft(120, '-'));
        }

        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Ordersys));
            StreamReader reader = new StreamReader("..\\..\\OrderSys_Data.xml");
            Ordersys m_sys = (Ordersys)serializer.Deserialize(reader);
            reader.Close();
            m_sys.setParents();

            if (Login(m_sys))
            {
                do
                {
                    Console.Clear();
                    ProductList(m_sys);
                    Console.WriteLine("Press any key to continue (ESC to quit).");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            else
            {
                Console.WriteLine("Username or password incorrect!");
                Console.ReadKey();
            }
        }
    }
}
