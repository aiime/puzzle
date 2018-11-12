using System;
using UnityEngine;
using Service;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/CoinsModel")]
    public class CoinsModel : MonoBehaviour
    {
        [SerializeField] TilesController tilesController;
        public Action<int> CoinsChanged;

        private int coins;

        private void Start()
        {
            tilesController.VictoryHappened += () => AddCoins(1);
        }

        public void AddCoins(int amount)
        {
            int newValue = coins + amount;

            if (newValue < 1000)
            {
                coins = newValue;
            }
            else
            {
                coins = 1000;
            }

            CoinsChanged.SafeInvoke(coins);
        }

        public void RemoveCoins(int amount)
        {
            int newValue = coins - amount;

            if (newValue >= 0)
            {
                coins = newValue;
            }
            else
            {
                coins = 0;
            }

            CoinsChanged.SafeInvoke(coins);
        }

        public int GetCoins()
        {
            return coins;
        }
    }
}

