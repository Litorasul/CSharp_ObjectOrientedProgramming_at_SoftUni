namespace P08.Military.Models
{
    public interface IRepair
    {
        int HoursWorked { get; }
        string PartName { get; }

        string ToString();
    }
}