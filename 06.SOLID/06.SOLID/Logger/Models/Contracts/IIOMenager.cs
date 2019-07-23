namespace Logger.Models.Contracts
{
    public interface IIOMenager
    {
        string CurentDirectoryPath { get; }
        string CurentFilePath { get; }
        void EnsureDirectoryAndPathExist();
        string GetCurrentPath();
    }
}
