using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.Interfaces
{
    internal interface IFileProcessorService<InputObject, OutputObject> 
        where InputObject : IFileObject
        where OutputObject : IDto
    {
        List<OutputObject> GetOutputObjects(List<InputObject> inputObjects);
    }
}
