using System;
using System.Collections;
using UnityEngine;

namespace Puzzle
{
    public static class FadeCoroutines
    {
        public static IEnumerator FadeIn(CanvasGroup fadingGroup, float fadeTime)
        {
            float currentTime = 0;

            while (fadingGroup.alpha < 1)
            {
                currentTime += Time.deltaTime;
                fadingGroup.alpha = Mathf.Lerp(0, 1, currentTime / fadeTime);
                yield return null;
            }

            fadingGroup.blocksRaycasts = true;
        }

        public static IEnumerator FadeIn(CanvasGroup fadingGroup, float fadeTime, Action onFadeEnd)
        {
            float currentTime = 0;

            while (fadingGroup.alpha < 1)
            {
                currentTime += Time.deltaTime;
                fadingGroup.alpha = Mathf.Lerp(0, 1, currentTime / fadeTime);
                yield return null;
            }

            fadingGroup.blocksRaycasts = true;

            onFadeEnd();
        }

        public static IEnumerator FadeIn_DONT_BLOCK_RAYCAST(CanvasGroup fadingGroup, float fadeTime)
        {
            float currentTime = 0;

            while (fadingGroup.alpha < 1)
            {
                currentTime += Time.deltaTime;
                fadingGroup.alpha = Mathf.Lerp(0, 1, currentTime / fadeTime);
                yield return null;
            }
        }

        public static IEnumerator FadeIn_DONT_BLOCK_RAYCAST(CanvasGroup fadingGroup, float fadeTime, 
            Action onFadeEnd)
        {
            float currentTime = 0;

            while (fadingGroup.alpha < 1)
            {
                currentTime += Time.deltaTime;
                fadingGroup.alpha = Mathf.Lerp(0, 1, currentTime / fadeTime);
                yield return null;
            }

            onFadeEnd();
        }

        public static IEnumerator FadeOut(CanvasGroup fadingGroup, float fadeTime)
        {
            fadingGroup.blocksRaycasts = false;

            float currentTime = 0;

            while (fadingGroup.alpha > 0)
            {
                currentTime += Time.deltaTime;
                fadingGroup.alpha = Mathf.Lerp(1, 0, currentTime / fadeTime);
                yield return null;
            }
        }

        public static IEnumerator FadeOut(CanvasGroup fadingGroup, float fadeTime, Action onFadeEnd)
        {
            fadingGroup.blocksRaycasts = false;

            float currentTime = 0;

            while (fadingGroup.alpha > 0)
            {
                currentTime += Time.deltaTime;
                fadingGroup.alpha = Mathf.Lerp(1, 0, currentTime / fadeTime);
                yield return null;
            }

            onFadeEnd();
        }
    }
}
