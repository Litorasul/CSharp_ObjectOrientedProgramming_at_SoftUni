namespace P08.Military.Contracts 
{
    public interface IPrivate : ISoldier 
    {
        decimal Salary { get; }

        string ToString();
    }
}