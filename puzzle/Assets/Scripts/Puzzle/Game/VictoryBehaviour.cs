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
        [SerializeField] private TilesController tilesController;
        [SerializeField] private StretchyGridLayoutGroup tilesStretchyGrid;
        [SerializeField] private CanvasGroup confirmButton;
        [SerializeField] private Animator greenFlashAnimator;

        [SerializeField] private float timeToJoinImagePieces;
        [SerializeField] private float timeToFade;
        [SerializeField] private float timeToWaitForConfirmButton;

        public Action ConfirmButtonBeganToAppear;

        private void Start()
        {
            tilesController.VictoryHappened += () =>
            {
                StartCoroutine(JoinImagePieces());
                StartCoroutine(FadeIn_ConfirmButton());
            };
        }

        IEnumerator JoinImagePieces()
        {
            float currentTime = 0;

            while (tilesStretchyGrid.spacing.x != 0)
            {
                currentTime += Time.deltaTime;

                float newX = Mathf.Lerp(5, 0, currentTime/ timeToJoinImagePieces);
                float newY = Mathf.Lerp(5, 0, currentTime / timeToJoinImagePieces);
                tilesStretchyGrid.spacing = new Vector2(newX, newY);

                yield return null;
            }

            greenFlashAnimator.SetTrigger("StartGreenFlash");
        }

        IEnumerator FadeIn_ConfirmButton()  
        {
            yield return new WaitForSeconds(2); // Пауза перед проявлением кнопки подтверждения.

            ConfirmButtonBeganToAppear.SafeInvoke();
            StartCoroutine(FadeCoroutines.FadeIn(confirmButton, timeToFade));
        }
    }
}
