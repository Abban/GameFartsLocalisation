using System.Collections.Generic;

namespace GF.Library.i18n
{
    public interface ILocalisation
    {
        string Name { get; }
        string Key { get; }
        List<ILocale> Locales { get; }
        void Load(string locale);
        string GetItem(string key);
    }
}