using System.Linq;
using TMPro;
using UnityEngine;

namespace GF.Library.i18n.UI
{
    public class SetLocaleDropdownTextMesh : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropdown = null;
        [SerializeField] private LocalisationScriptableObject localisationService = null;


        private void Start()
        {
            SetOptions();
            dropdown.onValueChanged.AddListener(x => ValueChanged(dropdown));
        }


        private void SetOptions()
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(localisationService.Locales.Select(x => x.Name ).ToList());
        }


        private void ValueChanged(TMP_Dropdown change)
        {
            var locale = localisationService.Locales.FirstOrDefault(x => x.Name == change.options[change.value].text);
            localisationService.Load(locale?.Key);
        }
    }
}