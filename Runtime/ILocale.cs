using UnityEngine;

namespace GF.Library.i18n
{
    public interface ILocale
    {
        string Name { get; }
        string Key { get; }
        TextAsset Source { get; }
    }
}