using System.Collections.Generic;

namespace P08.Military.Models
{
    public interface ICommando
    {
        List<Mission> Missions { get; }

        void AddMission(Mission mission);
        string ToString();
    }
}