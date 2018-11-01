using System.Collections;
using UnityEngine;

namespace Puzzle.UI.OptionsMenu
{
    [AddComponentMenu("Puzzle/UI/Options Menu/Refuse Button Controller")]
    public class Controller_RefuseButton : MonoBehaviour
    {
        [SerializeField] private GameObject panel_options;
        [SerializeField] private GameObject panel_backBlocker;
        [SerializeField] private GameObject panel_optionsBlocker;
        [SerializeField] private CanvasGroup canvasGroupOfPanel_options;
        [SerializeField] private CanvasGroup canvasGroupOfPanel_backBlocker;
        [SerializeField] private float timeToFade;

        public void OnRefuseClick()
        {
            StartCoroutine(FadeOutPanel_Options());
            StartCoroutine(FadeOutPanel_BackBlocker());
        }

        private IEnumerator FadeOutPanel_Options()
        {
            panel_optionsBlocker.SetActive(true);

            float currentTime = 0;

            while (canvasGroupOfPanel_options.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfPanel_options.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }

            panel_options.SetActive(false);
            panel_optionsBlocker.SetActive(false);
            panel_backBlocker.SetActive(false);
        }

        private IEnumerator FadeOutPanel_BackBlocker()
        {
            float currentTime = 0;

            while (canvasGroupOfPanel_backBlocker.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfPanel_backBlocker.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }
        }
    }
}
