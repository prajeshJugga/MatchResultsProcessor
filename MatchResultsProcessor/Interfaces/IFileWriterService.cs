using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.Interfaces
{
    public interface IFileWriterService<FileObject> where FileObject : IFileObject
    {
        void WriteFile(string outputFilePath);
    }
}
