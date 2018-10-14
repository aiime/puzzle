using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.Game
{
    public class TileClickDetector : MonoBehaviour, IPointerClickHandler
    {
        public TileController tileController;
        public int tileNo;

        public void OnPointerClick(PointerEventData eventData)
        {
            tileController.OnTileClicked(this);
        }
    }
}