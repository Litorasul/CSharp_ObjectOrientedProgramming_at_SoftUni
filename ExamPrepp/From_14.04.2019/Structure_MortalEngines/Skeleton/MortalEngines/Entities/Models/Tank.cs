using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Tank : BaseMachine, ITank
    {
        private const double Hp = 100;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, Hp)
        {
            DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                AttackPoints += 40;
                DefensePoints = Math.Max(0, this.DefensePoints - 30);
                DefenseMode = false;
            }
            else
            {
                AttackPoints = Math.Max(0, this.AttackPoints - 40);
                DefensePoints += 30;
                DefenseMode = true;
            }
        }

        public override string ToString()
        {
            string defenseModeCondition;
            defenseModeCondition = DefenseMode ? "ON" : "OFF";

            string result;
            result = base.ToString() + Environment.NewLine + $" *Defense: {defenseModeCondition}";
            return result;
        }
    }
}
