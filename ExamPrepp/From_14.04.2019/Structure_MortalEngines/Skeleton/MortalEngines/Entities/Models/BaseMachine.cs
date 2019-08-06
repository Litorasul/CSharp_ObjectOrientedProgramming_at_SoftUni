using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints,
            double defensePoints, double healthPoints)
        {
            Name = name;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            HealthPoints = healthPoints;
            Targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "Machine name cannot be null or empty.");
                }
                name = value;
            }
        }

        public IPilot Pilot
        {
            get => pilot;
            set => pilot = value ?? throw new NullReferenceException("Pilot cannot be null.");
        }

        public double HealthPoints { get; set; }
        public double AttackPoints { get; protected set; }
        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double damage = Math.Max(0, AttackPoints - target.DefensePoints);
           

            if (target.HealthPoints < damage)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= damage;
            }
            Targets.Add(target.Name);

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"- {Name}");
            result.AppendLine($" *Type: {GetType().Name}");
            result.AppendLine($" *Health: {HealthPoints:F2}");
            result.AppendLine($" *Attack: {AttackPoints:F2}");
            result.AppendLine($" *Defense: {DefensePoints:F2}");
            result.Append(" *Targets: ");
            if (Targets.Count == 0)
            {
                result.Append("None");
            }
            else
            {
                result.Append(string.Join(", ", Targets));
            }

            return result.ToString().Trim();
        }
    }
}
