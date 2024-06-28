using System;
using RTLTMPro;
using UnityEngine;

namespace ChessGame
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private RTLTextMeshPro usernameText;
        [SerializeField] private RTLTextMeshPro coinText;
        public void FetchUI(string username , int coinValue)
        {
            usernameText.text = username;
            coinText.text = coinValue.ToString();
        }
    }
}