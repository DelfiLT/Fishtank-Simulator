using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFeeding : MouseState
{
    public override void ClickAction()
    {
        GameObject food = FoodPool.Instance.GetPooledFood();

        if (food != null)
        {
            food.transform.position = MousePosition.Instance.worldPosition;
            food.SetActive(true);
        }
    }
}
