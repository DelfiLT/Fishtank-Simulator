using UnityEngine;

public class FoodToggler : MonoBehaviour
{
    MouseManager manager;

    private void Start()
    {
        manager = MouseManager.Instance;
    }

    public void Toggle()
    {
        if (manager.feeding == false) { manager.feeding = true; manager.ChangeState(manager.feedingState); }
        else { manager.feeding = false; manager.ChangeState(manager.idleState); }


    }
}
