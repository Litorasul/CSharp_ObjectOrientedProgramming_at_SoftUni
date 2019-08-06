using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double Hp = 200;
        private readonly double normalAttackPoints;
        private readonly double normalDefensePoints;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, Hp)
        {
            AggressiveMode = true;
            normalAttackPoints = attackPoints;
            normalDefensePoints = defensePoints;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                AttackPoints = Math.Max(0, this.AttackPoints - 50);
                DefensePoints += 25;
                AggressiveMode = false;
            }
            else
            {
                AttackPoints += 50;
                DefensePoints = Math.Max(0,this.DefensePoints - 25);
                AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            string aggressiveModeCondition;
            aggressiveModeCondition = AggressiveMode ? "ON" : "OFF";

            string result;
            result = base.ToString() + Environment.NewLine + $" *Aggressive: {aggressiveModeCondition}";
            return result;
        }
    }
}
