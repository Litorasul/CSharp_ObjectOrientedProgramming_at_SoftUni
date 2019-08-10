using System;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            IsPlayerDead(attackPlayer);
            IsPlayerDead(enemyPlayer);
            IsPlayerBeginner(attackPlayer);
            IsPlayerBeginner(enemyPlayer);
            GetBonusHp(attackPlayer);
            GetBonusHp(enemyPlayer);
            int attackerFullDamage = TakeFullDamage(attackPlayer);
            int enemyFullDamage = TakeFullDamage(enemyPlayer);
            while (true)
            {
                enemyPlayer.TakeDamage(attackerFullDamage);
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                attackPlayer.TakeDamage(enemyFullDamage);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }

        }

        private int TakeFullDamage(IPlayer player)
        {
            int result = 0;
            foreach (var card in player.CardRepository.Cards)
            {
                result += card.DamagePoints;
            }

            return result;
        }

        private void GetBonusHp(IPlayer player)
        {
            foreach (var card in player.CardRepository.Cards)
            {
                player.Health += card.HealthPoints;
            }
        }

        private void IsPlayerBeginner(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private void IsPlayerDead(IPlayer player)
        {
            if (player.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
        }
    }
}