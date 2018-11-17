using UnityEngine;

namespace Puzzle.Game
{
    [AddComponentMenu("Puzzle/Game/Selection Image Behaviour")]
    public class SelectionImageBehaviour : MonoBehaviour, IClickable
    {
        [SerializeField] private TilesBehaviour tilesBehaviour;
        [SerializeField] private Sprite[] imageSlices;

        public void OnClick()
        {
            tilesBehaviour.PrepareGameField(imageSlices);
        }
    }
}
