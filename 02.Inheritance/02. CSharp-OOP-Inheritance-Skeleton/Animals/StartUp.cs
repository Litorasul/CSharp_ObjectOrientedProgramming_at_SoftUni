using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            var animals = new Dictionary<string, List<Animal>>();
           

            try
            {
                while ((input = Console.ReadLine()) != "Beast!")
                {
                    var tokens = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);

                    if (input == "Dog")
                    {
                        string gender = tokens[2];
                        Dog dog = new Dog(name, age, gender);
                        if (Dog.List.Count == 0)
                        {
                            Dog.List = new List<Dog>
                            {
                                dog
                            };
                            
                        }
                        else
                        {
                            Dog.List.Add(dog);
                        }
                       
                    }
                    else if (input == "Cat")
                    {
                        string gender = tokens[2];
                        Cat cat = new Cat(name, age, gender);
                        if (Cat.List.Count == 0)
                        {
                            Cat.List = new List<Cat>
                            {
                                cat
                            };
                        }
                        else
                        {
                            Cat.List.Add(cat);
                        }
                    }
                    else if (input == "Frog")
                    {
                        string gender = tokens[2];
                        Frog frog = new Frog(name, age, gender);
                        if (Frog.List.Count == 0)
                        {
                            Frog.List = new List<Frog>
                            {
                                frog
                            };
                        }
                        else
                        {
                            Frog.List.Add(frog);
                        }
                    }
                    else if (input == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        if (Kitten.List.Count == 0)
                        {
                            Kitten.List = new List<Kitten>
                            {
                                kitten
                            };
                        }
                        else
                        {
                            Kitten.List.Add(kitten);
                        }
                    }
                    else if (input == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        if (Tomcat.List.Count == 0)
                        {
                            Tomcat.List = new List<Tomcat>
                            {
                                tomcat
                            };
                        }
                        else
                        {
                            Tomcat.List.Add(tomcat);
                        }
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Invalid input!");
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
