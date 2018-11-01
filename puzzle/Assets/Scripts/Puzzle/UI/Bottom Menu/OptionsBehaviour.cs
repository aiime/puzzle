using System.Collections;
using UnityEngine;

namespace Puzzle.UI.BottomMenu
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Options Button Controller")]
    public class OptionsButtonController : MonoBehaviour
    {
        [SerializeField] private GameObject optionsPanel;
        [SerializeField] private GameObject backBlockerPanel;
        [SerializeField] private GameObject optionsBlockerPanel;
        [SerializeField] private CanvasGroup canvasGroupOfOptionsPanel;
        [SerializeField] private CanvasGroup canvasGroupOfBackBlockerPanel;
        [SerializeField] private float timeToFade;

        public void OnOptionsClick()
        {
            StartCoroutine(FadeIn_OptionsPanel());
            StartCoroutine(FadeIn_BackBlockerPanel());
        }

        private IEnumerator FadeIn_OptionsPanel()
        {
            backBlockerPanel.SetActive(true);
            optionsPanel.SetActive(true);
            optionsBlockerPanel.SetActive(true);

            float currentTime = 0;

            while (canvasGroupOfOptionsPanel.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfOptionsPanel.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }

            optionsBlockerPanel.SetActive(false);
        }

        private IEnumerator FadeIn_BackBlockerPanel()
        {
            float currentTime = 0;

            while (canvasGroupOfBackBlockerPanel.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfBackBlockerPanel.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }
        }
    }
}
