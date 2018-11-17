using UnityEngine;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Tile Behaviour")]
    public class TileBehaviour : MonoBehaviour, IClickable
    {        
        [SerializeField] private TilesBehaviour tilesBehaviour;
        public CanvasGroup lightBorder;

        public void OnClick()
        {
            tilesBehaviour.OnTileClicked(this);
        }
    }
}
