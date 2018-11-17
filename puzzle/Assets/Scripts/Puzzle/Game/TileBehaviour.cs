using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Tile Click Detector")]
    public class TileClickDetector : MonoBehaviour, IClickable
    {        
        [SerializeField] private TilesController tilesController;
        public CanvasGroup lightBorder;

        public void OnClick()
        {
            tilesController.OnTileClicked(this);
        }
    }
}
