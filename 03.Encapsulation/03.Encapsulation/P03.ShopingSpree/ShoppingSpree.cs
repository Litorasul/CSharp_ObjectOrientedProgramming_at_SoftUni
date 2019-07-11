using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ShopingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] personsInfo = Console.ReadLine()
                 .Split(";", StringSplitOptions.RemoveEmptyEntries);
                string[] productsInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                var peopleList = new List<Person>();
                var productList = new List<Product>();

                foreach (var person in personsInfo)
                {
                    string[] tokens = person
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    int money = int.Parse(tokens[1]);
                    var pers = new Person(name, money);
                    peopleList.Add(pers);
                }

                foreach (var product in productsInfo)
                {
                    string[] tokens = product
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    int cost = int.Parse(tokens[1]);
                    var prod = new Product(name, cost);
                    productList.Add(prod);
                }

                string command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandInfo = command
                        .Split();

                    string name = commandInfo[0];
                    string product = commandInfo[1];

                    var curentPerson = peopleList
                        .Where(x => x.Name == name).FirstOrDefault();

                    var curentProduct = productList
                        .Where(y => y.Name == product).FirstOrDefault();
                    if (curentPerson == null)
                    {
                        throw new NullReferenceException();
                    }

                    if (curentProduct == null)
                    {
                        throw new NullReferenceException();
                    }

                    if (curentProduct.Cost > curentPerson.Money)
                    {
                        Console.WriteLine($"{curentPerson.Name} can't afford {curentProduct.Name}");
                        continue;
                    }

                    curentPerson.BuyProduct(curentProduct);
                }

                foreach (var person in peopleList)
                {
                    if (person.Products.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");                       
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                    }            
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
               
                
            }
        }
    }
}
