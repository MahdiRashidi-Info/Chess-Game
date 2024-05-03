using System;
using UnityEngine;

namespace ChessGame
{
    public class ColorUtils : MonoBehaviour
    {
        #region Singleton

        public static ColorUtils instance;

        private void Awake()
        {
            instance = this;
        }
        #endregion

        [SerializeField] private Color blackPieceColor;
        [SerializeField] private Color whitePieceColor;
        [SerializeField] private Color activeColor;
        [SerializeField] private Color blackBoardColor;
        [SerializeField] private Color whiteBoardColor;


    }
}