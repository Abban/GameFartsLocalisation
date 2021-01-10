using System.Collections.Generic;
using System.Linq;
using GF.Library.EventManagement;
using UnityEngine;

namespace GF.Library.i18n
{
    [CreateAssetMenu(fileName = "LocalisationService", menuName = "GF/Localisation Service")]
    public class LocalisationScriptableObject : ScriptableObject, ILocalisation
    {
        [SerializeField] private EventBusScriptableObject eventBus = null;
        [SerializeField] private List<Locale> locales = new List<Locale>();

        private Localisation _localisation;

        private Localisation Localisation
        {
            get
            {
                if (_localisation == null)
                {
                    _localisation = new Localisation(locales.ToList<ILocale>());
                }

                return _localisation;
            }
        }

        public void Initialise(string locale)
        {
            Localisation.Load(locale);
        }

        public string Name => Localisation.Name;
        public string Key => Localisation.Key;
        public List<ILocale> Locales => Localisation.Locales;

        public void Load(string locale)
        {
            Localisation.Load(locale);
            eventBus.Fire(new LocaleChangedEvent());
        }
        public string GetItem(string key) => Localisation.GetItem(key);
    }
}