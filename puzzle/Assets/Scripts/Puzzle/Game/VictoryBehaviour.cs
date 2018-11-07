using System.Collections;

using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Victory Behaviour")]
    public class VictoryBehaviour : MonoBehaviour
    {
        [SerializeField] private TilesController tilesController;
        [SerializeField] private StretchyGridLayoutGroup tilesStretchyGrid;
        [SerializeField] private CanvasGroup canvasGroupOfConfirmButton;
        [SerializeField] private Animator greenFlashAnimator;

        [SerializeField] float timeToJoinImagePieces;
        [SerializeField] float timeToFade;
        [SerializeField] float timeToWaitForConfirmButton;

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
            yield return new WaitForSeconds(2);

            float currentTime = 0;

            canvasGroupOfConfirmButton.blocksRaycasts = true;

            while (canvasGroupOfConfirmButton.alpha != 1)
            {
                currentTime += Time.deltaTime;

                canvasGroupOfConfirmButton.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
        
                yield return null;
            }
        }
    }
}
