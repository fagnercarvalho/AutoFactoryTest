using System.Threading.Tasks;

namespace AutoFactoryTest.Translation
{
    internal interface ITranslation
    {
        Task<string> Translate(string text);
    }
}
