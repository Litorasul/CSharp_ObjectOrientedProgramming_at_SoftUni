using P08.Military.Contracts;
using System.Text;

namespace P08.Military.Models
{
    public class Spy : Soldier, ISoldier, ISpy
    {
        public int CodeNumber { get; private set; }

        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            builder.AppendLine($"Code Number: {this.CodeNumber}");
            return base.ToString();
        }
    }
}
