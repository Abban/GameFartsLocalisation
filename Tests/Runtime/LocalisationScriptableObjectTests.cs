using System;
using GF.Library.EventManagement;
using NUnit.Framework;
using UnityEngine;

namespace GF.Library.i18n.Tests
{
    [TestFixture]
    public class LocalisationScriptableObjectTests
    {
        private const string English = "en_GB"; 
        private const string German = "de_DE"; 
        [Test]
        public void OnChangeLocale_FiresEvent()
        {
            var eventBus = Resources.Load<EventBusScriptableObject>("TestEventBus");
            var localisation = Resources.Load<LocalisationScriptableObject>("TestLocalisation");
            var fired = 0;

            eventBus.Subscribe<LocaleChangedEvent>(localeChangedEvent =>
            {
                fired++;
            });
            
            localisation.Load(English);
            localisation.Load(German);
            
            Assert.That(fired == 2);
        }
    }
}