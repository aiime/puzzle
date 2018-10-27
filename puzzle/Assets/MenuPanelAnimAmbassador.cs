using UnityEngine;

/* Скрипт-посол. По срабатыванию ивента на анимации он отправляет команду на исполняющий скрипт, прикреплённый
 * к дочернему игровому объекту. Это сделано из-за того, что аниматор может вызывать только те функции, которые
 * прикреплены к текущему игровому объекту. Если необходимая функция висит на дочернем, то приходится делать
 * такие страшные вещи
 */
public class MenuPanelAnimAmbassador : MonoBehaviour
{
    [SerializeField] private HideMenu hideMenuScript;

    public void OnOpenAnimationEnd()
    {
        hideMenuScript.SetRightArrow();
    }

    public void OnCloseAnimationEnd()
    {
        hideMenuScript.SetLeftArrow();
    }
}
