using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame.UserInterface.Components
{
    public class AvatarFrameComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI username;
        [SerializeField] private Image avatar;
        [SerializeField] private Image circleFrame;
        [SerializeField] private Color resetColor;

        public void Fetch(string usernameValue)
        {
            username.text = usernameValue;
        }

        public void ItsTurn()
        {
            Reset();
            circleFrame.color = Color.yellow;
        }

        public void Reset()
        {
            circleFrame.color = resetColor;
        }
    }
}