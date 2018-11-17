using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Service;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Victory Behaviour")]
    public class VictoryBehaviour : MonoBehaviour
    {
        [SerializeField] private TilesBehaviour tilesBehaviour;
        [SerializeField] private StretchyGridLayoutGroup tilesGrid;
        [SerializeField] private CanvasGroup confirmButton;
        [SerializeField] private Animator greenFlashAnimator;

        [SerializeField] private float timeToJoinImagePieces;
        [SerializeField] private float timeToFade;
        [SerializeField] private float timeToWaitForConfirmButton;

        private void Start()
        {
            tilesBehaviour.VictoryHappened += () =>
            {
                StartCoroutine(JoinImagePieces());
                StartCoroutine(FadeIn_ConfirmButton());
            };
        }

        IEnumerator JoinImagePieces()
        {
            float currentTime = 0;

            while (tilesGrid.spacing.x != 0)
            {
                currentTime += Time.deltaTime;

                float newX = Mathf.Lerp(5, 0, currentTime/ timeToJoinImagePieces);
                float newY = Mathf.Lerp(5, 0, currentTime / timeToJoinImagePieces);
                tilesGrid.spacing = new Vector2(newX, newY);

                yield return null;
            }

            greenFlashAnimator.SetTrigger("StartGreenFlash");
        }

        IEnumerator FadeIn_ConfirmButton()  
        {
            yield return new WaitForSeconds(2); // Пауза перед проявлением кнопки подтверждения.
            StartCoroutine(FadeCoroutines.FadeIn(confirmButton, timeToFade));
        }
    }
}
