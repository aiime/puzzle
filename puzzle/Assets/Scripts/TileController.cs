﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Service;

namespace Puzzle.Game
{
    public class TileController : MonoBehaviour
    {
        [SerializeField] private Image[] tiles;

        public Action VictoryHappened;

        private Image firstTile = null;
        private Image secondTile = null;

        private const int TILES_NUMBER = 9;

        public void PrepareGameField(Sprite[] imageSlices)
        {
            /* На тайлы сразу же устанавливается перемешанное изображение, поэтому установка кусков
             * изображений идёт по маске перемешивания, которую мы далее создаём.
             */
            int[] shuffleMask = CreateShuffleMask(TILES_NUMBER);
            /* Что такое маска перемешивания?
             * К примеру, маска перемешивания получилась { 3, 7, 2, 4, 1, 5, 6, 8, 0 }. Это значит, что 
             * сначала нужно взять изображение под номером 3, затем под номером 7, затем под номером 2 и т.д.
             */

            FillTilesWithImageSlices(imageSlices, shuffleMask);
        }

        public void OnTileClicked(TileClickDetector tileClicked)
        {
            if (FirstTileNotSelected())
            {
                firstTile = tileClicked.GetComponent<Image>();
            }
            else
            {
                secondTile = tileClicked.GetComponent<Image>();

                SwapTiles();
                CleanTileReferences();
                if (ImageWasAssembledCorrectly())
                {
                    VictoryHappened.SafeInvoke();
                }
            }
        }

        private bool FirstTileNotSelected()
        {
            if (firstTile == null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            // Перемешивание Фишера-Йетса.
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
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].sprite = imageSlices[shuffleMask[i]];
            }
        }

        private void SwapTiles()
        {
            Sprite tmp = firstTile.sprite;
            firstTile.sprite = secondTile.sprite;
            secondTile.sprite = tmp;
        }

        private void CleanTileReferences()
        {
            firstTile = null;
            secondTile = null;
        }

        private bool ImageWasAssembledCorrectly()
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].sprite.name != i.ToString())
                {
                    return false;
                }
            }
            return true;
        }
    }
}