using System;
using UnityEngine;

namespace ChessGame
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private AvatarFrameComponent firstPlayer;
        [SerializeField] private AvatarFrameComponent secondPlayer;


        public static GameView Instance;

        private void Awake()
        {
            Instance = this;
        }
        

        public void ChangeTurn(bool isWhiteTurn)
        {
            if(isWhiteTurn)
                firstPlayer.ItsTurn();
            else
                secondPlayer.ItsTurn();
        }
    }
}