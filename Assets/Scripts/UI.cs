using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (MouseManager.Instance.feeding)
        {
            MouseManager.Instance.ChangeState(MouseManager.Instance.idleState);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MouseManager.Instance.feeding)
        {
            MouseManager.Instance.ChangeState(MouseManager.Instance.feedingState);
        }
    }
}
