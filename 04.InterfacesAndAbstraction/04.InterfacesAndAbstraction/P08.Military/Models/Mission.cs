using System;
using System.Text;

namespace P08.Military.Models
{
    public class Mission
    {
        private string state;
        public string CodeName { get; private set; }
        public string State
        {
            get { return this.state; }
            set
            {
                if (value.ToLower() != "inprogress" && value.ToLower() != "finished")
                {
                    throw new ArgumentException("Invalid Mission State!");
                }
                this.state = value;
            }
        }

        public Mission(string codeName)
        {
            this.CodeName = codeName;
            this.State = "inProgress";
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"  Code Name: {this.CodeName} State: {this.State}");
            return sb.ToString();
        }
    }
}
