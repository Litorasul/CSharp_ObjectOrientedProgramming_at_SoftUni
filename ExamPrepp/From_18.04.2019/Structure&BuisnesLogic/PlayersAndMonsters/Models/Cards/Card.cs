﻿using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using PlayersAndMonsters.Common;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
           get => name;
           private set
           {
               if (string.IsNullOrEmpty(value))
               {
                   throw new ArgumentException("Card's name cannot be null or an empty string.");
               }

               name = value;
           }
        }

        public int DamagePoints
        {
            get => damagePoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }
                damagePoints = value;
            } 
        }

        public int HealthPoints
        {
            get => healthPoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }

                healthPoints = value;
            } 
        }

        public override string ToString()
        {
            return string.Format(ConstantMessages.CardReportInfo,
                this.Name, this.DamagePoints);
        }
    }
}