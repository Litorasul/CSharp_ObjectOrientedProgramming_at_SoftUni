namespace P05.BorderControl
{
    public class Robot : IIdentifiable
    {
        public string Id { get; private set; }
        public string Model { get; set; }

    

        public Robot(string model, string id)
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
