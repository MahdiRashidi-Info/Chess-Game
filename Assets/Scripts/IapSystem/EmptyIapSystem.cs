using System;
using System.Threading.Tasks;

namespace IapSystem
{
    public class EmptyIapSystem:IIapSystem
    {
        public Task<bool> PurchaseConsumablePackage(string packageName, string payload, Func<string, string, Task<bool>> validator)
        {
            throw new NotImplementedException();
        }
    }
}