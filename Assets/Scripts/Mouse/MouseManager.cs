using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public bool feeding;

    [SerializeField] MouseState currentState;
    public MouseIdle idleState;
    public MouseFeeding feedingState;

    public static MouseManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }

        idleState = this.gameObject.AddComponent<MouseIdle>();
        feedingState = this.gameObject.AddComponent<MouseFeeding>();
    }

    private void Start()
    {
        currentState = idleState;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentState.ClickAction();
        }
    }

    public void ChangeState(MouseState newState)
    {
        currentState = newState;
    }

    
}
