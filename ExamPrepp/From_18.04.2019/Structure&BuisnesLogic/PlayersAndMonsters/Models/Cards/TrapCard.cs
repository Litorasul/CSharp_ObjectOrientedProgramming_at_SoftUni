namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int InitialDamage = 120;
        private const int InitialHp = 5;
        public TrapCard(string name)
            : base(name, InitialDamage, InitialHp)
        {
        }
    }
}