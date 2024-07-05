using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChessGame.Models.MultiLanguages;
using Newtonsoft.Json;
using UnityEngine;

namespace ChessGame.UserInterface.Controllers
{
    public class MultiLanguageController : MonoBehaviour
    {
        public static MultiLanguageController Instance;
        public string CurrentLanguage { get; set; }
        
        private void Awake()
        {
            Instance = this;

            var configValue = Utils.GetConfigValue();
            CurrentLanguage = configValue.lang;
        }

        public void ChangeLanguage(string newLang)
        {
            var configValue = Utils.GetConfigValue();
            configValue.lang = newLang;
            string jsonString = JsonConvert.SerializeObject(configValue);

            string path = Path.Combine(Application.dataPath, "Resources/config.json");
            File.WriteAllText(path, jsonString);
        }
        public List<Value> GetSpecificWordValue(string key)
        {
            var textAsset = Resources.Load<TextAsset>("lang");

            var wordTranslation = JsonConvert.DeserializeObject<List<WordTranslation>>(textAsset.text);
            var firstOrDefault = wordTranslation.FirstOrDefault(x => x.word_key == key);
            if(firstOrDefault is null)
                Debug.LogError($"cant find {key}");

            return firstOrDefault?.values;
        }
    }
}