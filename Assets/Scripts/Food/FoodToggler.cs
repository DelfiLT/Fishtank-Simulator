using System;
using UnityEngine;

public class FoodToggler : MonoBehaviour
{
    public static FoodToggler Instance { get; private set; }

    public bool foodGrabbed;

    MouseManager manager;

    public static Action onToggleActivated;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }

    void Start() => manager = MouseManager.Instance;

    public void Toggle()
    {
        if (foodGrabbed == false) { foodGrabbed = true; manager.ChangeState(manager.feedingState); }
        else { foodGrabbed = false; manager.ChangeState(manager.idleState); }

        onToggleActivated?.Invoke();
    }
}
