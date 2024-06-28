using ChessGame.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame
{
    public class RateView : MonoBehaviour
    {
        [SerializeField] private Button maybeBtn;
        [SerializeField] private Button rateBtn;

        public void Open()
        {
            gameObject.SetActive(true);
            maybeBtn.AddCustomListener(() => gameObject.SetActive(false));
            rateBtn.AddCustomListener(() =>
            {
                
            });
        }
    }
}