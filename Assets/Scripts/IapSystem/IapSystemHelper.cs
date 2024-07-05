using System;
using ChessGame;
using UnityEngine;

namespace IapSystem
{
    public static class IapSystemHelper
    {
        private const string MyketPublicKey =
            "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDWY94Fk2/lPV6Lz78vnF0nI8+G2TMEhwP4vQqzCI6L2W9WLWW1tLM8bjgs2dGjR6c3Akb75W7/ajdF1OS9+jVM1mNgYgR5SijJPzpbyOd5fc84/mWh4BFhN9GiFIKjJjV/DxuVWwovBP2waz93ZOG373+Ctf0ei3kHLNX7y7w23QIDAQAB";

        private const string BazaarPublicKey =
            "MIHNMA0GCSqGSIb3DQEBAQUAA4G7ADCBtwKBrwDf/AFhgMUWWchug1iKLFggHN5Y1ihRWeOo5jbm8hVr21MWEpcTnbGX+mLvewcxxhX9IC38PRdDBkOsGFrGa96Bx6PyYPHGKyax9y1hq7b8h3Ryf1tv/qE2Z6iT7BOow6Yr5YdQm2V1X8NU6wVI/7LXa8vq4uqSXX4DQVFMaMdnvD3IROVOEcrjOBst67j83Nrj8U1NEVwGk7uqP1GV+Qw9SZ2HE/6ib4rgqGteOGMCAwEAAQ==";

        private static string IapName => Utils.GetConfigValue().iap;

        public static IIapSystem CurrentIapSystem { get; private set; }

        public static string LastPurchaseToken
        {
            get => PlayerPrefs.HasKey(IapName + "_lastpurchaseT")
                ? PlayerPrefs.GetString(IapName + "_lastpurchaseT")
                : null;
            set
            {
                if (value == null && PlayerPrefs.HasKey(IapName + "_lastpurchaseT"))
                    PlayerPrefs.DeleteKey(IapName + "_lastpurchaseT");
                else
                    PlayerPrefs.SetString(IapName + "_lastpurchaseT", value);
            }
        }

        public static string LastPurchasePackageName
        {
            get => PlayerPrefs.HasKey(IapName + "_lastpurchaseP")
                ? PlayerPrefs.GetString(IapName + "_lastpurchaseP")
                : null;
            set
            {
                if (value == null && PlayerPrefs.HasKey(IapName + "_lastpurchaseP"))
                    PlayerPrefs.DeleteKey(IapName + "_lastpurchaseP");
                else
                    PlayerPrefs.SetString(IapName + "_lastpurchaseP", value);
            }
        }

        public static void Init(IapSystemName name)
        {
            switch (name)
            {
#if UNITY_ANDROID
                case IapSystemName.Bazaar:
                    CurrentIapSystem = new BazaarIapSystem(BazaarPublicKey);
                    break;

                case IapSystemName.Myket:
                    CurrentIapSystem = new MyketIapSystem(MyketPublicKey);
                    break;
#endif

                default:
                    CurrentIapSystem = new EmptyIapSystem();
                    break;
            }
        }

        internal static void InitMarketUnityBridge(Action<string> onSuccess, Action onFailure, Action onConsumeSuccess,
            Action onConsumeFailed)
        {
            GameObject obj = new GameObject("[MarketBridge]");
            var bridge = obj.AddComponent<MarketUnityBridge>();

            bridge.PurchaseSucceed += onSuccess;
            bridge.PurchaseFailure += onFailure;
            bridge.ConsumeFailure += onConsumeFailed;
            bridge.ConsumeSuccess += onConsumeSuccess;
        }
    }
}