using System;
using UnityEngine;

namespace GF.Library.i18n
{
    [Serializable]
    public class Locale : ILocale
    {
        [SerializeField] private string name = string.Empty;
        [SerializeField] private string key = string.Empty;
        [SerializeField] private TextAsset source = null;

        public string Name => name;
        public string Key => key;
        public TextAsset Source => source;
    }
}