using System.Collections;
using UnityEngine;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Unlockable Image Behaviour")]
    public class UnlockableImageBehaviour : MonoBehaviour
    {
        [SerializeField] private CoinsModel coinsModel;
        [SerializeField] private CanvasGroup imageBlocker;
        [SerializeField] private CanvasGroup unlockButton;
        [SerializeField] private float fadeTime;

        public void OnLockClick()
        {
            if (coinsModel.Coins >= 2)
            {
                coinsModel.Coins -= 2;
                StartCoroutine(FadeCoroutines.FadeOut(imageBlocker, fadeTime));
                StartCoroutine(FadeCoroutines.FadeOut(unlockButton, fadeTime));
            }
        }
    }
}
