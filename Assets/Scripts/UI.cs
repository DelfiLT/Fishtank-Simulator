using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (FoodToggler.Instance.foodGrabbed)
        {
            MouseManager.Instance.ChangeState(MouseManager.Instance.idleState);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (FoodToggler.Instance.foodGrabbed)
        {
            MouseManager.Instance.ChangeState(MouseManager.Instance.feedingState);
        }
    }
}
