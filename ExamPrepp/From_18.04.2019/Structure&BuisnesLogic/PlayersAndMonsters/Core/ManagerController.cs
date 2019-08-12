using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System.Text;

namespace PlayersAndMonsters.Core
{

    using Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IBattleField battleField;
        public ManagerController(IPlayerRepository playerRepository,
            ICardRepository cardRepository, IPlayerFactory playerFactory,
            ICardFactory cardFactory, IBattleField battleField)
        {
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);
            return string
                .Format(ConstantMessages.SuccessfullyAddedPlayer, player.GetType().Name, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            return string
                .Format(ConstantMessages.SuccessfullyAddedCard, card.GetType().Name, name);
        }

        //Possible mistake 
        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);

            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string
                .Format(ConstantMessages.SuccessfullyAddedPlayerWithCards,
                    card.Name, player.Username);

        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);
            return string
                .Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(player.ToString());
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }

            }

            sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));

            return sb.ToString().TrimEnd();
        }
    }
}
