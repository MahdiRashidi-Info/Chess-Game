using UnityEngine;
using UnityEngine.UI;

namespace ChessGame.UserInterface.Views
{
	public class UpdateWinnerView : MonoBehaviour
	{
		public static UpdateWinnerView Instance { set; get; }

		public Text winner;

		private bool updated = false;

		// Start is called before the first frame update
		void Update()
		{
			if(!updated)
			{
				if(BoardManager.Instance.IsWhiteTurn)
					winner.text = "Black Team Wins!!";
				else
					winner.text = "White Team Wins!!";

				updated = true;
			}
	    	
		}
	}
}
