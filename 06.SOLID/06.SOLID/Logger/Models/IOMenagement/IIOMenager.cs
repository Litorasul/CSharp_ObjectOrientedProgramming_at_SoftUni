using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models.IOMenagement
{
    public class IOMenager : IIOMenager
    {
        private string curentPath;
        private string curentDirectory;
        private string curentFile;
        private IOMenager()
        {
            this.curentPath = this.GetCurrentPath();
        }
        public IOMenager(string curentDirectory, string curentFile)
            : this()
        {
            this.curentDirectory = curentDirectory;
            this.curentFile = curentFile;
        }
        public string CurentDirectoryPath => this.curentPath + this.curentDirectory;

        public string CurentFilePath => this.CurentDirectoryPath + this.curentFile;

        public void EnsureDirectoryAndPathExist()
        {
            if (!Directory.Exists(this.CurentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurentDirectoryPath);
            }
            File.WriteAllText(this.CurentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
