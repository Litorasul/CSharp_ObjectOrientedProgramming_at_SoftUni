using P08.Military.Models;
using System.Collections.Generic;

namespace P08.Military.Contracts
{
    public interface IEngineer
    {
        List<Repair> Repairs { get; }

        void AddRepair(Repair repair);
        string ToString();
    }
}