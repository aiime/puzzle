using System;
using System.Collections;

using UnityEngine;

using Service;

namespace Puzzle.UI.BottomMenu
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Exit To Selection Button Controller")]
    public class ExitToSelectionButtonController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroupOfGamePanel;
        [SerializeField] private CanvasGroup canvasGroupOfSelectionPanel;
        [SerializeField] private float timeToFade;

        public Action ExitingGamePanel;

        public void OnExitToSelectionButtonClick()
        {
            StartCoroutine(FadeOut_GamePanel());
            ExitingGamePanel.SafeInvoke();
        }

        IEnumerator FadeOut_GamePanel()
        {
            canvasGroupOfGamePanel.blocksRaycasts = false;

            float currentTime = 0;

            while (canvasGroupOfGamePanel.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfGamePanel.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }

            canvasGroupOfSelectionPanel.blocksRaycasts = true;
        }
    }
}
