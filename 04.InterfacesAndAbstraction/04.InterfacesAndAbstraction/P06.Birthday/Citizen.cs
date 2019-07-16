namespace P06.Birthday
{
    public class Citizen : IIdentifiable
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Bitrhday { get; private set; }

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Bitrhday = birthday;
          
        }

        public override string ToString()
        {
            return this.Bitrhday;
        }
    }
}
