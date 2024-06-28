using UnityEngine;

public class ColorUtils : MonoBehaviour
{
    #region Singleton

    public static ColorUtils instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Color blackPieceColor;
    public Color whitePieceColor;
    public Color activeColor;
    public Color blackBoardColor;
    public Color whiteBoardColor;


}