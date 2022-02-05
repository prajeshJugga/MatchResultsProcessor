using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.Interfaces
{
    internal interface IFileReader<FileObject> where FileObject : IFileObject
    {
        List<FileObject> GetFileObjects(string FilePath);
    }
}
