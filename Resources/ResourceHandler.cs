using Core.Interfaces;
using Core.Interfaces.Constants;
using Resources;
using System.Resources;


namespace Resources
{
    public class ResourceHandler : IResourceHandler
    {
        public string GetError(string key)
        {
            var resourceManger = new ResourceManager(typeof(Error));
            return resourceManger.GetString(key);
        }

        public string GetInfo(string key)
        {
            var resourceManger = new ResourceManager(typeof(InfoResource));
            return resourceManger.GetString(key);
        }



        public string GetError(string key, string culture = SupportedLanguage.en)
        {
            var resourceManger = new ResourceManager(typeof(Error));
            return resourceManger.GetString(key, new System.Globalization.CultureInfo(culture));
        }

        public string GetInfo(string key, string culture = SupportedLanguage.en)
        {
            var resourceManger = new ResourceManager(typeof(InfoResource));
            return resourceManger.GetString(key, new System.Globalization.CultureInfo(culture));
        }
        public string GetMessage(string key)
        {
            var resourceManger = new ResourceManager(typeof(MessageResource));
            return resourceManger.GetString(key);
        }
        public string GetMessage(string key, string culture = SupportedLanguage.en)
        {
            var resourceManger = new ResourceManager(typeof(MessageResource));
            return resourceManger.GetString(key, new System.Globalization.CultureInfo(culture));
        }
        public string GetArInfo(string key)
        {
            string culture = "ar";
            var resourceManger = new ResourceManager(typeof(InfoResource));
            return resourceManger.GetString(key, new System.Globalization.CultureInfo(culture));
        }
    }
}
