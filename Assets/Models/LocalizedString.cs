namespace AppSystem.Models
{

    public class LocalizedString
    {
        public string languageCode { get; set; }
        public string str { get; set; }

        public static string GetLocalizedString(LocalizedString[] localizedStrings)
        {

            for(int i = 0; i < localizedStrings.Length; i++) {
                if(localizedStrings[i].languageCode.Equals(SystemApp.LanguageCode))
                    return localizedStrings[i].str;
            }
            return localizedStrings[0].str;
        }
    }
}

