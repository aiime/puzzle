using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.Game
{
    public class TileController : MonoBehaviour
    {
        public Image[] imagePiecesHolders;
        public Sprite[] imagePieces;

        private Image firstTile = null;
        private Image secondTile = null;

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
            if (firstTile == null)
            {
                firstTile = tileClicked.GetComponent<Image>();
            }
            else
            {
                secondTile = tileClicked.GetComponent<Image>();
                SwapTiles();
                if (CheckVictoryCondition() == true)
                {
                    print("Victory");
                }
            }
        }

        private void SwapTiles()
        {
            Sprite tmp = firstTile.sprite;
            firstTile.sprite = secondTile.sprite;
            secondTile.sprite = tmp;
            CleanReferences();
        }

        private void CleanReferences()
        {
            firstTile = null;
            secondTile = null;
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

        private bool CheckVictoryCondition()
        {
            for (int i = 0; i < imagePiecesHolders.Length; i++)
            {
                if (imagePiecesHolders[i].sprite.name != i.ToString())
                {
                    return false;
                }
            }
            return true;
        }
    }
}