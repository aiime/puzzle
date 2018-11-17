using UnityEngine;
using UnityEngine.UI;
using Puzzle.Game;

namespace Puzzle.UI.CoinsMenu
{
    [AddComponentMenu("Puzzle/UI/Coins Menu/Coins View")]
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] CoinsModel coinsModel;
        [SerializeField] Text coinsValueText;
        [SerializeField] Animator coinsPanelAnimator;

        private void Start()
        {
            coinsModel.CoinsAdded += (int addedAmount) => coinsPanelAnimator.SetTrigger("RollOutPanel");
            coinsModel.CoinsRemoved += (int removedAmount) => coinsPanelAnimator.SetTrigger("RollOutPanel");
        }

        // Вызывается из анимации прибавления монеток.
        public void ChangeUIText()
        {
            coinsValueText.text = coinsModel.Coins.ToString();
        }
    }
}

