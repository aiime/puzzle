using System;
using UnityEngine;
using Service;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/CoinsModel")]
    public class CoinsModel : MonoBehaviour
    {
        [SerializeField] TilesController tilesController;
        public Action<int> CoinsAdded;
        public Action<int> CoinsRemoved;

        private int coins;
        public int Coins
        {
            get
            {
                return coins;
            }

            set
            {
                if (value > coins)
                {
                    int addedAmount = value - coins;
                    coins = value;
                    CoinsAdded.SafeInvoke(addedAmount);
                }

                if (value < coins)
                {
                    int removedAmount = coins - value;
                    coins = value;
                    CoinsRemoved.SafeInvoke(removedAmount);
                }

                if (value < 0)
                {
                    int removedAmount = coins;
                    coins = 0;
                    CoinsRemoved.SafeInvoke(removedAmount);
                }

                if (value > 999)
                {
                    int addedAmount = 999 - coins;
                    coins = 999;
                    CoinsRemoved.SafeInvoke(addedAmount);
                } 
            }
        }

        private void Start()
        {
            tilesController.VictoryHappened += () => Coins += 1;
        }
    }
}
