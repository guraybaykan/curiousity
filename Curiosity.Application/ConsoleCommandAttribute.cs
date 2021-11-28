using System;

namespace Curiosity.Application
{
    public class ConsoleCommandAttribute : Attribute
    {
        public ConsoleCommandAttribute(string pattern)
        {
            Pattern = pattern;
        }

        public string Pattern { get; }
    }
}
