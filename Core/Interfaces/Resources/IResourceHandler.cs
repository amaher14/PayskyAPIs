using Core.Interfaces.Constants;

namespace Core.Interfaces
{
    public interface IResourceHandler
    {
        string GetError(string key);
        string GetInfo(string key);
        string GetError(string key, string culture = SupportedLanguage.en);
        string GetInfo(string key, string culture = SupportedLanguage.en);
        string GetArInfo(string key);
    }
}
