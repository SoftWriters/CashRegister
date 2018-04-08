using System;

namespace CreativeCashDrawSolutions.Entities.Exceptions
{
    [Serializable]
    public class NoPossibleSolutionException : Exception
    {
        public NoPossibleSolutionException() { }
        public NoPossibleSolutionException(string message) : base(message) { }
        public NoPossibleSolutionException(string message, Exception inner) : base(message, inner) { }
    }
}
