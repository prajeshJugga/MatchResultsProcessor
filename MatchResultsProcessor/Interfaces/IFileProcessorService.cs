using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.Interfaces
{
    public interface IFileProcessorService<InputObject, OutputObject> 
        where InputObject : IFileObject
        where OutputObject : IDto
    {
        List<OutputObject> ProcessFile(List<InputObject> inputObjects);
    }
}
