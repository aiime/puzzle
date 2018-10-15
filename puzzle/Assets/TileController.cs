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
            int[] shuffleMask = CreateShuffleMask();

            for (int i = 0; i < imagePieces.Length; i++)
            {
                imagePiecesHolders[i].sprite = imagePieces[shuffleMask[i]];
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

        private int[] CreateShuffleMask()
        {
            int[] shuffleMask = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            // Тасование Фишера-Йетса
            for (int i = shuffleMask.Length; i > 0; i--)
            {
                int randomCellToSwap = Random.Range(0, i);
                int tmp = shuffleMask[randomCellToSwap];
                shuffleMask[randomCellToSwap] = shuffleMask[i - 1];
                shuffleMask[i - 1] = tmp;
            }

            return shuffleMask;
        }
    }
}