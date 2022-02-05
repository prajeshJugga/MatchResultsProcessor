using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.Interfaces
{
    internal interface IFileReader
    {
        List<IFileObject> GetFileObjects();
    }
}
