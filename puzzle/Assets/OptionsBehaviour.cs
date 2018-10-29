using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class OptionsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject optionsPanelBlocker;
    [SerializeField] private GameObject backBlocker;
    [SerializeField] private CanvasGroup optionsPanelCanvasGroup;
    [SerializeField] private CanvasGroup backBlockerCanvasGroup;
    [SerializeField] private float timeToFade;

    private float currentTimeForOptionPanel;
    private float currentTimeForBackBlockerPanel;
    
    public void OnOptionsClick()
    {
        StartCoroutine(FadeInOptionsPanel());
        StartCoroutine(FadeInBackBlockerPanel());
    }

    private IEnumerator FadeInOptionsPanel()
    {
        backBlocker.SetActive(true);    
        optionsPanel.SetActive(true);
        optionsPanelBlocker.SetActive(true);

        while (optionsPanelCanvasGroup.alpha != 1)
        {
            currentTimeForOptionPanel += Time.deltaTime;
            optionsPanelCanvasGroup.alpha = Mathf.Lerp(0, 1, currentTimeForOptionPanel / timeToFade);
            yield return null;
        }

        optionsPanelBlocker.SetActive(false);
        currentTimeForOptionPanel = 0;
    }

    private IEnumerator FadeInBackBlockerPanel()
    {
        while (backBlockerCanvasGroup.alpha != 1)
        {
            currentTimeForBackBlockerPanel += Time.deltaTime;
            backBlockerCanvasGroup.alpha = Mathf.Lerp(0, 1, currentTimeForBackBlockerPanel / timeToFade);
            yield return null;
        }

        currentTimeForBackBlockerPanel = 0;
    }
}
