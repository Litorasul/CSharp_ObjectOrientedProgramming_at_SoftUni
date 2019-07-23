using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        public string Path => throw new NotImplementedException();

        public ulong Size => throw new NotImplementedException();

        public string Write(ILayout layout, IError error)
        {
            throw new NotImplementedException();
        }
    }
}
