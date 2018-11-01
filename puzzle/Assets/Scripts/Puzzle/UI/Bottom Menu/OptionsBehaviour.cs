using System.Collections;
using UnityEngine;

namespace Puzzle.UI.BottomMenu
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Options Button Controller")]
    public class Controller_OptionsButton : MonoBehaviour
    {
        [SerializeField] private GameObject panel_options;
        [SerializeField] private GameObject panel_backBlocker;
        [SerializeField] private GameObject panel_optionsBlocker;
        [SerializeField] private CanvasGroup canvasGroupOfPanel_options;
        [SerializeField] private CanvasGroup canvasGroupOfPanel_backBlocker;
        [SerializeField] private float timeToFade;

        public void OnOptionsClick()
        {
            StartCoroutine(FadeInPanel_Options());
            StartCoroutine(FadeInPanel_BackBlocker());
        }

        private IEnumerator FadeInPanel_Options()
        {
            panel_backBlocker.SetActive(true);
            panel_options.SetActive(true);
            panel_optionsBlocker.SetActive(true);

            float currentTime = 0;

            while (canvasGroupOfPanel_options.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfPanel_options.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }

            panel_optionsBlocker.SetActive(false);
        }

        private IEnumerator FadeInPanel_BackBlocker()
        {
            float currentTime = 0;

            while (canvasGroupOfPanel_backBlocker.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfPanel_backBlocker.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }
        }
    }
}
