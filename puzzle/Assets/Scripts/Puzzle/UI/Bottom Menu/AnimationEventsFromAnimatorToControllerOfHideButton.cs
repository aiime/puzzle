using UnityEngine;
using Puzzle.UI.BottomMenu.Buttons;

namespace Puzzle.UI.BottomMenu
{
    /// <summary>
    /// Перенаправляет анимационные события на их методы-обработчики, находящиеся в скрипте на другом объекте.
    /// </summary>
    /// <remarks>
    /// Это сделано из-за того, что анимационные события "нативно" могут обрабатываться только методами в 
    /// скриптах, висящих на том же объекте, на котором висит аниматор. Если же нужные методы находятся в
    /// скрипте, висящим на другом объекте, то приходится создавать вот такой специальный скрипт-редиректор, 
    /// с помощью которого можно направлять события туда на обработку.
    /// </remarks>
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Animation Events From Animator To Controller Of Hide Button")]
    public class AnimationEventsFromAnimatorToControllerOfHideButton : MonoBehaviour
    // Не смог придумать более короткое название -______-
    {
        [SerializeField] private HideBehaviour hideButtonBehaviour;

        public void OnOpenAnimationEnd()
        {
            hideButtonBehaviour.OnOpenAnimationEnd();
        }

        public void OnHideAnimationEnd()
        {
            hideButtonBehaviour.OnHideAnimationEnd();
        }
    }
}
