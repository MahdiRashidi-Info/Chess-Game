using System;
using System.Threading.Tasks;
using IapSystem;
using UnityEngine;

namespace ChessGame.UserInterface.Controllers
{
    public class ShopController : MonoBehaviour
    {
        private void Awake()
        {
            var b = Utils.GetConfigValue().iap == "bazaar";
            IapSystemHelper.Init(b? IapSystemName.Bazaar : IapSystemName.Myket);
        }

        public void PurchasePack(string skuId)
        {
            IapSystemHelper.CurrentIapSystem.PurchaseConsumablePackage(skuId, "1", Validator);
        }

        private Task<bool> Validator(string arg1, string arg2)
        {
            Debug.Log(arg2);
            Debug.Log(arg1);

            return Task.FromResult(true);
        }
    }
}