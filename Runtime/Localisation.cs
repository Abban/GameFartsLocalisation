using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace GF.Library.i18n
{
    public class Localisation : ILocalisation
    {
        public List<ILocale> Locales { get; }
        private ILocale _locale;
        private List<LocalisationItem> _items;
        public string Name => _locale.Name;
        public string Key => _locale.Key;

        public Localisation(List<ILocale> locales)
        {
            Locales = locales;
        }

        
        public string GetItem(string key)
        {
            var item = _items.FirstOrDefault(x => x.key == key);
            
            if (item == null)
            {
                throw new ArgumentOutOfRangeException(nameof(key), key, $"Could not find specified item ({key})");	
            }
            
            return item.value;
        }


        public void Load(string locale)
        {
            _locale = Locales.FirstOrDefault(x => x.Key == locale);

            if (_locale == null)
            {
                throw new ArgumentOutOfRangeException(nameof(locale), locale, $"Could not find specified locale ({locale})");
            }

            if (_locale.Source == null)
            {
                throw new FileNotFoundException($"There is no specified source for ({_locale.Key})");
            }

            _items = JsonUtility.FromJson<LocalisationItemList>(_locale.Source.text).data;
        }
        

        [Serializable]
        public class LocalisationItemList
        {
            public List<LocalisationItem> data;
        }


        [Serializable]
        public class LocalisationItem
        {
            public string key;
            public string value;
        }
    }
}