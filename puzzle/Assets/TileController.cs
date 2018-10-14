using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.Game
{
    public class TileController : MonoBehaviour
    {
        public Image[] imagePiecesHolders;
        public Sprite[] imagePieces;
        
        private Transform firstTileTransform = null;
        private Transform secondTileTransform = null;

        private void Awake()
        {
            for (int i = 0; i < imagePieces.Length; i++)
            {
                imagePiecesHolders[i].sprite = imagePieces[i];
            }
        }

        public void OnTileClicked(TileClickDetector tileClicked)
        {
            if (firstTileTransform == null)
            {
                firstTileTransform = tileClicked.transform;
            }
            else
            {
                secondTileTransform = tileClicked.transform;
                SwapTiles();
            }
        }

        private void SwapTiles()
        {
            Vector2 temp = firstTileTransform.position;
            firstTileTransform.position = secondTileTransform.position;
            secondTileTransform.position = temp;
            CleanReferences();
        }

        private void CleanReferences()
        {
            firstTileTransform = null;
            secondTileTransform = null;
        }
    }
}