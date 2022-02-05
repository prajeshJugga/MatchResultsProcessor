using System;
using System.Runtime.Serialization;

namespace MatchResultsProcessor.FileProcessorService
{
    [Serializable]
    internal class InvalidGameLineException : Exception
    {
        public InvalidGameLineException()
        {
        }

        public InvalidGameLineException(string message) : base(message)
        {
        }

        public InvalidGameLineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGameLineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}