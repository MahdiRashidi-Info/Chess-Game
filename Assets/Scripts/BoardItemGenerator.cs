using System;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace ChessGame
{
    public class BoardItemGenerator : MonoBehaviour
    {
        [SerializeField] private int maxRow;
        [SerializeField] private int maxColumn;

        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform holder;

        private int _index = 0;
        private void Generate()
        {
            for (int i = 0; i < maxRow; i++)
            {
                for (int j = 0; j < maxColumn; j++)
                {
                    _index++;
                    var instantiate = Instantiate(prefab, holder, true);
                    instantiate.transform.name = $"item{_index}";
                    instantiate.transform.localScale = new Vector3(1, 1, 1);
                    var proceduralImage = instantiate.GetComponent<ProceduralImage>();
                    if (i % 2 == 0)
                        proceduralImage.color = j % 2 == 0
                            ? ColorUtils.instance.whiteBoardColor
                            : ColorUtils.instance.blackBoardColor;
                    else
                        proceduralImage.color = j % 2 == 0
                            ? ColorUtils.instance.blackBoardColor
                            : ColorUtils.instance.whiteBoardColor;
                }
            }
        }

        private void Start()
        {
            Generate();
        }
    }
}