using System;
using System.Collections.Generic;
using ChessGame.Extensions;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame.UserInterface.Views
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Button backBtn;
        [SerializeField] private Button watchAdsBtn;
        [SerializeField] private List<Button> coinPacks;
        [SerializeField] private RTLTextMeshPro coinText;

        public static ShopView Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void Open(int coinValue)
        {
            gameObject.SetActive(true);
            coinText.text = coinValue.ToString();
            backBtn.AddCustomListener(Close);
            
            watchAdsBtn.AddCustomListener(() => { });
            // watchAdsBtn.AddCustomListener(() => { });
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}