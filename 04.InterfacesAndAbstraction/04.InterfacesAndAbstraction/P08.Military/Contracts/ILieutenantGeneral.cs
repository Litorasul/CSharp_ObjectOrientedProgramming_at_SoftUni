using P08.Military.Models;
using System.Collections.Generic;

namespace P08.Military.Contracts
{
    public interface ILieutenantGeneral
    {
        HashSet<Private> Platoon { get; }
        decimal Salary { get; }

        void AddPrivate(Private pr);
        string ToString();
    }
}