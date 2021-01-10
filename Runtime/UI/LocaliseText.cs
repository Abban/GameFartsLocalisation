using GF.Library.EventManagement;
using UnityEngine;
using UnityEngine.UI;

namespace GF.Library.i18n.UI
{
    public class LocaliseText : MonoBehaviour
    {
        [SerializeField] private LocalisationScriptableObject localisationService = null;
        [SerializeField] private EventBusScriptableObject eventBus = null;
        [SerializeField] private Text text = null;
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