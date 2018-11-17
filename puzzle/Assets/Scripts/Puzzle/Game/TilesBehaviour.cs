using System;
using UnityEngine;
using UnityEngine.UI;
using Service;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Tiles Behaviour")]
    public class TilesBehaviour : MonoBehaviour
    {
        [SerializeField] private Image[] tileRenderers;
        [SerializeField] private CanvasGroup selectionPanel;
        [SerializeField] private CanvasGroup gamePanel;
        [SerializeField] private float fadeTime;

        public Action EnteringGamePanel;
        public Action VictoryHappened;

        private Image firstTileRenderer = null;
        private Image secondTileRenderer = null;
        private TileBehaviour selectedTile;
        private Sprite[] victorySequence;
        private Coroutine lightBorderFadeInCoroutine;

        private const int TILES_NUMBER = 9;

        public void PrepareGameField(Sprite[] imageSlices)
        {
            victorySequence = imageSlices;

            /* На тайлы сразу же устанавливается перемешанное изображение, поэтому установка кусков
             * изображений идёт по маске перемешивания, которую мы далее создаём.
             */
            int[] shuffleMask = CreateShuffleMask(TILES_NUMBER);
            /* Что такое маска перемешивания?
             * К примеру, маска перемешивания получилась { 3, 7, 2, 4, 1, 5, 6, 8, 0 }. Это значит, что 
             * сначала нужно взять изображение под номером 3, затем под номером 7, затем под номером 2 и т.д.
             */

            FillTilesWithImageSlices(imageSlices, shuffleMask);
            StartCoroutine(FadeCoroutines.FadeOut(selectionPanel, fadeTime));
            StartCoroutine(FadeCoroutines.FadeIn(gamePanel, fadeTime));
            EnteringGamePanel.SafeInvoke();
        }

        public void OnTileClicked(TileBehaviour tileClicked)
        {
            if (FirstTileNotSelected())
            {
                firstTileRenderer = tileClicked.GetComponent<Image>();

                selectedTile = tileClicked;
                lightBorderFadeInCoroutine =
                    StartCoroutine(FadeCoroutines.FadeIn_DONT_BLOCK_RAYCAST(tileClicked.lightBorder, 0.1f));
            }
            else
            {
                secondTileRenderer = tileClicked.GetComponent<Image>();

                SwapPieces(firstTileRenderer, secondTileRenderer);
                if (lightBorderFadeInCoroutine != null) StopCoroutine(lightBorderFadeInCoroutine);
                StartCoroutine(FadeCoroutines.FadeOut(selectedTile.lightBorder, 0));

                if (ImageWasAssembledCorrectly())
                {
                    VictoryHappened.SafeInvoke();
                }
            }
        }

        private bool FirstTileNotSelected()
        {
            return firstTileRenderer == null;
        }

        private int[] CreateShuffleMask(int maskLength)
        {
            int[] arrayOfNumbers = CreatArrayOfNumbersFrom0toN(maskLength);
            int[] shuffleMask = ShuffleArray(arrayOfNumbers);

            return shuffleMask;
        }

        private int[] CreatArrayOfNumbersFrom0toN(int N)
        {
            int[] arrayOfNumbers = new int[N];

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = i;
            }

            return arrayOfNumbers;
        }

        private int[] ShuffleArray(int[] arrayToShuffle)
        {
            // Фишер-Йетс.
            for (int i = arrayToShuffle.Length; i > 0; i--)
            {
                int randomCellToSwap = UnityEngine.Random.Range(0, i);
                int tmp = arrayToShuffle[randomCellToSwap];
                arrayToShuffle[randomCellToSwap] = arrayToShuffle[i - 1];
                arrayToShuffle[i - 1] = tmp;
            }

            return arrayToShuffle;
        }

        private void FillTilesWithImageSlices(Sprite[] imageSlices, int[] shuffleMask)
        {
            for (int i = 0; i < tileRenderers.Length; i++)
            {
                tileRenderers[i].sprite = imageSlices[shuffleMask[i]];
            }
        }

        private void SwapPieces(Image firstTileRenderer, Image secondTileRenderer)
        {
            Sprite tmp = firstTileRenderer.sprite;
            firstTileRenderer.sprite = secondTileRenderer.sprite;
            secondTileRenderer.sprite = tmp;
            CleanTileReferences();
        }

        private void CleanTileReferences()
        {
            firstTileRenderer = null;
            secondTileRenderer = null;
        }

        private bool ImageWasAssembledCorrectly()
        {
            for (int i = 0; i < tileRenderers.Length; i++)
            {
                if (tileRenderers[i].sprite != victorySequence[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
