using AutoFactory;
using AutoFactoryTest.Translation;
using Nito.AsyncEx;
using System;
using System.Threading.Tasks;

namespace AutoFactoryTest
{
    class Program
    {
        private static IAutoFactory<ITranslation> factory = 
            Factory.Create<ITranslation>();

        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        static async void MainAsync(string[] args)
        {
            Console.WriteLine(await Translate("富士", "English"));
            Console.WriteLine(await Translate("box", "Portuguese"));

            Console.ReadLine();
        }

        static async Task<string> Translate(string text, string to)
        {
            var translator = factory
                .SeekPartFromAttribute<TranslationLanguageAttribute>(l => l.Name == to);

            var translation = await translator.Translate(text);

            return translation;
        }
    }
}
