using System;
using System.Threading.Tasks;

namespace IapSystem
{
    public interface IIapSystem
    {
        public Task<bool> PurchaseConsumablePackage(string packageName, string payload, Func<string, string, Task<bool>> validator);
    }
}