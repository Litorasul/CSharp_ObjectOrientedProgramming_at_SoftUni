using System;
using System.Text;

namespace P08.Military.Models
{
    public class Mission 
    {
        private string state;
        public string CodeName { get; private set; }
        public string State { get; private set; }
        
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Code Name: {this.CodeName} State: {this.State}");
            return sb.ToString();
        }
    }
}
