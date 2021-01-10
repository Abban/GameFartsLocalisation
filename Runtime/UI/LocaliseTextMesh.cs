using GF.Library.EventManagement;
using UnityEngine;
using TMPro;

namespace GF.Library.i18n.UI
{
    public class LocaliseTextMesh : MonoBehaviour
    {
        [SerializeField] private LocalisationScriptableObject localisationService = null;
        [SerializeField] private EventBusScriptableObject eventBus = null;
        [SerializeField] private TextMeshProUGUI text = null;
        [SerializeField] private string languageItem = string.Empty;


        private void Awake()
        {
            eventBus.Subscribe<LocaleChangedEvent>(OnLocaleChanged);
        }

        
        private void Start()
        {
            SetText();
        }


        private void OnDestroy()
        {
            eventBus.Unsubscribe<LocaleChangedEvent>(OnLocaleChanged);
        }

        
        private void OnLocaleChanged(LocaleChangedEvent localeChangedEvent)
        {
            SetText();
        }


        private void SetText()
        {
            text.text = localisationService.GetItem(languageItem);
        }
    }
}