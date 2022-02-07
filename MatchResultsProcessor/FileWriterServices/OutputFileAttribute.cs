using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.FileWriterServices
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class OutputFileAttribute : Attribute
    {
        public OutputFileAttribute()
        {

        }
    }
}
