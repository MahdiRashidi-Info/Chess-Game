using System;
using System.Linq;
using ChessGame.UserInterface.Controllers;
using RTLTMPro;
using UnityEngine;

namespace ChessGame.UserInterface.Components
{
    [RequireComponent(typeof(RTLTextMeshPro))]
    public class LanguageComponent : MonoBehaviour
    {
        [SerializeField] private string key;
        
        
        private RTLTextMeshPro _text;

        private void OnEnable()
        {
            _text = GetComponent<RTLTextMeshPro>();
            var specificWordValue = MultiLanguageController.Instance.GetSpecificWordValue(key);
            var firstOrDefault = specificWordValue.FirstOrDefault(x => x.lang_key ==MultiLanguageController.Instance.CurrentLanguage);
            _text.text = firstOrDefault.lang_value;
            
        }
    }
}