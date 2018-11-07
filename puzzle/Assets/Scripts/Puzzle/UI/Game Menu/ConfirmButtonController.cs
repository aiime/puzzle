using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI.GameMenu
{
    [AddComponentMenu("Puzzle/UI/Game Menu/Confirm Button Controller")]
    public class ConfirmButtonController : MonoBehaviour
    {
        [SerializeField] private StretchyGridLayoutGroup tilesStretchyGrid;
        [SerializeField] private CanvasGroup canvasGroupOfConfirmButton;
        [SerializeField] private CanvasGroup canvasGroupOfGamePanel;
        [SerializeField] private CanvasGroup canvasGroupOfSelectionPanel;
        [SerializeField] private CanvasGroup canvasGroupOfExitToSystemButton;
        [SerializeField] private CanvasGroup canvasGroupOfExitToSelectionButton;
        [SerializeField] private float timeToFade;

        public void OnConfirmClick()
        {
            canvasGroupOfConfirmButton.blocksRaycasts = false;
            StartCoroutine(FadeOut_GamePanel());
            StartCoroutine(FadeIn_ExitToSystemButton());
            StartCoroutine(FadeOut_ExitToSelectionButton());
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

            tilesStretchyGrid.spacing = new Vector2(5, 5);
            canvasGroupOfConfirmButton.alpha = 0;
        }

        private IEnumerator FadeIn_ExitToSystemButton()
        {
            float currentTime = 0;

            while (canvasGroupOfExitToSystemButton.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfExitToSystemButton.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }

            canvasGroupOfExitToSystemButton.blocksRaycasts = true;
        }

        private IEnumerator FadeOut_ExitToSelectionButton()
        {
            canvasGroupOfExitToSelectionButton.blocksRaycasts = false;

            float currentTime = 0;

            while (canvasGroupOfExitToSelectionButton.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfExitToSelectionButton.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }
        }
    }
}
