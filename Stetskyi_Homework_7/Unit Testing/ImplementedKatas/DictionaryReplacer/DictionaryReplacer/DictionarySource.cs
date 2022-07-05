using System.Collections.Generic;


namespace DictionaryReplacer
{
    public static class DictionarySource
    {
        public static Dictionary<string, string> sourceDict =
            new Dictionary<string, string>()
            {
                { "wrong", "correct" },
                { "value1","value2" },
                { "temp", "temporary" },
                { "name", "John Doe" }
            };
    }
}
