using System.Text;

namespace P03.Ferrari
{
    public class Ferrari : ICar
    {
        public string Model { get; private set; }

        public string Driver { get; private set; }

        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;            
        }

        public string PushTheGas()
        {
            return "Gas!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Model}/{UseBrakes()}/{PushTheGas()}/{this.Driver}");

            return sb.ToString();
        }
    }
}
