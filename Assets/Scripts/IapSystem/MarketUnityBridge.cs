using System;
using BazaarPlugin;
using ChessGame;
using MyketPlugin;
using UnityEngine;

namespace IapSystem
{
    public class MarketUnityBridge : MonoBehaviour
    {
        public Action ConsumeFailure;
        public Action ConsumeSuccess;
        public Action PurchaseFailure;
        public Action<string> PurchaseSucceed;

        private string _iap;

        private void Awake()
        {
            _iap = Utils.GetConfigValue().iap;
            DontDestroyOnLoad(gameObject);
        }

        public void Start()
        {
#if UNITY_ANDROID
            switch (_iap)
            {
                case "bazaar":
                    BazaarPlugin.IABEventManager.purchaseSucceededEvent +=
                        BazaarIABEventManagerOnpurchaseSucceededEvent;
                    BazaarPlugin.IABEventManager.purchaseFailedEvent += BazaarIABEventManagerOnPurchaseFailedEvent;

                    BazaarPlugin.IABEventManager.consumePurchaseSucceededEvent +=
                        BazaarIABEventManagerOnconsumePurchaseSucceededEvent;
                    BazaarPlugin.IABEventManager.consumePurchaseFailedEvent +=
                        BazaarIABEventManagerOnconsumePurchaseFailedEvent;
                    break;
                case "myket":
                    MyketPlugin.IABEventManager.purchaseSucceededEvent += MyketIABEventManagerOnPurchaseSucceededEvent;
                    MyketPlugin.IABEventManager.purchaseFailedEvent += MyketIABEventManagerOnPurchaseFailedEvent;

                    MyketPlugin.IABEventManager.consumePurchaseSucceededEvent +=
                        MyketIABEventManagerOnconsumePurchaseSucceededEvent;
                    MyketPlugin.IABEventManager.consumePurchaseFailedEvent +=
                        MyketIABEventManagerOnconsumePurchaseFailedEvent;
                    break;
            }
#endif
        }

#if UNITY_ANDROID
        private void BazaarIABEventManagerOnconsumePurchaseFailedEvent(string obj)
        {
            Debug.LogError(_iap + " purchase failed, error: " + obj);
            ConsumeFailure?.Invoke();
        }

        private void BazaarIABEventManagerOnconsumePurchaseSucceededEvent(BazaarPurchase obj)
        {
            ConsumeSuccess?.Invoke();
        }

        private void BazaarIABEventManagerOnpurchaseSucceededEvent(BazaarPurchase pa)
        {
            PurchaseSucceed?.Invoke(pa.PurchaseToken);
        }

        private void BazaarIABEventManagerOnPurchaseFailedEvent(string obj)
        {
            Debug.LogError(_iap + " purchase failed, error: " + obj);
            PurchaseFailure?.Invoke();
        }


        private void MyketIABEventManagerOnPurchaseSucceededEvent(MyketPurchase pa)
        {
            PurchaseSucceed?.Invoke(pa.PurchaseToken);
        }

        private void MyketIABEventManagerOnPurchaseFailedEvent(string obj)
        {
            Debug.LogError(_iap + " purchase failed, error: " + obj);
            PurchaseFailure?.Invoke();
        }

        private void MyketIABEventManagerOnconsumePurchaseFailedEvent(string obj)
        {
            Debug.LogError(_iap + " purchase failed, error: " + obj);
            ConsumeFailure?.Invoke();
        }

        private void MyketIABEventManagerOnconsumePurchaseSucceededEvent(MyketPurchase obj)
        {
            ConsumeSuccess?.Invoke();
        }
#endif


        private void OnDestroy()
        {
#if UNITY_ANDROID
            switch (_iap)
            {
                case "bazaar":
                    BazaarPlugin.IABEventManager.purchaseSucceededEvent -=
                        BazaarIABEventManagerOnpurchaseSucceededEvent;
                    BazaarPlugin.IABEventManager.purchaseFailedEvent -= BazaarIABEventManagerOnPurchaseFailedEvent;

                    BazaarPlugin.IABEventManager.consumePurchaseSucceededEvent -=
                        BazaarIABEventManagerOnconsumePurchaseSucceededEvent;
                    BazaarPlugin.IABEventManager.consumePurchaseFailedEvent -=
                        BazaarIABEventManagerOnconsumePurchaseFailedEvent;
                    break;
                case "myket":
                    MyketPlugin.IABEventManager.purchaseSucceededEvent -= MyketIABEventManagerOnPurchaseSucceededEvent;
                    MyketPlugin.IABEventManager.purchaseFailedEvent -= MyketIABEventManagerOnPurchaseFailedEvent;


                    MyketPlugin.IABEventManager.consumePurchaseSucceededEvent -=
                        MyketIABEventManagerOnconsumePurchaseSucceededEvent;
                    MyketPlugin.IABEventManager.consumePurchaseFailedEvent -=
                        MyketIABEventManagerOnconsumePurchaseFailedEvent;
                    break;
            }
#endif
        }
    }
}