using UnityEngine;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Selection Item Behaviour")]
    public class SelectionItemBehaviour : MonoBehaviour, IClickable
    {
        [SerializeField] private TilesController tilesController;
        [SerializeField] private Sprite[] imageSlices;

        public void OnClick()
        {
            tilesController.PrepareGameField(imageSlices);
        }
    }
}
