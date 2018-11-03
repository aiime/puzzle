using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Tile Click Detector")]
    public class TileClickDetector : MonoBehaviour, IPointerClickHandler
    {
        public TilesController tilesController;

        public void OnPointerClick(PointerEventData eventData)
        {
            tilesController.OnTileClicked(this);
        }
    }
}
