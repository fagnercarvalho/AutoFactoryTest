using System;

namespace AutoFactoryTest.Translation
{
    internal sealed class TranslationLanguageAttribute : Attribute
    {
        public string Name { get; set; }

        public TranslationLanguageAttribute(string name) { Name = name; }
    }
}
