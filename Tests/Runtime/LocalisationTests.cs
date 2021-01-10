using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;

namespace GF.Library.i18n.Tests
{
    [TestFixture]
    public class LocalisationTests
    {
        private TestDataScriptableObject _testData;
        
        private const string EnKey = "en_GB";
        private const string DeKey = "de_DE";
        private const string ItemKey = "test";
        private const string EnItemValue = "Testing";
        private const string DeItemValue = "Testen";
        
        private class TestLocale : ILocale
        {
            public TestLocale(
                string name,
                string key,
                TextAsset source)
            {
                Name = name;
                Key = key;
                Source = source;
            }

            public string Name { get; }
            public string Key { get; }
            public TextAsset Source { get; }
        }

        [SetUp]
        public void Setup()
        {
            _testData = Resources.Load<TestDataScriptableObject>("TestData");
        }

        [Test]
        public void OnLoadValidLocale_LoadsLanguageItems()
        {
            var localisation = new Localisation(_testData.Locales);
            localisation.Load(EnKey);
            
            Assert.That(localisation.GetItem(ItemKey) == EnItemValue);
        }


        [Test]
        public void OnLoadInvalidLocale_ThrowsException()
        {
            var localisation = new Localisation(_testData.Locales);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                localisation.Load("NOT A LOCALE");
            });
        }


        [Test]
        public void OnLoadLocaleWithMissingSource_ThrowsException()
        {
            var locales = new List<ILocale>
            {
                new TestLocale("test", "test", null)
            };
            
            var localisation = new Localisation(locales);
            
            Assert.Throws<FileNotFoundException>(() =>
            {
                localisation.Load("test");
            });
        }


        [Test]
        public void OnGetItem_ReturnsLanguageItem()
        {
            var localisation = new Localisation(_testData.Locales);
            localisation.Load(EnKey);
            
            Assert.That(localisation.GetItem(ItemKey) == EnItemValue);
        }


        [Test]
        public void OnGetMissingItem_ThrowsException()
        {
            var localisation = new Localisation(_testData.Locales);
            localisation.Load(EnKey);
            
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                localisation.GetItem("NOT A KEY");
            });
        }
    }
}