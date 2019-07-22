namespace P03.WildFarm.Models
{
    public interface IAnimal
    {
        int FoodEaten { get; }
        string Name { get; }
        double Weight { get; }

        void AskForFood();
        void Eat(IFood food);
    }
}