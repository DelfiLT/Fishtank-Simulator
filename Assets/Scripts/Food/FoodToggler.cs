using UnityEngine;

public class FoodToggler : MonoBehaviour
{
    [field:SerializeField] public bool feeding { get; private set; }

    public void Toggle()
    {
        if (feeding == false) { feeding = true; }
        else feeding = false;
    }
}
