using System;

namespace StatePattern
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message) : base(message)
        {
        }
    }
}