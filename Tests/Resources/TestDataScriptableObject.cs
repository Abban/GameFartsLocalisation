using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GF.Library.i18n.Tests
{
    // [CreateAssetMenu(fileName = "TestData", menuName = "GF/Localisation/Test Data/Localisation Test Data")]
    public class TestDataScriptableObject : ScriptableObject
    {
        [SerializeField] private List<Locale> locales = new List<Locale>();

        public List<ILocale> Locales => locales.ToList<ILocale>();
    }
}