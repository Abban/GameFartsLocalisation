using GF.Library.i18n;
using UnityEngine;

namespace Localisation
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LocalisationScriptableObject localisationService = null;

        private void Awake()
        {
            localisationService.Initialise("en_GB");
        }
    }
}