using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class RefuseButtonController : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject optionsPanelBlocker;
    [SerializeField] private GameObject backBlocker;
    [SerializeField] private CanvasGroup optionsPanelCanvasGroup;
    [SerializeField] private CanvasGroup backBlockerCanvasGroup;
    [SerializeField] private float timeToFade;

    private float currentTimeForOptionPanel;
    private float currentTimeForBackBlockerPanel;

    public void OnRefuseClick()
    {
        StartCoroutine(FadeOutOptionsPanel());
        StartCoroutine(FadeOutBackBlockerPanel());
    }

    private IEnumerator FadeOutOptionsPanel()
    {
        optionsPanelBlocker.SetActive(true);

        while (optionsPanelCanvasGroup.alpha != 0)
        {
            currentTimeForOptionPanel += Time.deltaTime;
            optionsPanelCanvasGroup.alpha = Mathf.Lerp(1, 0, currentTimeForOptionPanel / timeToFade);
            yield return null;
        }

        optionsPanel.SetActive(false);
        optionsPanelBlocker.SetActive(false);
        backBlocker.SetActive(false);
        currentTimeForOptionPanel = 0;
    }

    private IEnumerator FadeOutBackBlockerPanel()
    {
        while (backBlockerCanvasGroup.alpha != 0)
        {
            currentTimeForBackBlockerPanel += Time.deltaTime;
            backBlockerCanvasGroup.alpha = Mathf.Lerp(1, 0, currentTimeForBackBlockerPanel / timeToFade);
            yield return null;
        }

        currentTimeForBackBlockerPanel = 0;
    }
}
