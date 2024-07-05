#if UNITY_ANDROID
using System;
using System.Threading.Tasks;
using MyketPlugin;
using UnityEngine;

namespace IapSystem
{
    public class MyketIapSystem : IIapSystem
    {
        private TaskCompletionSource<string> _purchaseComplete;


        public MyketIapSystem(string key)
        {
            MyketIAB.init(key);
            IapSystemHelper.InitMarketUnityBridge(OnPurchaseSuccess, OnPurchaseFailure, OnConsumeSuccess,
                OnConsumeFailed);

            Debug.Log("myket store iap service started successfully");
        }

        private void OnConsumeFailed()
        {
            _purchaseComplete.TrySetResult(null);
        }

        private void OnConsumeSuccess()
        {
            _purchaseComplete.TrySetResult(IapSystemHelper.LastPurchaseToken);
        }

        private void OnPurchaseSuccess(string token)
        {
            IapSystemHelper.LastPurchaseToken = token;
            MyketIAB.consumeProduct(IapSystemHelper.LastPurchasePackageName);
        }


        private void OnPurchaseFailure()
        {
            _purchaseComplete.TrySetResult(null);
        }


        public async Task<bool> PurchaseConsumablePackage(string packageName, string payload,
            Func<string, string, Task<bool>> validator)
        {
            IapSystemHelper.LastPurchasePackageName = packageName;
            _purchaseComplete = new TaskCompletionSource<string>();
            MyketIAB.purchaseProduct(packageName, payload);
            var token = await _purchaseComplete.Task;
            if (token == null)
                return false;

            bool valid = validator != null && await validator.Invoke(token, packageName);
            if (!valid) return false;

            IapSystemHelper.LastPurchaseToken = null;
            IapSystemHelper.LastPurchasePackageName = null;
            return true;
        }
    }
}
#endif