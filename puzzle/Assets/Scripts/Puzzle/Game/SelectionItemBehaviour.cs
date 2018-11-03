using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Selection Item Behaviour")]
    public class SelectionItemBehaviour : MonoBehaviour
    {
        [SerializeField] private Button selectionItemButton;
        [SerializeField] private TilesController tilesController;
        [SerializeField] private Sprite[] imageSlices;

        public void OnSelectionItemButtonClick()
        {
            tilesController.PrepareGameField(imageSlices);
        }
    }
}
