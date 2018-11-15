using System.Collections;
using UnityEngine;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Unlockable Image Behaviour")]
    public class UnlockableImageBehaviour : MonoBehaviour
    {
        [SerializeField] private CoinsModel coinsModel;
        [SerializeField] private CanvasGroup canvasGroupOf_imageBlocker;
        [SerializeField] private CanvasGroup canvasGroupOf_unlockButton;
        [SerializeField] private float timeToFade;

        public void OnLockClick()
        {
            if (coinsModel.GetCoins() >= 2)
            {
                coinsModel.RemoveCoins(2);
                StartCoroutine(RemoveLock());
            }
        }

        IEnumerator RemoveLock()
        {
            float currentTime = 0;

            while (canvasGroupOf_imageBlocker.alpha > 0)
            {
                canvasGroupOf_imageBlocker.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                canvasGroupOf_unlockButton.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);

                currentTime += Time.deltaTime;

                yield return null;
            }

            canvasGroupOf_imageBlocker.blocksRaycasts = false;
        }
    }
}
