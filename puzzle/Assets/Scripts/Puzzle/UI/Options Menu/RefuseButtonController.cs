using System.Collections;
using UnityEngine;

namespace Puzzle.UI.OptionsMenu
{
    [AddComponentMenu("Puzzle/UI/Options Menu/Refuse Button Controller")]
    public class RefuseButtonController : MonoBehaviour
    {
        [SerializeField] private GameObject optionsPanel;
        [SerializeField] private GameObject backBlockerPanel;
        [SerializeField] private GameObject optionsBlockerPanel;
        [SerializeField] private CanvasGroup canvasGroupOfOptionsPanel;
        [SerializeField] private CanvasGroup canvasGroupOfBackBlockerPanel;
        [SerializeField] private float timeToFade;

        public void OnRefuseClick()
        {
            StartCoroutine(FadeOut_OptionsPanel());
            StartCoroutine(FadeOut_BackBlockerPanel());
        }

        private IEnumerator FadeOut_OptionsPanel()
        {
            optionsBlockerPanel.SetActive(true);

            float currentTime = 0;

            while (canvasGroupOfOptionsPanel.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfOptionsPanel.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }

            optionsPanel.SetActive(false);
            optionsBlockerPanel.SetActive(false);
            backBlockerPanel.SetActive(false);
        }

        private IEnumerator FadeOut_BackBlockerPanel()
        {
            float currentTime = 0;

            while (canvasGroupOfBackBlockerPanel.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfBackBlockerPanel.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }
        }
    }
}
