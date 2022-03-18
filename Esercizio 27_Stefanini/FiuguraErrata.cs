using System;
using System.Runtime.Serialization;

namespace Esercizio_27_Stefanini
{
    [Serializable]
    internal class FiuguraErrata : Exception
    {
        public FiuguraErrata()
        {
        }

        public FiuguraErrata(string message) : base(message)
        {
            Console.WriteLine();
        }

        public FiuguraErrata(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FiuguraErrata(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}