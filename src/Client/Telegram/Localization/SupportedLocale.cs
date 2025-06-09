using DragonBot.Localization.Interfases;

namespace DragonBot.Localization
{
    internal class SupportedLocale : ISupportedLocale
    {
        public string PathToFile { get; set; }
        public string Code { get; set; }
        public string NameButton { get; set; }
        public string Message { get; set; }
    }

}
