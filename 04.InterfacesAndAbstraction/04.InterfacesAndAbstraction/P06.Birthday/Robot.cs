namespace P06.Birthday
{
    public class Robot 
    {
        public string Id { get; private set; }
        public string Model { get; set; }

        

        public Robot(string model, string id, string bitrhday)
        {
            this.Model = model;
            this.Id = id;
            
        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
