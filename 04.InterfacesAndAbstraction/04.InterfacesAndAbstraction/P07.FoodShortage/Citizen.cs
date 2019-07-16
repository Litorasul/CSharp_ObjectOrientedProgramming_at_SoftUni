namespace P07.FoodShortage
{
    public class Citizen : IBuyer
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Bitrhday { get; private set; }

        public int Food { get; private set; }

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Bitrhday = birthday;
            this.Food = 0;
          
        }

        public override string ToString()
        {
            return this.Bitrhday;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
