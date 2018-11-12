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
            coinsModel.CoinsChanged += (int newValue) => coinsPanelAnimator.SetTrigger("RollOutPanel");
        }

        // Вызывается из анимации панели с монетками.
        public void ChangeUIText()
        {
            coinsValueText.text = coinsModel.GetCoins().ToString();
        }
    }
}

